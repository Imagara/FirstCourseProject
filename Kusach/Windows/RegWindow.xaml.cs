﻿using System;
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
            try
            {
                if (logbox.Text == "" || passbox.Text == "")
                    MessageBox.Show("Поля не могут быть пустыми.");
                else if (Functions.IsLoginAlreadyTaken(logbox.Text))
                    MessageBox.Show("Данный логин уже занят");
                else if (!Functions.IsValidPhoneNumber(PhoneBox.Text))
                    MessageBox.Show("Номер телефона введен неверно.");
                else if (!Functions.IsValidEmail(EmailBox.Text))
                    MessageBox.Show("Email введен неверно."); 
                else if (!Functions.IsValidDateOfBirthday(BirthdayBox.Text))
                    MessageBox.Show("День рождения введен неверно.");
                else
                {
                    Dispatcher newUser = new Dispatcher()
                    {
                        IdDispatcher = cnt.db.Dispatcher.Select(p => p.IdDispatcher).DefaultIfEmpty(0).Max() + 1,
                        Login = logbox.Text,
                        Password = Encrypt.GetHash(passbox.Text),
                        Surname = FNameBox.Text,
                        Name = LNameBox.Text,
                        Patronymic = MNameBox.Text,
                        Birthday = Convert.ToDateTime(BirthdayBox.Text),
                        PhoneNumber = PhoneBox.Text,
                        Email = EmailBox.Text,
                    };
                    if (cnt.db.Dispatcher.Count() == 0)
                        newUser.Permission = 0;
                    else
                        newUser.Permission = 1;
                    cnt.db.Dispatcher.Add(newUser);
                    cnt.db.SaveChanges();
                    profile.DispatcherId = cnt.db.Dispatcher.First(item => item.Login == logbox.Text).IdDispatcher;
                    profile.Permission = cnt.db.Dispatcher.First(item => item.Login == logbox.Text).Permission;
                    MessageBox.Show("Вы успешно зарегистрировались");
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show($"Произошла ошибка.");
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
