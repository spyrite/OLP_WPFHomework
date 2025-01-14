﻿using MeteoApp;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            register_Button.Click += Register_Button_Click;
            signIn_Button.Click += SignIn_Button_Click;
        }

        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegistrationWindow();
            registerWindow.ShowDialog();
        }
    }
}