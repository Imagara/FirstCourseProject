using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Kusach.Windows
{
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
            new AddRouteWindow().Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
