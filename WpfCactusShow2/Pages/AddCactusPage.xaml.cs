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
using System.Xml.Linq;
using WpfCactusShow2.DB;

namespace WpfCactusShow2.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddCactusPage.xaml
    /// </summary>
    public partial class AddCactusPage : Page
    {
        public AddCactusPage()
        {
            InitializeComponent();
            cmbkind.ItemsSource = ConnectionDB.DB.Kind.ToList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            ConnectionDB.DB.Cactus.Add(new Cactus
            { Origin = txtOrigin.Text,
                Age = Convert.ToInt32(txtAge.Text),
                Price = Convert.ToInt32(txtPrice.Text),
                Id_kind = ((Kind)cmbkind.SelectedItem).Id_kind,
            }) ;
            ConnectionDB.DB.SaveChanges();
            NavigationService.Navigate(new ShowPage());
        }

        private void TxtOrigin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[а-яА-Яa-zA-Z]+$");
        }

        private void TxtAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9]+$");
        }

        private void TxtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9]+$");
        }

   
    }
}
