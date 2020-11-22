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

namespace uppgift6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // reset inputs and the result
            firstInput.Text = "";
            secondInput.Text = "";
            result.Text = "";
            type.Visibility = Visibility.Hidden;
        }
        private static bool CheckIfNumber(string number)
        {
            bool success = int.TryParse(number, out int test);
            return success;
        }
        private bool CheckInputs()
        {
            // never trust the user - check the inputs
            string firstText = firstInput.Text;
            string secondText = secondInput.Text;
            if (CheckIfNumber(firstText) == false
                || CheckIfNumber(secondText) == false)
            {
                MessageBox.Show("Fel! Accepterar bara positiva heltal");
                return false;
            }
            else
            {
                return true;
            }
        }
        private int[] convertToInt()
        {
            // never trust the user - check the inputs
            string firstText = firstInput.Text;
            string secondText = secondInput.Text;
            // convert to int
            int firstInt = int.Parse(firstText);
            int secondInt = int.Parse(secondText);
            int[] integers = { firstInt, secondInt };
            return integers;
        }
        private static int SumNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        private static int SubtractNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
        private static int MultiplyNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
        private static double DivideNumbers(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
            {
                MessageBox.Show("Fel, kan inte dividera med 0!");
                return 0; 
            }
            else
            {
                double res = (double)firstNumber / secondNumber;
                return Math.Round(res, 2);
            }
            
        }
        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == true)
            {
                int[] integers = convertToInt();
                // calculate the result
                int res = SumNumbers(integers[0], integers[1]);
                // show it to the user
                result.Text = res.ToString();
                // set the type
                type.Visibility = Visibility.Visible;
                type.Text = "Summa";
            }
        }
        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == true)
            {
                int[] integers = convertToInt();
                // calculate the result
                int res = SubtractNumbers(integers[0], integers[1]);
                // show it to the user
                result.Text = res.ToString();
                // set the type
                type.Visibility = Visibility.Visible;
                type.Text = "Differens";
            }
        }
        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == true)
            {
                int[] integers = convertToInt();
                // calculate the result
                int res = MultiplyNumbers(integers[0], integers[1]);
                // show it to the user
                result.Text = res.ToString();
                // set the type
                type.Visibility = Visibility.Visible;
                type.Text = "Produkt";
            }
        }
        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == true)
            {
                int[] integers = convertToInt();
                // calculate the result
                double res = DivideNumbers(integers[0], integers[1]);
                // show it to the user
                result.Text = res.ToString();
                // set the type
                type.Visibility = Visibility.Visible;
                type.Text = "Kvot";
            }
        }
    }
}
