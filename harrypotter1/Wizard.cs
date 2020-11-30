using System;
using System.Collections.Generic;
using System.Text;

namespace harrypotter1
{
    class Wizard
    {
        public string BloodStatus  // property
        { get; set; }
        public bool DeathEater  // property
        { get; set; }
        public bool DumbledoresArmy  // property
        { get; set; }
        public string Name  // property
        { get; set; }
        // Instantiate random number generator.  
        private readonly Random _random = new Random();

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        private void SetBloodStatus()
        {
            // This sets a random blood status
            string[] bloodStatus = { "renblod", "halvblod", "mugglarfödd", "okänt" };
            BloodStatus = bloodStatus[RandomNumber(0, 2)];
        }
        public Wizard(string name, bool eater, bool army)
        {
            Name = name;
            DeathEater = eater;
            DumbledoresArmy = army;
            SetBloodStatus();
        }
    }
}
