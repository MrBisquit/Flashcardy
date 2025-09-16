using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flashcardy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Wpf.Ui.Appearance.WindowBackgroundManager.ApplyDarkThemeToWindow(this);

            //Wpf.Ui.Appearance.ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme.Dark,
            //    Wpf.Ui.Controls.WindowBackdropType.Mica, true);

            Loaded += (sender, args) =>
            {
                Wpf.Ui.Appearance.SystemThemeWatcher.Watch(
                    this,                                    // Window class
                    Wpf.Ui.Controls.WindowBackdropType.Mica, // Background type
                    true                                     // Whether to change accents automatically
                );

                Helpers.Loading.Init();

                FContent.Content = new Pages.ViewSets();
            };

            Teleport += (sender, page) =>
            {
                FContent.Content = page;
                try
                {
                    if (AboutToClose == null) return;
                    foreach (Delegate d in AboutToClose.GetInvocationList())
                    {
                        AboutToClose -= (EventHandler<CancelEventArgs>)d;
                    }
                } catch { }
            };

            CanSave += (sender, canSave) =>
            {
                if (canSave) Title = "Flashcardy*";
                else Title = "Flashcardy";
            };

            Closing += (sender, closing) =>
            {
                if(AboutToClose != null) AboutToClose.Invoke(this, closing);
            };
        }

        public static EventHandler<Page>? Teleport;
        public static EventHandler<bool>? CanSave;
        public static EventHandler<CancelEventArgs>? AboutToClose;
    }
}