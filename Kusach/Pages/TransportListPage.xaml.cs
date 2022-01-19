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
            if (profile.Permission != 0)
                CreateButton.Visibility = Visibility.Collapsed;
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (profile.Permission == 0)
            {
                Windows.TransportEditWindow tew = new Windows.TransportEditWindow(((Transport)TransportList.SelectedItem).IdTransport);
                tew.Show();
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
                TransportList.ItemsSource = cnt.db.Transport.Where(item => (item.IdTransport + " " + item.NameOfTransport + " " + item.NumberPlate).Contains(SearchBox.Text)).ToList();
            else
                cnt.db.Transport.ToList();
        }
        #endregion
        private void AddTransportButton_Click(object sender, RoutedEventArgs e)
        {
            AddTransportWindow atw = new AddTransportWindow();
            atw.Show();
        }
        private void UpdateTransportButton_Click(object sender, RoutedEventArgs e)
        {
            TransportList.ItemsSource = cnt.db.Transport.ToList();
        }
    }
}
