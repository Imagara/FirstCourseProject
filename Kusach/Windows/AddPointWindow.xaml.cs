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
    /// Логика взаимодействия для AddPointWindow.xaml
    /// </summary>
    public partial class AddPointWindow : Window
    {
        int RouteId;
        public AddPointWindow(int id = -1)
        {
            InitializeComponent();
            RouteId = id;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddPointButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == "" || LocationBox.Text == "")
                MessageBox.Show("Поля не могут быть пустыми.");
            else
            {
                try
                {
                    Points newPoint = new Points()
                    {
                        IdPoint = cnt.db.Points.Count() + 1,
                        Name = NameBox.Text,
                        location = LocationBox.Text
                    };
                    cnt.db.Points.Add(newPoint);
                    cnt.db.SaveChanges();
                    if (RouteId != -1)
                    {
                        PointsList newPointRoute = new PointsList()
                        {
                            Id = cnt.db.PointsList.Count() + 1,
                            IdPoint = cnt.db.Points.Count(),
                            IdRoute = RouteId
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
