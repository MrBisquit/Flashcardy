using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;

namespace Flashcardy.Types
{
    public class CardInterface
    {
        public Border Border { get; set; }
        public Grid Grid { get; set; }

        public bool EditMode { get; set; } = false;
        public NormalElements Normal;
        public EditElements Edit;

        public Button DeleteBtn;

        public StackPanel ContentStackPanel { get; set; }
        public StackPanel BtnStackPanel { get; set; }

        public class NormalElements
        {
            public TextBlock Name;
            public TextBlock Desc;
            public TextBlock ID;
            public TextBlock Answer;

            public Button EditBtn;
        }

        public class EditElements
        {
            public TextBlock NameLabel;
            public TextBox NameTB;

            public TextBlock DescLabel;
            public TextBox DescTB;

            public TextBlock IDLabel;
            public TextBox IDTB;

            public TextBlock AnswerLabel;
            public TextBox AnswerTB;

            public Button SaveBtn;
            public Button DiscardBtn;
        }
    }
}
