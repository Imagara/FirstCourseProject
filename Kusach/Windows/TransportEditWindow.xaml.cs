using System.Linq;
using System.Windows;

namespace Kusach.Windows
{
    public partial class TransportEditWindow : Window
    {
        Transport transport;
        public TransportEditWindow(int id)
        {
            InitializeComponent();
            transport = cnt.db.Transport.Where(item => item.IdTransport == id).FirstOrDefault();
            NameOfTransportBox.Text = transport.NameOfTransport;
            NumberPlateBox.Text = transport.NumberPlate;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveTransportButton_Click(object sender, RoutedEventArgs e)
        {
            transport.NameOfTransport = NameOfTransportBox.Text;
            transport.NumberPlate = NumberPlateBox.Text;
            cnt.db.SaveChanges();
            this.Close();
        }
    }
}
