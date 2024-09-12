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
using WpfCactusShow2.DB;

namespace WpfCactusShow2.Pages
{
    /// <summary>
    /// Логика взаимодействия для CactusPage.xaml
    /// </summary>
    public partial class CactusPage : Page
    {
        int _id = 0;
        public CactusPage(int id)
        {
            InitializeComponent();
            _id = id;
            ListCactus.ItemsSource = ConnectionDB.DB.Show_cactus.Where(cactus => cactus.Id_show == _id).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                var b = ListCactus.SelectedItem as Show;
                if (b != null)
                {
                    ConnectionDB.DB.Show.Remove(b);
                    ConnectionDB.DB.SaveChanges();
                    ListCactus.ItemsSource = ConnectionDB.DB.Show.ToList();
                    MessageBox.Show($"Выставка номер {b.Id_show} удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Для начала выберите запись!!!");
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCactusPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
