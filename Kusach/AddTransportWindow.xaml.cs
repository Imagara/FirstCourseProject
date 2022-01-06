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
    /// Логика взаимодействия для AddTransportWindow.xaml
    /// </summary>
    public partial class AddTransportWindow : Window
    {
        public AddTransportWindow()
        {
            InitializeComponent();
        }

        private void AddTransportButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameOfTransportBox.Text == "" || NumberPlateBox.Text == "")
                MessageBox.Show("Поля не могут быть пустыми.");
            else
            {
                Transport newTransport = new Transport()
                {
                    IdTransport = cnt.db.Transport.Count() + 1,
                    NameOfTransport = NameOfTransportBox.Text,
                    NumberPlate = NumberPlateBox.Text
                };
                cnt.db.Transport.Add(newTransport);
                cnt.db.SaveChanges();
                MessageBox.Show("Транспортное средство успешно создано.");
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
