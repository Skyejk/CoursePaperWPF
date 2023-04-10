using HotelComplexWPF.Entities;
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

namespace HotelComplexWPF.Pages.RegistrarPages
{
    /// <summary>
    /// Логика взаимодействия для AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Page
    {
        private ReservationHotelRoom currentRoom = new ReservationHotelRoom();
        public AddReservation(ReservationHotelRoom selectedRoom)
        {
            InitializeComponent();

            if (selectedRoom != null )
                currentRoom = selectedRoom;

            DataContext = currentRoom;
            cmbxHotelRoom.ItemsSource = HotelEntities.GetContext().ReservationHotelRoom.ToList();
            cmbxClient.ItemsSource = HotelEntities.GetContext().Human.ToList();

        //    cmbxClient.ItemsSource = new Person[]
        //{
        //    new Person { Name = "Tom", Company = "Microsoft" },
        //    new Person { Name = "Bob", Company = "Google" },
        //    new Person { Name = "Sam", Company = "JetBrains" }
        //};
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentRoom.ID == 0)
                HotelEntities.GetContext().ReservationHotelRoom.Add(currentRoom);

            MessageBox.Show("В разработке");

            //try
            //{
            //    HotelEntities.GetContext().SaveChanges();
            //    MessageBox.Show("Информация сохранена!");
            //    NavigationService.GoBack();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
            //NavigationService.Navigate(new AddClient());
        }
    }
}
//public class Person
//{
//    public string Name { get; set; } = "";
//    public string Company { get; set; } = "";
//    public override string ToString() => $"{Name} ({Company})";
//}