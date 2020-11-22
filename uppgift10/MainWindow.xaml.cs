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

namespace uppgift10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // public variable
        int answer = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool CheckInputs()
        {
            // never trust the user - check the inputs
            string firstText = guess.Text;
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
        private static bool CheckIfNumber(string number)
        {
            bool success = int.TryParse(number, out int test);
            return success;
        }
        private int[] convertToInt()
        {
            // never trust the user - check the inputs
            string firstText = guess.Text;
            // convert to int
            int firstInt = int.Parse(firstText);
            int[] integers = { firstInt };
            return integers;
        }
        private void GenerateRandomAnswer()
        {
            Random slump = new Random();
            answer = slump.Next(1000);
        }
        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == true)
            {
                if (answer == 0)
                {
                    GenerateRandomAnswer();
                }
                // debug
                // MessageBox.Show(answer.ToString());
                int[] integers = convertToInt();
                int guess = integers[0];
                if (guess == answer)
                {
                    result.Text = "Du gissade rätt!";
                }
                else if (guess > answer)
                {
                    if ((guess - 100) > answer)
                    {
                        result.Text = "Du gissade alldeles för långt över!";
                    }
                    else
                    {
                        result.Text = "Du gissade över!";
                    }
                }
                else if (guess < answer)
                {
                    if ((guess + 100) < answer)
                    {
                        result.Text = "Du gissade alldeles för lågt!";
                    }
                    else
                    {
                        result.Text = "Du gissade för lågt!";
                    }
                }
            }
        }
        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateRandomAnswer();
        }
    }
}