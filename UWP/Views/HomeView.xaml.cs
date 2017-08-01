using Windows.UI.Xaml.Controls;

namespace Uwp.Views
{
    public partial class HomeView : Page
    {
        public HomeView()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MenuPanel.IsPaneOpen = !MenuPanel.IsPaneOpen;
        }
    }
}
