using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TestRouteEditWindow trew = new TestRouteEditWindow(((Routes)RoutesList.SelectedItem).IdRoute);
            trew.Show();
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

        private void DeleteRouteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateRoutesButton_Click(object sender, RoutedEventArgs e)
        {
            RoutesList.ItemsSource = cnt.db.Routes.ToList();
        }
    }
}
