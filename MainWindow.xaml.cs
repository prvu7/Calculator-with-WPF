using System.ComponentModel;
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

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        public CalculatorFunctionalities Functionalities { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Functionalities = new CalculatorFunctionalities();
            DataContext = Functionalities; 

            buttonDivide.Content = "\u00F7";
            buttonMultiple.Content = "\u00D7";
            buttonPlus.Content = "\u002B";
            buttonx2.Content = "x\u00B2";
            buttonRadical.Content = "\u221A";
            buttonDelete.Content = "\u232B";
            buttonNegate.Content = "\u00B1";
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string number = button.Content.ToString();
                Functionalities.AppendNumber(number);
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e) 
        {
            Button button = sender as Button;
            if (button != null)
            {
                string op = button.Content.ToString();
                Functionalities.SetOperator(op);
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.CalculateResult();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.Clear();
        }

        private void SquareButton_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.Square();
        }

        private void buttonReciprocal_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.Reciprocal();
        }

        private void buttonRadical_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.Radical();
        }

        private void buttonDot_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.AddDecimalPoint();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.DeleteLastCharacter();
        }

        private void buttonNegate_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.Negate();
        }

        private void itemAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pirvu George-Cristian\nInformatica Aplicata\n10LF332");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) 
        {
            switch(e.Key)
            {
                case Key.NumPad0: Functionalities.AppendNumber("0"); break;
                case Key.NumPad1: Functionalities.AppendNumber("1"); break;
                case Key.NumPad2: Functionalities.AppendNumber("2"); break;
                case Key.NumPad3: Functionalities.AppendNumber("3"); break;
                case Key.NumPad4: Functionalities.AppendNumber("4"); break;
                case Key.NumPad5: Functionalities.AppendNumber("5"); break;
                case Key.NumPad6: Functionalities.AppendNumber("6"); break;
                case Key.NumPad7: Functionalities.AppendNumber("7"); break;
                case Key.NumPad8: Functionalities.AppendNumber("8"); break;
                case Key.NumPad9: Functionalities.AppendNumber("9"); break;
                case Key.Back: Functionalities.DeleteLastCharacter(); break;
                case Key.Add: Functionalities.SetOperator("+"); break;
                case Key.Subtract: Functionalities.SetOperator("-"); break;
                case Key.Multiply: Functionalities.SetOperator("*"); break;
                case Key.Enter: Functionalities.CalculateResult(); break;
                case Key.Escape: Functionalities.Clear(); break;
            }
        }

        private void buttonCE_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.DeleteLastNumber();
        }

        private void buttonProcent_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.Percentage();
        }

        private void itemCopy_Click(object sender, RoutedEventArgs e)
        {
            Functionalities.CopyFunction();
        }

        private void itemPaste_Clicked(object sender, RoutedEventArgs e)
        {
            Functionalities.PasteFunction();
        }
    }
}