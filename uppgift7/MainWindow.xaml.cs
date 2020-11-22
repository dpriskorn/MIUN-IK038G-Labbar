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

namespace uppgift7
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
        private static bool CheckIfNumber(string number)
        {
            bool success = int.TryParse(number, out int test);
            return success;
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
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // reset inputs and the result
            firstInput.Text = "";
            secondInput.Text = "";
            whole.Text = "";
            rest.Text = "";
        }
        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == true)
            {
                int[] integers = convertToInt();
                // calculate
                int wholeint = integers[0] / integers[1];
                int restint = integers[0] % integers[1];
                // show to the user
                whole.Text = wholeint.ToString();
                rest.Text = restint.ToString();

            }
        }
    }
}
