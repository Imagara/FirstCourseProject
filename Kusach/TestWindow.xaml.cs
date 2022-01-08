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
using System.Windows.Shapes;

namespace Kusach
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
            RoutesList.ItemsSource = cnt.db.Routes.ToList();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TestRouteEditWindow trew = new TestRouteEditWindow(((Routes)RoutesList.SelectedItem).IdRoute);
            trew.Show();
            this.Close();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if(SearchBox.Text != "")
                RoutesList.ItemsSource = cnt.db.Routes.Where(item => (item.IdRoute + " " + item.IdDriver + " " + item.Name).Contains(SearchBox.Text)).ToList();
            else
                RoutesList.ItemsSource = cnt.db.Routes.ToList();
        }
    }
}
