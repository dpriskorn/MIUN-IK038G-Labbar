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

namespace uppgift14
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
        private static bool CheckIfNumber(string number)
        {
            bool success = int.TryParse(number, out int test);
            return success;
        }
        private bool CheckInputs(string input)
        {
            // never trust the user - check the inputs
            if (CheckIfNumber(input) == false)
            {
                MessageBox.Show("Fel! Accepterar bara positiva heltal");
                return false;
            }
            else
            {
                return true;
            }
        }
        private int convertToInt(string input)
        {
            return int.Parse(input);
        }
        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            string userinput = input.Text.ToString();
            if (CheckInputs(userinput) == true)
            {
                int birthyear = convertToInt(userinput);
                int year = DateTime.Today.Year;
                int age = year - birthyear;
                MessageBox.Show($"Du är {age} år gammal.");
            }
        }
    }
}
