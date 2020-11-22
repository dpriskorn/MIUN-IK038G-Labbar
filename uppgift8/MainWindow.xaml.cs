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
            string firstText = galleonInput.Text;
            string secondText = siklerInput.Text;
            string thirdText = knutingInput.Text;
            if (CheckIfNumber(firstText) == false
                || CheckIfNumber(secondText) == false
                || CheckIfNumber(thirdText) == false)
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
            string firstText = galleonInput.Text;
            string secondText = siklerInput.Text;
            string thirdText = knutingInput.Text;
            // convert to int
            int firstInt = int.Parse(firstText);
            int secondInt = int.Parse(secondText);
            int thirdInt = int.Parse(thirdText);
            int[] integers = { firstInt, secondInt, thirdInt };
            return integers;
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // reset inputs and the result
            galleonInput.Text = "";
            siklerInput.Text = "";
            knutingInput.Text = "";
            result.Text = "";
        }
        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == true)
            {
                int[] integers = convertToInt();
                // 1 Galleon motsvarar 62,02 SEK
                // 1 Galleon = 17 Sikler
                // 1/17 * 62,02 SEK = 3,648235294117647 SEK
                // 1 Galleon = 493 Knutingar
                // 1/493 * 62,02 SEK = 0,1258012170385396 SEK

                // calculate
                double one = 1;
                double sikler = 17;
                double knuting = 493;
                double sek = integers[0] * 62.02;
                sek += integers[1] * (one / sikler) * 62.02;
                sek += integers[2] * (one / knuting) * 62.02;

                // amount to the user
                result.Text = Math.Round(sek, 0).ToString() + " SEK";
            }
        }
    }
}