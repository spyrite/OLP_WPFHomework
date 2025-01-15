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
using System.Windows.Shapes;

namespace MeteoApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private UserStorage userStorage { get; } = new UserStorage();

        public RegistrationWindow()
        {
            InitializeComponent();
            Registration_Button.Click += Register_Button_Click;
            
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            var inputLogin = RegLogin_TextBox.Text;
            var inputPassword = RegPassword_TextBox.Text;
            var confirmPassword = RegConfirm_TextBox.Text;

            if (inputPassword != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают! Проверьте данные ввода.");
                return;
            }

            var registeredUser = new User(inputLogin, inputPassword);
            registeredUser.IsSignIn = true;

            userStorage.Add(registeredUser);

            MessageBox.Show("Аккаунт успешно зарегистрирован!");
            Close();
        }
    }
}
