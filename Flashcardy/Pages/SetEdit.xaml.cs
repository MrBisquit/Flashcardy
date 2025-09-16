using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for SetEdit.xaml
    /// </summary>
    public partial class SetEdit : Page
    {
        public SetEdit(Types.Set set)
        {
            InitializeComponent();

            this.set = set;

            MainWindow.AboutToClose += async (sender, e) =>
            {
                if (SaveableContent)
                {
                    e.Cancel = true;

                    ContentDialog contentDialog = new ContentDialog(DialogPresenter);

                    contentDialog.SetCurrentValue(ContentDialog.TitleProperty, "Unsaved changes");
                    contentDialog.SetCurrentValue(ContentControl.ContentProperty, "Would you like to save your changes before closing?");
                    contentDialog.SetCurrentValue(ContentDialog.PrimaryButtonTextProperty, "Yes, save changes");
                    contentDialog.SetCurrentValue(ContentDialog.CloseButtonTextProperty, "No, discard changes");

                    ContentDialogResult result = await contentDialog.ShowAsync();
                    if (result == ContentDialogResult.Secondary)
                    {
                        Environment.Exit(0);
                    } else
                    {
                        Save();
                        Environment.Exit(0);
                    }
                }
            };

            Loaded += (sender, e) =>
            {
                NameTextBox.Text = set.Name;

                LoadAll();

                SaveableContent = false;
                MainWindow.CanSave(this, false);
            };
        }

        private bool SaveableContent = false;
        private Types.Set set;
        private List<Types.CardInterface> cards = new();
        private int Editing = -1;

        private async void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(SaveableContent)
            {
                ContentDialog contentDialog = new ContentDialog(DialogPresenter);

                contentDialog.SetCurrentValue(ContentDialog.TitleProperty, "Unsaved changes");
                contentDialog.SetCurrentValue(ContentControl.ContentProperty, "Would you like to save your changes?");
                contentDialog.SetCurrentValue(ContentDialog.PrimaryButtonTextProperty, "Yes, save changes");
                contentDialog.SetCurrentValue(ContentDialog.CloseButtonTextProperty, "No, discard changes");

                ContentDialogResult result = await contentDialog.ShowAsync();
                if (result == ContentDialogResult.Secondary)
                {
                    MainWindow.Teleport(this, new ViewSets());
                }
                else
                {
                    Save();
                    MainWindow.Teleport(this, new ViewSets());
                }
            } else
            {
                MainWindow.Teleport(this, new ViewSets());
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveableContent = true;
            MainWindow.CanSave(this, true);
        }

        private void Save()
        {
            set.Name = NameTextBox.Text;
            Helpers.Loading.SaveSet(set);

            SaveableContent = false;
            MainWindow.CanSave(this, false);
        }

        private async void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveableContent)
            {
                ContentDialog contentDialog = new ContentDialog(DialogPresenter);

                contentDialog.SetCurrentValue(ContentDialog.TitleProperty, "Unsaved changes");
                contentDialog.SetCurrentValue(ContentControl.ContentProperty, "Would you like to save your changes?");
                contentDialog.SetCurrentValue(ContentDialog.PrimaryButtonTextProperty, "Yes, save changes");
                contentDialog.SetCurrentValue(ContentDialog.CloseButtonTextProperty, "No, discard changes");

                ContentDialogResult result = await contentDialog.ShowAsync();
                if (result == ContentDialogResult.Secondary)
                {
                    MainWindow.Teleport(this, new EditDetails(set));
                }
                else
                {
                    Helpers.Loading.SaveSet(set);
                    MainWindow.Teleport(this, new EditDetails(set));
                }
            }
            else
            {
                MainWindow.Teleport(this, new EditDetails(set));
            }
        }

        private async void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveableContent)
            {
                ContentDialog contentDialog = new ContentDialog(DialogPresenter);

                contentDialog.SetCurrentValue(ContentDialog.TitleProperty, "Unsaved changes");
                contentDialog.SetCurrentValue(ContentControl.ContentProperty, "Would you like to save your changes?");
                contentDialog.SetCurrentValue(ContentDialog.PrimaryButtonTextProperty, "Yes, save changes");
                contentDialog.SetCurrentValue(ContentDialog.CloseButtonTextProperty, "No, discard changes");

                ContentDialogResult result = await contentDialog.ShowAsync();
                if (result == ContentDialogResult.Secondary)
                {
                    MainWindow.Teleport(this, new Export(set));
                }
                else
                {
                    Helpers.Loading.SaveSet(set);
                    MainWindow.Teleport(this, new Export(set));
                }
            }
            else
            {
                MainWindow.Teleport(this, new Export(set));
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            set.cards.Add(Helpers.Create.CreateCard());
            Editing = set.cards.Count - 1;
            LoadAll();

            SaveableContent = true;
            MainWindow.CanSave(this, true);
        }

        private void LoadAll()
        {
            cards.Clear();
            Cards.Children.Clear();
            for (int i = 0; i < set.cards.Count; i++)
            {
                Types.CardInterface card =
                    Helpers.CardInterface.GenerateCard(set.cards[i], Editing == i, set);

                cards.Add(card);
                Cards.Children.Add(card.Border);

                card.DeleteBtn.Name = $"d_{i}";
                card.DeleteBtn.Click += (sender, e) =>
                {
                    int _i = int.Parse(((Wpf.Ui.Controls.Button)e.OriginalSource).Name.Split("_")[1]);
                    DeleteSelected(_i);
                };

                if (card.EditMode)
                {
                    card.Edit.SaveBtn.Name = $"s_{i}";
                    card.Edit.SaveBtn.Click += (sender, e) =>
                    {
                        int _i = int.Parse(((Wpf.Ui.Controls.Button)e.OriginalSource).Name.Split("_")[1]);
                        SaveSelected(_i);
                    };

                    card.Edit.DiscardBtn.Name = $"dc_{i}";
                    card.Edit.DiscardBtn.Click += (sender, e) =>
                    {
                        int _i = int.Parse(((Wpf.Ui.Controls.Button)e.OriginalSource).Name.Split("_")[1]);
                        DiscardSelected(_i);
                    };
                } else
                {
                    card.Normal.EditBtn.Name = $"e_{i}";
                    card.Normal.EditBtn.Click += (sender, e) =>
                    {
                        int _i = int.Parse(((Wpf.Ui.Controls.Button)e.OriginalSource).Name.Split("_")[1]);
                        Editing = _i;
                        LoadAll();
                    };
                }
            }
        }

        private async void DeleteSelected(int i)
        {
            ContentDialog contentDialog = new ContentDialog(DialogPresenter);

            contentDialog.SetCurrentValue(ContentDialog.TitleProperty, "Are you sure?");
            contentDialog.SetCurrentValue(ContentControl.ContentProperty, $"Deleting a card is permanent and cannot be undone.");
            contentDialog.SetCurrentValue(ContentDialog.PrimaryButtonTextProperty, "Delete card");
            contentDialog.SetCurrentValue(ContentDialog.CloseButtonTextProperty, "Cancel");
            contentDialog.SetCurrentValue(ContentDialog.PrimaryButtonAppearanceProperty, ControlAppearance.Danger);

            ContentDialogResult result = await contentDialog.ShowAsync();
            if (result == ContentDialogResult.Secondary)
            {
                return;
            }
            else
            {
                set.cards.RemoveAt(i);
                Editing = -1;
                LoadAll();

                SaveableContent = true;
                MainWindow.CanSave(this, true);
            }
        }

        private async void DiscardSelected(int i)
        {
            ContentDialog contentDialog = new ContentDialog(DialogPresenter);

            contentDialog.SetCurrentValue(ContentDialog.TitleProperty, "Unsaved changes");
            contentDialog.SetCurrentValue(ContentControl.ContentProperty, "Would you like to save your changes?");
            contentDialog.SetCurrentValue(ContentDialog.PrimaryButtonTextProperty, "Yes, save changes");
            contentDialog.SetCurrentValue(ContentDialog.CloseButtonTextProperty, "No, discard changes");

            ContentDialogResult result = await contentDialog.ShowAsync();
            if (result == ContentDialogResult.Secondary)
            {
                Editing = -1;
                LoadAll();
            }
            else
            {
                SaveSelected(i);
            }
        }

        private void SaveSelected(int i)
        {
            set.cards[i].Name = cards[i].Edit.NameTB.Text;
            set.cards[i].Description = cards[i].Edit.DescTB.Text;
            set.cards[i].Identifier = cards[i].Edit.IDTB.Text;
            set.cards[i].Answer = cards[i].Edit.AnswerTB.Text;

            Editing = -1;
            LoadAll();

            SaveableContent = true;
            MainWindow.CanSave(this, true);
        }
    }
}
