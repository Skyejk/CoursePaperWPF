﻿using System;
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
            string password = tbxUserPassword.Text.ToString();

            //User user = new User();
            //user = Entities.GetContext().User.Where(predicate => predicate.UserLogin == login && predicate.UserPassword == password).FirstOrDefault();
            //int userCount = Entities.GetContext().User.Where(predicate => predicate.UserLogin == login && predicate.UserPassword == password).Count();

            //подключение к базе данных
            /*
            try {
                if (tbxUserName.Text == "" || tbxUserPassword.Text == "")
                    СheckingForDataAvailability();
                else {
                    MarkValid();
                    if (countUnsuccessfully < 1) {
                        if (userCount > 0) {
                            Successfully(user.Role.RoleName.ToString());
                            //выполнить вход
                        }
                        else {
                            NotF("Проверьте введённые данные");
                            countUnsuccessfully++;
                            GenerateCaptcha();
                        }
                    }
                    else {

                        if (userCount > 0 && tblCaptcha.Text == tbxCaptcha.Text) {
                            Successfully(user.Role.RoleName.ToString());
                            //выполнить вход
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
            */
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
            tbxUserPassword.Background = default;
            tbxUserPassword.ToolTip = null;
            tbxUserName.Background = default;
            tbxUserName.ToolTip = null;
        }
        void MarkInvalid(Control control, string txt) {
            control.ToolTip = txt;
            control.Background = Brushes.Red;
        }
        void СheckingForDataAvailability() {
            if (tbxUserName.Text == "")
                MarkInvalid(tbxUserName, "Введите логин.");
            else if (tbxUserPassword.Text == "")
                MarkInvalid(tbxUserPassword, "Введите пароль.");
        }
        void NotF(string text) {
            MessageBox.Show(text, null, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.None);
        }
    }
}