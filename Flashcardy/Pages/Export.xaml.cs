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
using Wpf.Ui.Violeta.Controls;

namespace Flashcardy.Pages
{
    /// <summary>
    /// Interaction logic for Export.xaml
    /// </summary>
    public partial class Export : Page
    {
        public Export(Types.Set set)
        {
            InitializeComponent();

            this.set = set;

            Loaded += (sender, e) =>
            {
                LoadPreview();
            };
        }

        private Types.Set set;

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
            switch (ExportType.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    ExportJSON();
                    break;
                default:
                    break;
            }
            IsEnabled = true;
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadPreview();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Teleport(this, new SetEdit(set));
        }

        private void ExportJSON()
        {
            VistaSaveFileDialog sfd = new VistaSaveFileDialog()
            {
                Title = "Export a flashcard set",
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                AddExtension = true
            };

            if(sfd.ShowDialog() == true)
            {
                Helpers.Loading.ExportSet(sfd.FileName, set);
            }
        }

        private void ExportType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PPP == null) return;

            PPP.Visibility = Visibility.Collapsed;
            switch (ExportType.SelectedIndex)
            {
                case 0:
                    PPP.Visibility = Visibility.Visible;
                    break;
                case 1:

                    break;
                case 2:

                    break;
                default:
                    break;
            }

            LoadPreview();
        }

        private void LoadPreview()
        {
            if (Preview == null) return;

            Preview.Children.Clear();
            Preview.ColumnDefinitions.Clear();
            Preview.RowDefinitions.Clear();

            switch(ExportType.SelectedIndex)
            {
                case 0:
                    Preview.Children.Add(Helpers.Preview.PowerPointPreview(PPPSize.SelectedIndex,
                        PPPMode.SelectedIndex));
                    break;
                case 1:

                    break;
                case 2:
                    TextBlock no = new()
                    {
                        Text = "No preview available for this export type",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    Preview.Children.Add(no);
                    break;
                default:
                    break;
            }
        }

        private void PPPSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadPreview();
        }

        private void PPPMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadPreview();
        }
    }
}
