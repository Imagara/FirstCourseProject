using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Kusach.Windows
{
    public partial class AddDriverToRouteWindow : Window
    {
        public int driverId = -1; int routeId;
        public AddDriverToRouteWindow(int id)
        {
            InitializeComponent();
            routeId = id;
            DriversListDataGrid.ItemsSource = cnt.db.Drivers.ToList();
        }
        private void PointsDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            driverId = ((Drivers)DriversListDataGrid.SelectedItem).IdDriver;
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            new AddDriverWindow(routeId).ShowDialog();
            this.Close();
        }
    }
}