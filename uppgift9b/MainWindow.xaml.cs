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

namespace uppgift8
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
            string ageText = ageInput.Text;
            if (CheckIfNumber(ageText) == false)
            {
                MessageBox.Show("Fel! Accepterar bara ålder i positiva heltal");
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
            // get inputs
            string ageText = ageInput.Text;
            // convert to int
            int firstInt = int.Parse(ageText);
            int[] integers = { firstInt };
            return integers;
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // reset inputs and the result
            nameInput.Text = "";
            ageInput.Text = "";
            result.Text = "";
        }
        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == true)
            {
                int[] integers = convertToInt();
                // get name
                string name = nameInput.Text;
                if (name.Length == 0)
                {
                    MessageBox.Show("Fel. Namn saknas.");
                }
                else
                {
                    int age = integers[0];
                    if (withAdult.IsChecked == true)
                    {
                        if (age < 7)
                        {
                            result.Text = $"Hej {name}. Du är {age} år gammal och får endast se barnfilmer. \nDet spelar ingen roll att du går \ntillsammans med en vuxen.";
                        }
                        if (age >= 7 && age < 11)
                        {
                            result.Text = $"Hej {name}. Du är {age} år gammal och får se barnfilmer \noch filmer med åldersgräns upp till 11 år \neftersom du är tillsammans med en vuxen.";
                        }
                        if (age >= 11 && age < 15)
                        {
                            result.Text = $"Hej {name}. Du är {age} år gammal och får se barnfilmer \noch filmer med åldersgräns upp till 15 år \neftersom du är tillsammans med en vuxen.";
                        }
                        if (age >= 15)
                        {
                            result.Text = $"Hej {name}. Du är {age} år gammal och får se alla filmer.";
                        }
                    }
                    else
                    {
                        if (age < 7)
                        {
                            result.Text = $"Hej {name}. Du är {age} år gammal och får endast se barnfilmer.";
                        }
                        if (age >= 7 && age < 11)
                        {
                            result.Text = $"Hej {name}. Du är {age} år gammal och får se barnfilmer \noch filmer med åldersgräns upp till 7 år.";
                        }
                        if (age >= 11 && age < 15)
                        {
                            result.Text = $"Hej {name}. Du är {age} år gammal och får se barnfilmer \noch filmer med åldersgräns upp till 11 år.";
                        }
                        if (age >= 15)
                        {
                            result.Text = $"Hej {name}. Du är {age} år gammal och får se alla filmer.";
                        }
                    }
                }    
            }
        }
    }
}