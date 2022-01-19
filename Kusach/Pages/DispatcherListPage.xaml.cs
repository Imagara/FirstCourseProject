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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kusach.Pages
{
    /// <summary>
    /// Логика взаимодействия для DispatcherListPage.xaml
    /// </summary>
    public partial class DispatcherListPage : Page
    {
        public DispatcherListPage()
        {
            InitializeComponent();
            DispatcherList.ItemsSource = cnt.db.Dispatcher.ToList();
            if (profile.Permission != 0)
                CreateButton.Visibility = Visibility.Collapsed;
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        #region Поиск
        private void SearchBoxPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SearchBox.Text == "Поиск...")
                SearchBox.Text = "";
        }
        private void SearchLostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "")
                SearchBox.Text = "Поиск...";
        }
        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text != "" && SearchBox.Text != "Поиск...")
                DispatcherList.ItemsSource = cnt.db.Dispatcher.Where(item => (item.IdDispatcher + " " + item.Login + " " + item.Surname + " " + item.Name + " " + item.Patronymic + " " + item.Birthday + " " + item.PhoneNumber).Contains(SearchBox.Text)).ToList();
            else
                cnt.db.Dispatcher.ToList();
        }
        #endregion
        private void AddDispatcherButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void UpdateDispatcherButton_Click(object sender, RoutedEventArgs e)
        {
            DispatcherList.ItemsSource = cnt.db.Dispatcher.ToList();
        }
    }
}
