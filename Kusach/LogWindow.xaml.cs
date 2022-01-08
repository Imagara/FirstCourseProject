using System;
using System.Linq;
using System.Windows;

namespace Kusach
{
    /// <summary>
    /// Логика взаимодействия для LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public LogWindow()
        {
            InitializeComponent();
        }
        public void OnLoad(object sender, RoutedEventArgs e)
        {
            logbox.Focus();
        }
        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (logbox.Text == "" || passbox.Password == "")
                    MessageBox.Show("Поля не могут быть пустыми.");
                else if (cnt.db.Dispatcher.Select(item => item.Login + item.Password).Contains(logbox.Text + Encrypt.GetHash(passbox.Password)))
                {
                    DataWindow dw = new DataWindow();
                    dw.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Неверный логин или пароль");
            } catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка. : {ex}");
            }
            
        }
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            RegWindow rw = new RegWindow();
            rw.Show();
            this.Close();
        }
    }
}
