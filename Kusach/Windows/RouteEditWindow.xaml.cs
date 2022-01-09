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
        int RouteId;
        public RouteEditWindow(int id)
        {
            InitializeComponent();
            RouteId = id;
            RouteNameBox.Text = cnt.db.Routes.Where(item => item.IdRoute == RouteId).Select(item => item.Name).FirstOrDefault();
            PointsListDataGrid.ItemsSource = cnt.db.PointsList.Where(item => item.IdRoute == RouteId).ToList();
            DriversListDataGrid.ItemsSource = cnt.db.DriversList.Where(item => item.IdRoute == RouteId).ToList();

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
            AddPointWindow apw = new AddPointWindow(RouteId);
            apw.ShowDialog();
        }
        private void RemovePoint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cnt.db.PointsList.Remove(cnt.db.PointsList.Where(item => item.IdRoute == RouteId && item.IdPoint == ((PointsList)PointsListDataGrid.SelectedItem).IdPoint).FirstOrDefault());
                cnt.db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления записи.");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddFromListPoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdatePoints_Click(object sender, RoutedEventArgs e)
        {
            PointsListDataGrid.ItemsSource = cnt.db.PointsList.Where(item => item.IdRoute == RouteId).ToList();
        }
    }
}
