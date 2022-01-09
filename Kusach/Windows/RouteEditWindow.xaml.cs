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
    /// Логика взаимодействия для RouteEditWindow.xaml
    /// </summary>
    public partial class RouteEditWindow : Window
    {
        public RouteEditWindow(int id)
        {
            InitializeComponent(); 
            RouteNameBox.Text = cnt.db.Routes.Where(item => item.IdRoute == id).Select(item => item.Name).FirstOrDefault();
            PointsListDataGrid.ItemsSource = cnt.db.PointsList.Where(item => item.IdRoute == id).ToList();
            DriversListDataGrid.ItemsSource = cnt.db.DriversList.Where(item => item.IdRoute == id).ToList();

        }
        private void PointsDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("cell: " + ((PointsList)PointsListDataGrid.SelectedItem).IdPoint);
        }
        private void DriversDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("cell: " + ((DriversList)DriversListDataGrid.SelectedItem).IdDriver);
        }
        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
