using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kusach.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoutesListPage.xaml
    /// </summary>
    public partial class RoutesListPage : Page
    {
        public RoutesListPage()
        {
            InitializeComponent();
            RoutesList.ItemsSource = cnt.db.Routes.ToList();
            if (profile.Permission != 0)
                CreateButton.Visibility = Visibility.Collapsed;
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Windows.RouteEditWindow rew = new Windows.RouteEditWindow(((Routes)RoutesList.SelectedItem).IdRoute);
                rew.Show();
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
                RoutesList.ItemsSource = cnt.db.Routes.Where(item => (item.IdRoute + " " + item.Name).Contains(SearchBox.Text)).ToList();
            else
                cnt.db.Routes.ToList();
        }
        #endregion
        private void AddRouteButton_Click(object sender, RoutedEventArgs e)
        {
            AddRouteWindow arw = new AddRouteWindow();
            arw.Show();
        }
        private void UpdateRoutesButton_Click(object sender, RoutedEventArgs e)
        {
            RoutesList.ItemsSource = cnt.db.Routes.ToList();
        }
    }
}
