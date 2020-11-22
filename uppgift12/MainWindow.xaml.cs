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

namespace uppgift12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double meanvalue = 0;
        List<int> values = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private static bool CheckIfNumber(string number)
        {
            bool success = int.TryParse(number, out int test);
            return success;
        }
        private bool CheckInputs()
        {
            // never trust the user - check the inputs
            if (CheckIfNumber(input.Text) == false)
            {
                MessageBox.Show("Fel! Accepterar bara positiva heltal");
                return false;
            }
            else
            {
                return true;
            }
        }
        private int convertToInt()
        {
            // never trust the user - check the inputs
            string firstText = input.Text;
            // convert to int
            return int.Parse(firstText);
        }
        private void AddToList()
        {
            values.Add(convertToInt());
        }
        private void Calculate()
        {
            meanvalue = Math.Round(values.Average(), 1);
        }
        private void ShowResult()
        {
            mean.Text = meanvalue.ToString();
            listbox.ItemsSource = values.ToArray();
        }
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs() == true)
            {
                AddToList();
                Calculate();
                ShowResult();
            }
        }
    }
}
