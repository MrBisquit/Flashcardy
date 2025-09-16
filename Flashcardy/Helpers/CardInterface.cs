using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace Flashcardy.Helpers
{
    public static class CardInterface
    {
        public static Types.CardInterface GenerateCard(Types.Flashcard card, bool edit)
        {
            Types.CardInterface cardInterface = new();
            cardInterface.EditMode = edit;
            cardInterface.Border = new();
            cardInterface.Border.Margin = new(5);
            cardInterface.Border.Padding = new(5);
            cardInterface.Border.BorderThickness = new(2);
            cardInterface.Border.BorderBrush = new SolidColorBrush(Colors.Black);
            cardInterface.Border.CornerRadius = new(5);
            cardInterface.Border.Width = 350;
            cardInterface.Border.Height = 250;
            cardInterface.Grid = new();
            cardInterface.Border.Child = cardInterface.Grid;

            cardInterface.Grid.ColumnDefinitions.Add(new()
            {
                Width = new(1, System.Windows.GridUnitType.Star)
            });
            cardInterface.Grid.ColumnDefinitions.Add(new()
            {
                Width = new(1, System.Windows.GridUnitType.Auto)
            });

            cardInterface.ContentStackPanel = new();
            cardInterface.ContentStackPanel.Margin = new(5);
            cardInterface.Grid.Children.Add(cardInterface.ContentStackPanel);

            cardInterface.BtnStackPanel = new();
            cardInterface.BtnStackPanel.Margin = new(5);
            Grid.SetColumn(cardInterface.BtnStackPanel, 1);
            cardInterface.Grid.Children.Add(cardInterface.BtnStackPanel);

            if(edit)
            {
                cardInterface.Edit = new();
                cardInterface.Edit.NameLabel = new();
                cardInterface.Edit.DescLabel = new();
                cardInterface.Edit.IDLabel = new();
                cardInterface.Edit.AnswerLabel = new();
                cardInterface.Edit.NameTB = new();
                cardInterface.Edit.DescTB = new();
                cardInterface.Edit.IDTB = new();
                cardInterface.Edit.AnswerTB = new();
                cardInterface.Edit.SaveBtn = new();
                cardInterface.Edit.DiscardBtn = new();

                cardInterface.Edit.NameLabel.Text = "Name:";
                cardInterface.Edit.DescLabel.Text = "Description:";
                cardInterface.Edit.IDLabel.Text = "Identifier:";
                cardInterface.Edit.AnswerLabel.Text = "Answer:";

                cardInterface.Edit.NameTB.Text = card.Name;
                cardInterface.Edit.DescTB.Text = card.Description;
                cardInterface.Edit.IDTB.Text = card.Identifier;
                cardInterface.Edit.AnswerTB.Text = card.Answer;

                cardInterface.ContentStackPanel.Children.Add(cardInterface.Edit.NameLabel);
                cardInterface.ContentStackPanel.Children.Add(cardInterface.Edit.NameTB);
                cardInterface.ContentStackPanel.Children.Add(cardInterface.Edit.DescLabel);
                cardInterface.ContentStackPanel.Children.Add(cardInterface.Edit.DescTB);
                cardInterface.ContentStackPanel.Children.Add(cardInterface.Edit.IDLabel);
                cardInterface.ContentStackPanel.Children.Add(cardInterface.Edit.IDTB);
                cardInterface.ContentStackPanel.Children.Add(cardInterface.Edit.AnswerLabel);
                cardInterface.ContentStackPanel.Children.Add(cardInterface.Edit.AnswerTB);

                cardInterface.Edit.SaveBtn.Appearance = ControlAppearance.Primary;
                cardInterface.Edit.SaveBtn.Content =
                    new SymbolIcon(SymbolRegular.Save16);

                cardInterface.Edit.DiscardBtn.Appearance = ControlAppearance.Secondary;
                cardInterface.Edit.DiscardBtn.Content =
                    new SymbolIcon(SymbolRegular.ArrowExit20);

                cardInterface.BtnStackPanel.Children.Add(cardInterface.Edit.SaveBtn);
                cardInterface.BtnStackPanel.Children.Add(cardInterface.Edit.DiscardBtn);
            } else
            {
                cardInterface.Normal = new();
                cardInterface.Normal.Name = new();
                cardInterface.Normal.Desc = new();
                cardInterface.Normal.ID = new();
                cardInterface.Normal.Answer = new();
                cardInterface.Normal.EditBtn = new();

                cardInterface.Normal.Name.Text = card.Name;
                cardInterface.Normal.Desc.Text = card.Description;
                cardInterface.Normal.ID.Text = card.Identifier;
                cardInterface.Normal.Answer.Text = $"Answer: {card.Answer}";

                cardInterface.Normal.Name.FontSize = 17;
                cardInterface.Normal.Desc.FontSize = 15;
                cardInterface.Normal.ID.FontSize = 10;
                cardInterface.Normal.Answer.FontSize = 15;

                cardInterface.ContentStackPanel.Children.Add(cardInterface.Normal.Name);
                cardInterface.ContentStackPanel.Children.Add(cardInterface.Normal.Desc);
                cardInterface.ContentStackPanel.Children.Add(cardInterface.Normal.ID);
                cardInterface.ContentStackPanel.Children.Add(cardInterface.Normal.Answer);

                cardInterface.Normal.EditBtn.Appearance = ControlAppearance.Primary;
                cardInterface.Normal.EditBtn.Content =
                    new SymbolIcon(SymbolRegular.DocumentEdit16);

                cardInterface.BtnStackPanel.Children.Add(cardInterface.Normal.EditBtn);
            }

            cardInterface.DeleteBtn = new();
            cardInterface.DeleteBtn.Appearance = ControlAppearance.Danger;
            cardInterface.DeleteBtn.Content = new SymbolIcon(SymbolRegular.Delete12);
            cardInterface.BtnStackPanel.Children.Add(cardInterface.DeleteBtn);

            return cardInterface;
        }
    }
}
