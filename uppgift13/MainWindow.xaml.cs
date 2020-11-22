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

namespace uppgift13
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
        private int FindLetters(string input, string letter)
        {
            int count = 0;
            string text = input.ToLower();
            string letterToFind = letter.ToLower();
            char[] array = new char[text.Length];
            array = text.ToCharArray();
            foreach (char c in array)
            {
                if (c == letterToFind[0])
                {
                    count += 1;
                }
            }
            return count;
        }
        private string GetInput()
        {
            return input.Text;
        }
        private string GetLetter()
        {
            return letter.Text;
        }
        private void ShowResult(string count)
        {
            result.Text = $"Hittade bokstaven {count} gånger.";
        }
        private void find_Click(object sender, RoutedEventArgs e)
        {
            int count = FindLetters(GetInput(), GetLetter());
            ShowResult(count.ToString());
        }
    }
}
