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

    public enum TextBlockStatus
    {
        NewInput,
        Continue,
    }

    public partial class MainWindow : Window
    {
        public readonly List<char> _operators = ['+', '-', '*', '/'];

        private string _textblockStr = "0";
        private TextBlockStatus _textBlockStatus;

        public MainWindow()
        {
            InitializeComponent();
            button_N0.Click += Button_N0_Click;
            button_N1.Click += Button_Operation_Click;
            button_N2.Click += Button_Operation_Click;
            button_N3.Click += Button_Operation_Click;
            button_N4.Click += Button_Operation_Click;
            button_N5.Click += Button_Operation_Click;
            button_N6.Click += Button_Operation_Click;
            button_N7.Click += Button_Operation_Click;
            button_N8.Click += Button_Operation_Click;
            button_N9.Click += Button_Operation_Click;
            button_Add.Click += Button_Operation_Click;
            button_Sub.Click += Button_Operation_Click;
            button_Mul.Click += Button_Operation_Click;
            button_Div.Click += Button_Operation_Click;
            button_Result.Click += Button_Result_Click;
            button_Clear.Click += Button_Clear_Click;
            KeyDown += MainWindow_KeyDown;

            Button_Clear_Click(button_Clear, new());
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0: Button_N0_Click(button_N0, new()); break;
                case Key.NumPad1: Button_Operation_Click(button_N1, new()); break;
                case Key.NumPad2: Button_Operation_Click(button_N2, new()); break;
                case Key.NumPad3: Button_Operation_Click(button_N3, new()); break;
                case Key.NumPad4: Button_Operation_Click(button_N4, new()); break;
                case Key.NumPad5: Button_Operation_Click(button_N5, new()); break;
                case Key.NumPad6: Button_Operation_Click(button_N6, new()); break;
                case Key.NumPad7: Button_Operation_Click(button_N7, new()); break;
                case Key.NumPad8: Button_Operation_Click(button_N8, new()); break;
                case Key.NumPad9: Button_Operation_Click(button_N9, new()); break;
                case Key.Add: Button_Operation_Click(button_Add, new()); break;
                case Key.Subtract: Button_Operation_Click(button_Sub, new()); break;
                case Key.Multiply: Button_Operation_Click(button_Mul, new()); break;
                case Key.Divide: Button_Operation_Click(button_Div, new()); break;
                case Key.Enter: Button_Result_Click(button_Result, new()); break;
                case Key.Back: Button_Clear_Click(button_Clear, new()); break;
                case Key.Escape: Button_Clear_Click(button_Clear, new()); break;
            }
        }

        private void Button_Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string input = button.Content.ToString();
            if (_operators.Contains(_textblockStr.Last()) & _operators.Contains(input.Last()))
                _textBlockStatus = TextBlockStatus.Continue;

            else if (_textBlockStatus == TextBlockStatus.NewInput & _operators.Contains(input.Last()))
            {
                _textblockStr += input;
                _textBlockStatus = TextBlockStatus.Continue;
            }              
                     
            else
            {
                if ((_textblockStr == "0" & !_operators.Contains(input.Last())) || _textBlockStatus == TextBlockStatus.NewInput)
                    _textblockStr = input;
                else
                    _textblockStr += input;
                _textBlockStatus = TextBlockStatus.Continue;
            }
            textblock_Result.Text = _textblockStr;
        }

        private void Button_N0_Click(object sender, RoutedEventArgs e)
        {
            switch (_textBlockStatus)
            {
                case TextBlockStatus.NewInput: Button_Clear_Click(button_Clear, new()); break;
                case TextBlockStatus.Continue: break;
            }

            if (_textblockStr != "0")
            {
                _textblockStr += "0";
                textblock_Result.Text = _textblockStr;
                _textBlockStatus = TextBlockStatus.Continue;
            }
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            _textblockStr = "0";
            textblock_Result.Text = _textblockStr;
            _textBlockStatus = TextBlockStatus.Continue;
        }

        private void Button_Result_Click(object sender, RoutedEventArgs e)
        {
            textblock_Result.Text = Convert.ToDouble(new DataTable().Compute(_textblockStr.Replace(',', '.'), "")).ToString();
            _textblockStr = textblock_Result.Text;
            _textBlockStatus = TextBlockStatus.NewInput;
        }



    }
}