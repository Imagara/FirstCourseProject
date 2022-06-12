using System.Linq;
using System.Windows;

namespace Kusach
{
    public partial class AddPointWindow : Window
    {
        int routeId, pointId;
        public AddPointWindow(int id = -1)
        {
            InitializeComponent();
            routeId = id;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddPointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Functions.IsValidNameAndLocationOfPoint(NameBox.Text, LocationBox.Text))
                MessageBox.Show("Поля не могут быть пустыми.");
            else
            {
                try
                {
                    pointId = cnt.db.Points.Select(p => p.IdPoint).DefaultIfEmpty(0).Max() + 1;
                    Points newPoint = new Points()
                    {
                        IdPoint = pointId,
                        Name = NameBox.Text,
                        location = LocationBox.Text
                    };
                    cnt.db.Points.Add(newPoint);
                    cnt.db.SaveChanges();
                    if (routeId != -1)
                    {
                        PointsList newPointRoute = new PointsList()
                        {
                            Id = cnt.db.PointsList.Select(p => p.Id).DefaultIfEmpty(0).Max() + 1,
                            IdPoint = pointId,
                            IdRoute = routeId
                        };
                        cnt.db.PointsList.Add(newPointRoute);
                    }
                    cnt.db.SaveChanges();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка создания остановки.");
                    this.Close();
                }
            }
        }
    }
}
