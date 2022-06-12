using System.Linq;
using System.Windows;

namespace Kusach.Windows
{
    public partial class PointEditWindow : Window
    {
        Points point;
        public PointEditWindow(int id)
        {
            InitializeComponent();
            point = cnt.db.Points.Where(item => item.IdPoint == id).FirstOrDefault();
            NameBox.Text = point.Name;
            LocationBox.Text = point.location;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SavePointButton_Click(object sender, RoutedEventArgs e)
        {
            point.Name = NameBox.Text;
            point.location = LocationBox.Text;
            cnt.db.SaveChanges();
            this.Close();
        }
    }
}
