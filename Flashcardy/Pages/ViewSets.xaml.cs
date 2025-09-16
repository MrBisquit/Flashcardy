using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace Flashcardy.Pages
{
    /// <summary>
    /// Interaction logic for ViewSets.xaml
    /// </summary>
    public partial class ViewSets : Page
    {
        public ViewSets()
        {
            InitializeComponent();

            Loaded += (sender, e) =>
            {
                Load();
            };
        }

        private void NewSetBtn_Click(object sender, RoutedEventArgs e)
        {
            Types.Set set = Helpers.Create.CreateSet();
            Helpers.Loading.SaveSet(set);
            Helpers.Loading.RegisterSet(Helpers.Loading.GetOverview(set));
            MainWindow.Teleport(this, new SetEdit(set));
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void Load()
        {
            Helpers.Loading.LoadIndex();
            Sets.Children.Clear();

            for (int i = 0; i < Helpers.Definitions.LoadedIndex.Sets.Count; i++)
            {
                Wpf.Ui.Controls.Border b = new();
                b.CornerRadius = new(5);
                b.BorderThickness = new(2);
                b.BorderBrush = new SolidColorBrush(Colors.Black);
                b.Margin = new Thickness(0, 0, 0, 5);
                Wpf.Ui.Controls.Grid g = new();
                b.Child = g;
                g.Margin = new(5);
                g.ColumnDefinitions.Add(new() { Width = new(3, GridUnitType.Star) });
                g.ColumnDefinitions.Add(new() { Width = new(1, GridUnitType.Star) });

                Wpf.Ui.Controls.StackPanel sp = new();
                g.Children.Add(sp);

                Wpf.Ui.Controls.TextBlock tb = new();
                tb.Text = Helpers.Definitions.LoadedIndex.Sets[i].Name;
                tb.FontSize = 25;
                sp.Children.Add(tb);

                Wpf.Ui.Controls.TextBlock db = new();
                db.Text = Helpers.Definitions.LoadedIndex.Sets[i].Description;
                sp.Children.Add(db);

                Wpf.Ui.Controls.TextBlock ib = new();
                ib.Text = Helpers.Definitions.LoadedIndex.Sets[i].Identifier;
                ib.FontSize = 10;
                sp.Children.Add(ib);

                Wpf.Ui.Controls.Button btn = new();
                btn.HorizontalAlignment = HorizontalAlignment.Stretch;
                btn.Appearance = ControlAppearance.Primary;
                btn.Name = $"_{i}";
                btn.Click += (sender, e) =>
                {
                    int _i = int.Parse(((Wpf.Ui.Controls.Button)e.OriginalSource).Name.Split("_")[1]);
                    Types.Set set = Helpers.Loading.LoadSet(Helpers.Definitions.LoadedIndex.Sets[_i]);
                    MainWindow.Teleport(this, new SetEdit(set));
                };
                Wpf.Ui.Controls.Grid.SetColumn(btn, 1);
                Wpf.Ui.Controls.StackPanel btnSP = new();
                btnSP.Orientation = Orientation.Horizontal;
                SymbolIcon btnSI = new();
                btnSI.Symbol = SymbolRegular.OpenFolder16;
                btnSI.VerticalAlignment = VerticalAlignment.Center;
                btnSP.Children.Add(btnSI);
                Wpf.Ui.Controls.TextBlock btnTB = new();
                btnTB.Text = "Open set";
                btnTB.Margin = new Thickness(5, 0, 0, 0);
                btnTB.VerticalAlignment = VerticalAlignment.Center;
                btnSP.Children.Add(btnTB);
                btn.Content = btnSP;
                g.Children.Add(btn);

                Sets.Children.Add(b);
            }
        }

        private async void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            VistaOpenFileDialog ofd = new()
            {
                Title = "Import a flashcard set",
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if(ofd.ShowDialog() == true)
            {
                (Types.Set, Types.SetOverview)? imported =
                    Helpers.Loading.ImportSet(ofd.FileName);

                if(imported != null)
                {
                    Helpers.Loading.RegisterSet(imported.Value.Item2);
                    Helpers.Loading.SaveSet(imported.Value.Item1);
                    Load();
                } else
                {
                    ContentDialog contentDialog = new ContentDialog(DialogPresenter);

                    contentDialog.SetCurrentValue(ContentDialog.TitleProperty, "Invalid flashcard set file");
                    contentDialog.SetCurrentValue(ContentControl.ContentProperty, "Couldn't import flashcard set from file," +
                        " please check to ensure the contents are valid and then try again.");

                    await contentDialog.ShowAsync();
                }
            }
        }
    }
}
