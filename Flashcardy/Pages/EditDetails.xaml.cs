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
    /// Interaction logic for EditDetails.xaml
    /// </summary>
    public partial class EditDetails : Page
    {
        public EditDetails(Types.Set set)
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
                    }
                    else
                    {
                        Save();
                        Environment.Exit(0);
                    }
                }
            };

            Loaded += (sender, e) =>
            {
                NameTB.Text = set.Name;
                DescTB.Text = set.Description;
                IDTB.Text = set.Identifier;
                LinkedIDs.IsChecked = set.LinkedID;

                SaveableContent = false;
                MainWindow.CanSave(this, false);
            };
        }

        private bool SaveableContent = false;
        private Types.Set set;

        private async void BackBtn_Click(object sender, RoutedEventArgs e)
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
                    MainWindow.Teleport(this, new SetEdit(set));
                }
                else
                {
                    Save();
                    MainWindow.Teleport(this, new SetEdit(set));
                }
            }
            else
            {
                MainWindow.Teleport(this, new SetEdit(set));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void NameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveableContent = true;
            MainWindow.CanSave(this, true);
        }

        private void DescTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveableContent = true;
            MainWindow.CanSave(this, true);
        }

        private void IDTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveableContent = true;
            MainWindow.CanSave(this, true);
        }

        private void LinkedIDs_Click(object sender, RoutedEventArgs e)
        {
            SaveableContent = true;
            MainWindow.CanSave(this, true);
        }

        private void Save()
        {
            set.Name = NameTB.Text;
            set.Description = DescTB.Text;
            set.Identifier = IDTB.Text;
            set.LinkedID = LinkedIDs.IsChecked == true;
            Helpers.Loading.SaveSet(set);

            SaveableContent = false;
            MainWindow.CanSave(this, false);
        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog(DialogPresenter);

            contentDialog.SetCurrentValue(ContentDialog.TitleProperty, "Are you sure?");
            contentDialog.SetCurrentValue(ContentControl.ContentProperty, $"Deleting a set is permanent and cannot be undone.\n" +
                $"{set.cards.Count} flashcards within this set will be DELETED.");
            contentDialog.SetCurrentValue(ContentDialog.PrimaryButtonTextProperty, "Delete set");
            contentDialog.SetCurrentValue(ContentDialog.CloseButtonTextProperty, "Cancel");
            contentDialog.SetCurrentValue(ContentDialog.PrimaryButtonAppearanceProperty, ControlAppearance.Danger);

            ContentDialogResult result = await contentDialog.ShowAsync();
            if (result == ContentDialogResult.Secondary)
            {
                return;
            }
            else
            {
                Helpers.Loading.DeleteSet(set);
                MainWindow.Teleport(this, new ViewSets());
            }
        }
    }
}
