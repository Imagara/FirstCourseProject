using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Kusach.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPointToRouteWindow.xaml
    /// </summary>
    public partial class AddPointToRouteWindow : Window
    {
        public AddPointToRouteWindow()
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
