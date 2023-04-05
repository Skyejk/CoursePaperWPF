using HotelComplexWPF.Entities;
using HotelComplexWPF.Pages.AdminPages;
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

namespace HotelComplexWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        User user = new User();
        public AdminPage(User currentUser)
        {
            InitializeComponent();

            string fullNameThisPerson = 
                $"{currentUser.Employee.DetailedInformationAboutThePerson.Human.Surname} " + 
                $"{currentUser.Employee.DetailedInformationAboutThePerson.Human.Firstname} " +
                $"{currentUser.Employee.DetailedInformationAboutThePerson.Patronymic}";

            tblFIO.Text = fullNameThisPerson;
        }
        private void btnAddCountry_Click(object sender, RoutedEventArgs e)
        {
            frmFocus.NavigationService.Navigate(new CountryPage());
        }

        private void btnAddRegion_Click(object sender, RoutedEventArgs e)
        {
            frmFocus.NavigationService.Navigate(new RegionPage());
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            frmFocus.NavigationService.Navigate(new CityPage());
        }

        private void btnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            frmFocus.NavigationService.Navigate(new HotelPage());
        }

        private void btnAddHotelRoom_Click(object sender, RoutedEventArgs e)
        {
            frmFocus.NavigationService.Navigate(new HRoomPage());
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            frmFocus.NavigationService.Navigate(new EmployeePage());
        }
    }
}
