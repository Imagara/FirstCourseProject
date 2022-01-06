using System.Linq;
using System.Windows;


namespace Kusach
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (logbox.Text == "" || passbox.Text == "")
                MessageBox.Show("Поля не могут быть пустыми.");
            else if (cnt.db.Dispatcher.Select(item => item.Login).Contains(logbox.Text))
                MessageBox.Show("Данный логин уже занят");
            else
            {
                Dispatcher newUser = new Dispatcher()
                {
                    IdDispatcher = cnt.db.Dispatcher.Count() + 1,
                    Login = logbox.Text,
                    Password = passbox.Text
                };
                cnt.db.Dispatcher.Add(newUser);
                cnt.db.SaveChanges();
                MessageBox.Show("Пользователь успешно создан.");
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
