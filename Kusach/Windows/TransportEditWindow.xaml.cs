using System.Linq;
using System.Windows;

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
            NameOfTransportBox.Text = Functions.GetNameOfTransport(transportId);
            NumberPlateBox.Text = Functions.GetNumberPlate(transportId);
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
