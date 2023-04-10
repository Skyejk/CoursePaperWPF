using HotelComplexWPF.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page {

        short countUnsuccessfully = 0;//количество неудачных попыток входа
        public AuthPage() {
            InitializeComponent();
            tblCaptcha.Visibility = Visibility.Hidden;
            tbxCaptcha.Visibility = Visibility.Hidden;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e) {
            string login = tbxUserName.Text.ToString();
            string password = tbxUserPassword.Password.ToString();

            User user = new User();
            user = HotelEntities.GetContext().User.Where(predicate => predicate.UserName == login && predicate.UserPassword == password).FirstOrDefault();
            int userCount = HotelEntities.GetContext().User.Where(predicate => predicate.UserName == login && predicate.UserPassword == password).Count();

            //подключение к базе данных
            try {
                if (tbxUserName.Text == "" || tbxUserPassword.Password == "")
                    СheckingForDataAvailability();
                else {
                    MarkValid();
                    if (countUnsuccessfully < 1) {
                        if (userCount > 0) {
                            Successfully(user.Employee.EmployeePosition.Post.ToString());
                            //вход
                            LoadF(user.Employee.EmployeePosition.Post.ToString(), user);
                        }
                        else {
                            NotF("Проверьте введённые данные");
                            countUnsuccessfully++;
                            GenerateCaptcha();
                        }
                    }
                    else {
                        if(tbxCaptcha.Text == tblCaptcha.Text) {
                            if (userCount > 0)
                            {
                                Successfully(user.Employee.EmployeePosition.Post.ToString());
                                //вход
                                LoadF(user.Employee.EmployeePosition.Post.ToString(), user);
                            }else{
                                NotF("Пользователя с таким паролем не существует.");
                            }
                        }
                        else {
                            NotF("Введите Captcha.");
                            GenerateCaptcha();
                        }
                    }
                }
            }
            catch (Exception ex) {
                NotF(ex.Message);
            }
        }

        void Successfully(string RoleName){
            MessageBox.Show($"Вы успешно вошли под:{RoleName}", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.None, MessageBoxOptions.None);
        }

        void GenerateCaptcha() {
            tblCaptcha.Visibility = Visibility.Visible;
            tbxCaptcha.Visibility = Visibility.Visible;

            Random random = new Random();

            double randNum = random.Next(10000000, 99999999);
            string captcha = randNum.ToString();

            tblCaptcha.Text = captcha;
            tblCaptcha.TextDecorations = TextDecorations.Strikethrough;
        }
        void MarkValid() {
            var bc = new BrushConverter();

            tbxUserPassword.Background = (Brush)bc.ConvertFrom("#293238");
            tbxUserPassword.ToolTip = null;
            tbxUserName.Background = (Brush)bc.ConvertFrom("#293238");
            tbxUserName.ToolTip = null;
        }
        void MarkInvalid(Control control, string txt) {
            control.ToolTip = txt;
            control.Background = Brushes.Red;
        }
        void СheckingForDataAvailability() {
            if (tbxUserName.Text == "")
                MarkInvalid(tbxUserName, "Введите логин.");
            if (tbxUserPassword.Password == "")
                MarkInvalid(tbxUserPassword, "Введите пароль.");
        }
        void NotF(string text) {
            MessageBox.Show(text, null, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.None);
        }

        void LoadF(string _role, User user)
        {
            switch (_role)
            {
                case "Administrator":
                    NavigationService.Navigate(new AdminPage(user));
                    break;
                case "Registrar":
                    NavigationService.Navigate(new RegistrarPage(user));
                    break;
                default:
                    MessageBox.Show("Данный раздел находится в разработке. Ожидайте следующих версий.");
                    break;
            }
            tbxUserName.Text = "";
            tbxUserPassword.Password = "";
            tbxCaptcha.Text = "";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
