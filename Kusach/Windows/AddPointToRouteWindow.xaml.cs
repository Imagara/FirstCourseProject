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
    /// Логика взаимодействия для AddPointToRouteWindow.xaml
    /// </summary>
    public partial class AddPointToRouteWindow : Window
    {
        public AddPointToRouteWindow(int id)
        {
            InitializeComponent();
            PointsListDataGrid.ItemsSource = cnt.db.Points.ToList();
        }
        public int pointId = -1;
        private void PointsDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            pointId = ((Points)PointsListDataGrid.SelectedItem).IdPoint;
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
