using System.Linq;
using System.Windows;

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
                try
                {
                    Transport newTransport = new Transport()
                    {
                        IdTransport = cnt.db.Transport.Select(p => p.IdTransport).DefaultIfEmpty(0).Max() + 1,
                        NameOfTransport = NameOfTransportBox.Text,
                        NumberPlate = NumberPlateBox.Text
                    };
                    cnt.db.Transport.Add(newTransport);
                    cnt.db.SaveChanges();
                    MessageBox.Show("Транспортное средство успешно создано.");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка создания транспортного средства.");
                    this.Close();
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
