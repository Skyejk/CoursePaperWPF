using HotelComplexWPF.Entities;
using HotelComplexWPF.Pages.RegistrarPages;
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
    /// Логика взаимодействия для RegistrarPage.xaml
    /// </summary>
    public partial class RegistrarPage : Page
    {
        public RegistrarPage(User currentUser)
        {
            InitializeComponent();

            string fullNameThisPerson =
                $"{currentUser.Employee.DetailedInformationAboutThePerson.Human.Surname} " +
                $"{currentUser.Employee.DetailedInformationAboutThePerson.Human.Firstname} " +
                $"{currentUser.Employee.DetailedInformationAboutThePerson.Patronymic}";

            tblFIO.Text = fullNameThisPerson;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HotelEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridReservationHRoom.ItemsSource = HotelEntities.GetContext().ReservationHotelRoom.ToList();
            }
        }

        private void btnAddReservation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddReservation(null));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddReservation((sender as Button).DataContext as ReservationHotelRoom));
        }
    }
}
