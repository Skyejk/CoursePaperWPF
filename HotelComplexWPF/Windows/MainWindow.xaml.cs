﻿using HotelComplexWPF.Pages;
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

namespace HotelComplexWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new AuthPage());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.GoBack();
        }

        private void mainFrame_ContentRendered(object sender, EventArgs e)//Сокрытие кнопки возвращения на главном экране.
        {
            if (mainFrame.CanGoBack)
                btnCancel.Visibility = Visibility.Visible;
            else
                btnCancel.Visibility = Visibility.Hidden;
        }
    }
}