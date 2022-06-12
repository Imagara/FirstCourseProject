using System.Windows;

namespace Kusach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (profile.Permission != 0)
                DispatchersButton.Visibility = Visibility.Collapsed;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new LogWindow().Show();
            this.Close();
        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.RoutesListPage();
        }
        #region LeftPanelButtons
        private void RoutesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.RoutesListPage();
        }

        private void DriversButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.DriversListPage();
        }
        private void VehButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.TransportListPage();
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.DispatcherListPage();
        }
        #endregion

        private void PointsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.PointsListPage();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.ProfilePage();
        }
    }
}
