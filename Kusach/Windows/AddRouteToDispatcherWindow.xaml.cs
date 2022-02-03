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

namespace Kusach.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddRouteToDispatcherWindow.xaml
    /// </summary>
    public partial class AddRouteToDispatcherWindow : Window
    {
        public int routeId = -1;
        public AddRouteToDispatcherWindow()
        {
            InitializeComponent();
            RoutesListDataGrid.ItemsSource = cnt.db.Routes.ToList();
        }
        private void RouteDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            routeId = ((Routes)RoutesListDataGrid.SelectedItem).IdRoute;
            this.Close();
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            AddRouteWindow arw = new AddRouteWindow();
            arw.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
