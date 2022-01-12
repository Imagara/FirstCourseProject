using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kusach.Pages
{
    /// <summary>
    /// Логика взаимодействия для TransportListPage.xaml
    /// </summary>
    public partial class TransportListPage : Page
    {
        public TransportListPage()
        {
            InitializeComponent();
            TransportList.ItemsSource = cnt.db.Transport.ToList();
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Windows.DriverEditWindow dew = new Windows.DriverEditWindow(((Transport)TransportList.SelectedItem).IdDriver);
            dew.Show();
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
                TransportList.ItemsSource = cnt.db.Transport.Where(item => (item.IdDriver + " " + item.Transport.NameOfTransport + " " + item.Surname + " " + item.Name + " " + item.Patronymic).Contains(SearchBox.Text)).ToList();
            else
                cnt.db.Transport.ToList();
        }
        #endregion
        private void AddDriverButton_Click(object sender, RoutedEventArgs e)
        {
            AddDriverWindow adw = new AddDriverWindow();
            adw.Show();
        }

        private void DeleteTransportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateTransportButton_Click(object sender, RoutedEventArgs e)
        {
            TransportList.ItemsSource = cnt.db.Transport.ToList();
        }
    }
}
