using System;
using System.Collections.Generic;
using System.Text;

namespace harrypotter1
{
    abstract class House // base class (parent)
    {
        public string HouseGhost  // property
        { get; set; }
        public string Mascot  // property
        { get; set; }
        public string Password  // property
        { get; set; }
        //char[] consonants = new char[] { 'b', 'c', 'c', 'd', 'f', 
        //    'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'x', 'z' };
        //char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y', 'ä', 'ö', 'å' };
        string consonants = "b c d f g h j k l m n p q r s t v w x y z";
        string vowels = "aeiouyäöå";
        private bool IsConsonant(char c)
        {
            if (consonants.Contains(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsVowel(char c)
        {
            if (vowels.Contains(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool HasCorrectPasswordFormat(string password)
        {
            string lowerPassword = password.ToLower();
            char firstLetter = lowerPassword[0];
            char lastLetter = lowerPassword[-1];
            if (this.GetType().Name == "Slytherin")
            {
                if (IsConsonant(firstLetter) && IsConsonant(lastLetter) && password.Length >= 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (IsVowel(firstLetter) && IsConsonant(lastLetter) && password.Length >= 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool SetPassword(string currentPassword, string newPassword)
        {
            if (HasCorrectPasswordFormat(newPassword))
            {
                if (Password == currentPassword)
                {
                    Password = newPassword;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
