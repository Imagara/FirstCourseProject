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

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            //if (SearchBox.Text != "")
            //    RoutesList.ItemsSource = cnt.db.Routes.Where(item => (item.IdRoute + " " + item.Name).Contains(SearchBox.Text)).ToList();
            //else
            //    RoutesList.ItemsSource = cnt.db.Routes.ToList();
        }

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

        }
    }
}
