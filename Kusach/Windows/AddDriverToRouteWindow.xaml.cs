using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Kusach.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddDriverToRouteWindow.xaml
    /// </summary>
    public partial class AddDriverToRouteWindow : Window
    {
        public int driverId = -1;
        public AddDriverToRouteWindow(int id)
        {
            InitializeComponent();
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
    }
}