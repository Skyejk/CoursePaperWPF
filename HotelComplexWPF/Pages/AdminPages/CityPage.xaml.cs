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

namespace HotelComplexWPF.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для CityPage.xaml
    /// </summary>
    public partial class CityPage : Page
    {
        public CityPage()
        {
            InitializeComponent();
            DGridCity.ItemsSource = HotelEntities.GetContext().City.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
