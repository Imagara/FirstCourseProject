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
    /// Логика взаимодействия для TestRouteEditWindow.xaml
    /// </summary>
    public partial class TestRouteEditWindow : Window
    {
        Routes route;
        public TestRouteEditWindow(int id)
        {
            InitializeComponent();
            RouteNameBox.Text = cnt.db.Routes.Where(item => item.IdRoute == id).Select(item => item.Name).FirstOrDefault();
            
            
            PointsListDataGrid.ItemsSource = cnt.db.PointsList.Where(item => item.IdRoute == id).ToList();
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(((PointsList)PointsListDataGrid.SelectedItem) != null)
            MessageBox.Show("cell: " + ((PointsList)PointsListDataGrid.SelectedItem).IdPoint);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TestWindow tw = new TestWindow();
            //tw.Show();
            //this.Close();
        }
    }
}
