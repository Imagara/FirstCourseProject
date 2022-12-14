using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Kusach.Windows
{
    public partial class RouteEditWindow : Window
    {
        int routeId;
        public RouteEditWindow(int id)
        {
            InitializeComponent();
            routeId = id;
            RouteNameBox.Text = Functions.GetRouteName(routeId);
            if (profile.Permission != 0)
            {
                RouteNameBox.IsEnabled = false;
                AddButton.Visibility = Visibility.Collapsed;
                RemoveButton.Visibility = Visibility.Collapsed;
                AddButtonDrivers.Visibility = Visibility.Collapsed;
                CreateButtonDrivers.Visibility = Visibility.Collapsed;
                RemoveDriver.Visibility = Visibility.Collapsed;
            }
            Update();
        }
        private void PointsDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (profile.Permission == 0)
            {
                PointEditWindow pew = new PointEditWindow(((PointsList)PointsListDataGrid.SelectedItem).IdPoint);
                pew.ShowDialog();
            }
        }
        private void DriversDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (profile.Permission == 0)
            {
                DriverEditWindow dew = new DriverEditWindow(((DriversList)DriversListDataGrid.SelectedItem).IdDriver);
                dew.ShowDialog();
            }
        }
        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            AddDriverWindow adw = new AddDriverWindow(routeId);
            adw.ShowDialog();
        }
        private void RemovePoint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cnt.db.PointsList.Remove(cnt.db.PointsList.Where(item => item.IdRoute == routeId && item.IdPoint == ((PointsList)PointsListDataGrid.SelectedItem).IdPoint).FirstOrDefault());
                cnt.db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления записи.");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Routes route = cnt.db.Routes.Where(item => item.IdRoute == routeId).FirstOrDefault();
            route.Name = RouteNameBox.Text;
            cnt.db.SaveChanges();
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Routes route = cnt.db.Routes.Where(item => item.IdRoute == routeId).FirstOrDefault();
            route.Name = RouteNameBox.Text;
            cnt.db.SaveChanges();
        }

        private void AddFromListPoint_Click(object sender, RoutedEventArgs e)
        {
            AddPointToRouteWindow aptrw = new AddPointToRouteWindow(routeId);
            aptrw.ShowDialog();
            int pointId = aptrw.pointId;
            if (pointId != -1)
            {
                try
                {
                    PointsList newAddPointToRoute = new PointsList()
                    {
                        Id = cnt.db.PointsList.Select(p => p.Id).DefaultIfEmpty(0).Max() + 1,
                        IdPoint = pointId,
                        IdRoute = routeId
                    };
                    cnt.db.PointsList.Add(newAddPointToRoute);
                    cnt.db.SaveChanges();
                    Update();
                    MessageBox.Show("Точка успешно добавлена");
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления записи");
                }
            }
            Update();
        }

        private void AddFromListDriver_Click(object sender, RoutedEventArgs e)
        {
            AddDriverToRouteWindow adtrw = new AddDriverToRouteWindow(routeId);
            adtrw.ShowDialog();
            int driverId = adtrw.driverId;
            if (driverId != -1)
            {
                try
                {
                    DriversList newAddDriverToRoute = new DriversList()
                    {
                        Id = cnt.db.DriversList.Select(p => p.Id).DefaultIfEmpty(0).Max() + 1,
                        IdDriver = driverId,
                        IdRoute = routeId
                    };
                    cnt.db.DriversList.Add(newAddDriverToRoute);
                    cnt.db.SaveChanges();
                    Update();
                    MessageBox.Show("Водитель успешно добавлен");
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления записи");
                }
            }
            Update();
        }

        void Update()
        {
            PointsListDataGrid.ItemsSource = cnt.db.PointsList.Where(item => item.IdRoute == routeId).ToList();
            DriversListDataGrid.ItemsSource = cnt.db.DriversList.Where(item => item.IdRoute == routeId).ToList();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void RemoveDriver_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cnt.db.DriversList.Remove(cnt.db.DriversList.Where(item => item.IdRoute == routeId && item.IdDriver == ((DriversList)DriversListDataGrid.SelectedItem).IdDriver).FirstOrDefault());
                cnt.db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления записи.");
            }
        }
    }
}
