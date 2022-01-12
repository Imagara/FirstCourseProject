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
    /// Логика взаимодействия для AddDriverWindow.xaml
    /// </summary>
    public partial class AddDriverWindow : Window
    {
        public AddDriverWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddDriverButton_Click(object sender, RoutedEventArgs e)
        {
            if (IdTransportBox.Text == "" || NameBox.Text == "" || SurnameBox.Text == "" || PatronymicBox.Text == "")
                MessageBox.Show("Поля не могут быть пустыми.");
            else
            {
                Drivers newDriver = new Drivers()
                {
                    IdDriver = cnt.db.Drivers.Select(p => p.IdDriver).DefaultIfEmpty(0).Max() + 1,
                    IdTransport = Convert.ToInt32(IdTransportBox.Text),
                    Name = NameBox.Text,
                    Surname = SurnameBox.Text,
                    Patronymic = PatronymicBox.Text
                };
                cnt.db.Drivers.Add(newDriver);
                cnt.db.SaveChanges();
                MessageBox.Show("Водитель успешно создан.");
                this.Close();
            }
        }
    }
}
