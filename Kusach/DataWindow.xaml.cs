using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Diagnostics;

namespace Kusach
{
    /// <summary>
    /// Логика взаимодействия для DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        public DataWindow()
        {
            InitializeComponent();
        }
        private void UserDateView(object sender, RoutedEventArgs e)
        {
            var query = from Dispatcher in cnt.db.Dispatcher
                        select new { Dispatcher.IdDispatcher, Dispatcher.Login, Dispatcher.Password };
            DataGrid.ItemsSource = query.ToList();
        }
        private void RoutesDateView(object sender, RoutedEventArgs e)
        {
            var query = from Routes in cnt.db.Routes
                        select new { Routes.IdRoute, Routes.Name };
            DataGrid.ItemsSource = query.ToList();
        }
        private void TransportDateView(object sender, RoutedEventArgs e)
        {
            var query = from Transport in cnt.db.Transport
                        select new { Transport.IdTransport, Transport.NameOfTransport, Transport.NumberPlate };
            DataGrid.ItemsSource = query.ToList();
        }
        private void PointDateView(object sender, RoutedEventArgs e)
        {
            var query = from Points in cnt.db.Points
                        select new { Points.IdPoint, Points.Name, Points.location };
            DataGrid.ItemsSource = query.ToList();
        }
        private void DriversDateView(object sender, RoutedEventArgs e)
        {
            var query = from Drivers in cnt.db.Drivers
                        select new { Drivers.IdDriver, Drivers.Transport, Drivers.Name, Drivers.Surname, Drivers.Patronymic };
            DataGrid.ItemsSource = query.ToList();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            LogWindow lw = new LogWindow();
            lw.Show();
            this.Close();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow auw = new AddUserWindow();
            auw.ShowDialog();
        }
        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show(TabContrl.SelectedItem());
        }

        private void FindRouteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddRouteButton_Click(object sender, RoutedEventArgs e)
        {
            AddRouteWindow arw = new AddRouteWindow();
            arw.ShowDialog();
        }

        private void AddTransportButton_Click(object sender, RoutedEventArgs e)
        {
            AddTransportWindow atw = new AddTransportWindow();
            atw.ShowDialog();
        }

        private void AddPointButton_Click(object sender, RoutedEventArgs e)
        {
            AddPointWindow apw = new AddPointWindow();
            apw.ShowDialog();
        }

        private void AddDriverButton_Click(object sender, RoutedEventArgs e)
        {
            AddDriverWindow adw = new AddDriverWindow();
            adw.ShowDialog();
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //var query = from Dispatcher in cnt.db.Dispatcher
            //            select new { Dispatcher.IdDispatcher, Dispatcher.Login, Dispatcher.Password };
            //DataGrid.ItemsSource = query.ToList().Where(item => item.Login == UserSearch.Text);
        }
    }
}