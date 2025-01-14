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
        public RegistrationWindow()
        {
            InitializeComponent();
            register_Button.Click += Register_Button_Click;
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            var login = login_TextBox.Text;
            var password = password_TextBox.Text;
            var confirmPassword = confirmPassword_TextBox.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            var user = new User(login, password);
            UsersStorage.Add(user);

            MessageBox.Show("Вы успешно зарегистрировались :)");
            Close();
        }
    }
}
