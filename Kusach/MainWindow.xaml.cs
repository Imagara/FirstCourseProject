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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            LogWindow lw = new LogWindow();
            lw.Show();
            this.Close();
        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.RoutesListPage();
        }
        #region LeftPanelButtons
        private void RoutesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.RoutesListPage();
        }

        private void DriversButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pages.DriversListPage();
        }
        private void VehButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new TestPGPage();
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new TestPGPage();
        }
        #endregion

    }
}
