using System.Linq;
using System.Windows;

namespace Kusach
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (logbox.Text == "" || passbox.Text== "")
                MessageBox.Show("Поля не могут быть пустыми.");
            else if (cnt.db.Dispatcher.Select(item => item.Login).Contains(logbox.Text))
                MessageBox.Show("Данный логин уже занят");
            else
            {
                Dispatcher newUser = new Dispatcher()
                {
                    IdDispatcher = cnt.db.Dispatcher.Count()+1,
                    Login = logbox.Text,
                    Password = Encrypt.GetHash(passbox.Text)
                };
                cnt.db.Dispatcher.Add(newUser);
                cnt.db.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрировались");
                DataWindow dw = new DataWindow();
                dw.Show();
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            LogWindow lw = new LogWindow();
            lw.Show();
            this.Close();
        }
    }
}
