using System.Windows;

namespace Kusach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            LogWindow lw = new LogWindow();
            lw.Show();
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
            MainFrame.Content = new TestPGPage();
        }
        #endregion

    }
}
