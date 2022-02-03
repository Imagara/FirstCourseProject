using System;
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
            RoutesList.ItemsSource = cnt.db.RouteList.Where(item => item.IdDispatcher == profile.DispatcherId).ToList();
            if (profile.Permission != 0)
                CreateButton.Visibility = Visibility.Collapsed;
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Windows.RouteEditWindow rew = new Windows.RouteEditWindow(((RouteList)RoutesList.SelectedItem).IdRoute);
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
                RoutesList.ItemsSource = cnt.db.RouteList.Where(item => (item.Routes.IdRoute + " " + item.Routes.Name).Contains(SearchBox.Text) && item.IdDispatcher == profile.DispatcherId).ToList();
            else
                cnt.db.RouteList.Where(item => item.IdDispatcher == profile.DispatcherId).ToList();
        }
        #endregion
        private void AddRouteButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddRouteToDispatcherWindow artdw = new Windows.AddRouteToDispatcherWindow();
            artdw.ShowDialog();
            int routeId = artdw.routeId;
            if (routeId != -1)
            {
                try
                {
                    RouteList newAddRouteToDispatcher = new RouteList()
                    {
                        Id = cnt.db.RouteList.Select(p => p.Id).DefaultIfEmpty(0).Max() + 1,
                        IdRoute = routeId,
                        IdDispatcher = profile.DispatcherId
                    };
                    cnt.db.RouteList.Add(newAddRouteToDispatcher);
                    cnt.db.SaveChanges();
                    MessageBox.Show("Маршрут успешно добавлена");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка добавления записи" + exc);
                }
            }

        }
        private void UpdateRoutesButton_Click(object sender, RoutedEventArgs e)
        {
            RoutesList.ItemsSource = cnt.db.RouteList.Where(item => item.IdDispatcher == profile.DispatcherId).ToList();
        }
    }
}
