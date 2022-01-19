using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kusach.Pages
{
    /// <summary>
    /// Логика взаимодействия для DriversListPage.xaml
    /// </summary>
    public partial class DriversListPage : Page
    {
        public DriversListPage()
        {
            InitializeComponent();
            DriversList.ItemsSource = cnt.db.Drivers.ToList();
            if (profile.Permission != 0)
                CreateButton.Visibility = Visibility.Collapsed;
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (profile.Permission == 0)
            {
                Windows.DriverEditWindow dew = new Windows.DriverEditWindow(((Drivers)DriversList.SelectedItem).IdDriver);
                dew.Show();
            }
        }

        #region Поиск
        private void SearchBoxPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SearchBox.Text == "Поиск...")
                SearchBox.Text = "";
        }
        private void SearchLostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "")
                SearchBox.Text = "Поиск...";
        }
        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text != "" && SearchBox.Text != "Поиск...")
                DriversList.ItemsSource = cnt.db.Drivers.Where(item => (item.IdDriver + " " + item.Transport.NameOfTransport + " " + item.Surname + " " + item.Name + " " + item.Patronymic).Contains(SearchBox.Text)).ToList();
            else
                cnt.db.Drivers.ToList();
        }
        #endregion
        private void AddDriverButton_Click(object sender, RoutedEventArgs e)
        {
            AddDriverWindow adw = new AddDriverWindow();
            adw.Show();
        }

        private void UpdateDriversButton_Click(object sender, RoutedEventArgs e)
        {
            DriversList.ItemsSource = cnt.db.Drivers.ToList();
        }
    }
}
