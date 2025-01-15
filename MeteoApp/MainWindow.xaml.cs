using MeteoApp;
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
        private UserStorage userStorage { get; } = new UserStorage();

        public MainWindow()
        {
            InitializeComponent();
            SignOut_Button.Click += SignOut_Button_Click;
            SignIn_Button.Click += SignIn_Button_Click;
            Register_Button.Click += Register_Button_Click;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var signInUser = userStorage.GetSignInUser();
            if (signInUser != null)
            {
                Authorized(signInUser);
            }
            else
            {
                UnAuthorized();
            }
        }

        private void UnAuthorized()
        {
            LoginName_Label.Visibility = Visibility.Hidden;
            PersonalDesk_Login.Visibility = Visibility.Hidden;
            SignOut_Button.Visibility = Visibility.Hidden;
            SignIn_Button.Visibility = Visibility.Visible;
            Register_Button.Visibility = Visibility.Visible;
        }

        private void Authorized(User signInUser)
        {
            LoginName_Label.Content = signInUser.Login;
            LoginName_Label.Visibility = Visibility.Visible;
            PersonalDesk_Login.Visibility = Visibility.Visible;
            SignOut_Button.Visibility = Visibility.Visible;
            SignIn_Button.Visibility = Visibility.Hidden;
            Register_Button.Visibility = Visibility.Hidden;
        }

        private void SignOut_Button_Click(object sender, RoutedEventArgs e)
        {
            userStorage.SignOut();
            UnAuthorized();
        }

        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegistrationWindow();
            registerWindow.ShowDialog();
            CheckUser();
        }

        private void CheckUser()
        {
            var user = userStorage.GetSignInUser();
            if (user != null)
            {
                Authorized(user);
            }
            else
            {
                UnAuthorized();
            }
        }
    }
}