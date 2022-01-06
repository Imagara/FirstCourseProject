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
        public AddPointWindow()
        {
            InitializeComponent();
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
                Points newPoint = new Points()
                {
                    IdPoint = cnt.db.Points.Count() + 1,
                    Name = NameBox.Text,
                    location = LocationBox.Text
                };
                cnt.db.Points.Add(newPoint);
                cnt.db.SaveChanges();
                MessageBox.Show("Точка остановки успешно создана.");
                this.Close();
            }
        }
    }
}
