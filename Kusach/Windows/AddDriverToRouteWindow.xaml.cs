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