using System.Linq;
using System.Windows;

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
            NameBox.Text = Functions.GetNameOfPoint(pointId);
            LocationBox.Text = Functions.GetLocationOfPoint(pointId);
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
