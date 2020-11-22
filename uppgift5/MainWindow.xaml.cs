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

namespace uppgift5
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

        private static bool checkIfNumber(string number)
        {
            bool success = int.TryParse(number, out int test);
            return success;
        }
        private static int sumNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            // reset inputs and the result
            firstNumber.Text = "";
            secondNumber.Text = "";
            result.Text = "";
        }

        private void sumButton_Click(object sender, RoutedEventArgs e)
        {
            // never trust the user - check the inputs
            string firstText = firstNumber.Text;
            string secondText = secondNumber.Text;
            if (checkIfNumber(firstText) == true
                && checkIfNumber(secondText) == true) 
            {
                // convert to int
                int firstNumber = int.Parse(firstText);
                int secondNumber = int.Parse(secondText);
                // calculate the result
                int sum = sumNumbers(firstNumber, secondNumber);
                // show it to the user
                result.Text = sum.ToString();
            }
            else
            {
                MessageBox.Show("Fel! Accepterar bara positiva heltal");
            }

        }
    }
}
