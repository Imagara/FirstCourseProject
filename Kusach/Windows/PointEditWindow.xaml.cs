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
    /// Логика взаимодействия для PointEditWindow.xaml
    /// </summary>
    public partial class PointEditWindow : Window
    {
        int pointId;
        public PointEditWindow(int id)
        {
            InitializeComponent();
            pointId = id;
            NameBox.Text = cnt.db.Points.Where(item => item.IdPoint == pointId).Select(item => item.Name).FirstOrDefault();
            LocationBox.Text = cnt.db.Points.Where(item => item.IdPoint == pointId).Select(item => item.location).FirstOrDefault();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SavePointButton_Click(object sender, RoutedEventArgs e)
        {
            Points point = cnt.db.Points.Where(item => item.IdPoint == pointId).FirstOrDefault();
            point.Name = NameBox.Text;
            point.location = LocationBox.Text;
            cnt.db.SaveChanges();
            this.Close();
        }
    }
}
