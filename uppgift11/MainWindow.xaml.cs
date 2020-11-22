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

namespace uppgift11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int unluck = 50;
        int correct = 0;
        int incorrect = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DecreaseUnluck()
        {
            if (unluck > 0)
            {
                unluck -= 5;
                progress.Value = unluck;
            }
        }
        private void lessUnluck_Click(object sender, RoutedEventArgs e)
        {
            DecreaseUnluck();
        }
        private void IncreaseUnluck()
        {
            if (unluck < 100)
            {
                unluck += 5;
                progress.Value = unluck;
            }
        }
        private void moreUnluck_Click(object sender, RoutedEventArgs e)
        {
            IncreaseUnluck();
        }
        private static bool CheckIfNumber(string number)
        {
            bool success = int.TryParse(number, out int test);
            return success;
        }
        private bool CheckInputs()
        {
            // never trust the user - check the inputs
            string firstText = rounds.Text;
            if (CheckIfNumber(firstText) == false)
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
            string firstText = rounds.Text;
            // convert to int
            int firstInt = int.Parse(firstText);
            int[] integers = { firstInt };
            return integers;
        }
        private void CalculateResult()
        {
            unluckDebug.Text = unluck.ToString();
            int[] integers = convertToInt();
            int rounds = integers[0];
            // This calculates how many of the single layer 
            // sandwitches ended up with the sticky side up
            Random slump = new Random();
            while (rounds > 0)
            {
                int result = slump.Next(100);
                // The more unluck you got - the less chance of getting 
                // a correct score
                if (result < unluck)
                {
                    incorrect += 1;
                }
                else
                {
                    correct += 1;
                }
                rounds -= 1;
            }
        }
        private void ShowResult()
        {
            resultCorrect.Text = $"Antal åt rätt håll {correct}";
            resultIncorrect.Text = $"Antal åt fel håll {incorrect}";
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == true)
            {
                CalculateResult();
                ShowResult();
            }
        }
    }
}
