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
    /// Логика взаимодействия для TransportEditWindow.xaml
    /// </summary>
    public partial class TransportEditWindow : Window
    {
        int transportId;
        public TransportEditWindow(int id)
        {
            InitializeComponent();
            transportId = id;
            NameOfTransportBox.Text = cnt.db.Transport.Where(item => item.IdTransport == transportId).Select(item => item.NameOfTransport).FirstOrDefault();
            NumberPlateBox.Text = cnt.db.Transport.Where(item => item.IdTransport == transportId).Select(item => item.NumberPlate).FirstOrDefault();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveTransportButton_Click(object sender, RoutedEventArgs e)
        {
            Transport transport = cnt.db.Transport.Where(item => item.IdTransport == transportId).FirstOrDefault();
            transport.NameOfTransport = NameOfTransportBox.Text;
            transport.NumberPlate = NumberPlateBox.Text;
            cnt.db.SaveChanges();
            this.Close();
        }
    }
}
