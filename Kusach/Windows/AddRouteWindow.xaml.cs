using System.Linq;
using System.Windows;

namespace Kusach
{
    /// <summary>
    /// Логика взаимодействия для AddRouteWindow.xaml
    /// </summary>
    public partial class AddRouteWindow : Window
    {
        public AddRouteWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            RouteNameBox.Focus();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (RouteNameBox.Text == "")
                MessageBox.Show("Поля не могут быть пустыми.");
            else
            {
                try
                {
                    int newRouteId = cnt.db.Routes.Select(p => p.IdRoute).DefaultIfEmpty(0).Max() + 1;
                    Routes newRoute = new Routes()
                    {
                        IdRoute = newRouteId,
                        Name = RouteNameBox.Text
                    };
                    cnt.db.Routes.Add(newRoute);
                    cnt.db.SaveChanges();

                    RouteList newRouteList = new RouteList()
                    {
                        Id = cnt.db.RouteList.Select(p => p.Id).DefaultIfEmpty(0).Max() + 1,
                        IdRoute = newRouteId,
                        IdDispatcher = profile.DispatcherId
                    };
                    cnt.db.RouteList.Add(newRouteList);
                    cnt.db.SaveChanges();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка создания маршрута.");
                    this.Close();
                }
            }
        }
    }
}
