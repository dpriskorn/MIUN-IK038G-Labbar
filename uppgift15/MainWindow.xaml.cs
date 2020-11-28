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

namespace uppgift15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char[] smallVowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y', 'ä', 'ö', 'å' };
        char[] bigVowels = new char[] { 'A', 'E', 'I', 'O', 'U', 'Y', 'Ä', 'Ö', 'Å' };
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool IsVowel(char c)
        {
            if (smallVowels.Contains(c) || bigVowels.Contains(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int NumberOfVowels(string text)
        {
            int count = 0;
            char[] array = new char[text.Length];
            array = text.ToCharArray();
            foreach (char c in array)
            {
                if (IsVowel(c))
                {
                    count += 1;
                }
            }
            return count;
        }
        private string ReplaceSmall(string text)
        {
            foreach (char c in smallVowels)
            {
                text = text.Replace(c, 'ö');
            }
            return text;
        }
        private string ReplaceBig(string text)
        {
            foreach (char c in bigVowels)
            {
                text = text.Replace(c, 'Ö');
            }
            return text;
        }
        private string Jibberish(string text)
        {
            return ReplaceSmall(ReplaceBig(text));
        }
        private void convert_Click(object sender, RoutedEventArgs e)
        {
            string inputText = input.Text;
            output.Text= Jibberish(inputText);
            count.Text = $"Antal vokaler: {NumberOfVowels(inputText)}";
        }
    }
}
