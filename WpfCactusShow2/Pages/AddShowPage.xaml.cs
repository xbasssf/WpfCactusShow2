using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddShowPage.xaml
    /// </summary>
    public partial class AddShowPage : Page
    {
        public AddShowPage()
        {
            InitializeComponent();
            cmbLoc.ItemsSource = ConnectionDB.DB.Location.ToList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); 
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            ConnectionDB.DB.Show.Add(new Show
            {
                Date = DateTime.Parse(dateTime.Text),
                Name = txtName.Text,
                Id_loc = ((Location)cmbLoc.SelectedItem).Id_loc,
            });
            ConnectionDB.DB.SaveChanges();
            NavigationService.Navigate(new ShowPage());
        }

        private void cmbLoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = cmbLoc.SelectedItem as Location;
            var loc = (from location in ConnectionDB.DB.Location
                          where location.Id_loc == p.Id_loc
                          select location).FirstOrDefault();
            cmbLoc.SelectedItem = loc;
        }

        private void TxtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[а-яА-Яa-zA-Z]+$");
        }

    }
}
