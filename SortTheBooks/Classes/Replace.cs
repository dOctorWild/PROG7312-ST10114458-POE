using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTheBooks.Classes
{
    //-----------------------------------------------START---------------------------------------------//
    internal class Replace
    {
        //----------------------------------------------------------------------------------------------//
        // Declaring variables
        private Random random;
        private List<string> randomCallNumbers;
        //----------------------------------------------------------------------------------------------//
        //Method to intialise the random
        private void InitDict()
        {
            this.random = new Random();
            this.randomCallNumbers = new List<string>();
        }
        //-----------------------------------------------------------------------------------------------//
        // Generates three random characters to add to the call number
        private string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 4)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //----------------------------------------------------------------------------------------------//
        //Generates the random call numbers for the user to sort
        public List<string> GenerateRandomNumbers()
        {
            InitDict();
            this.randomCallNumbers.Clear();
            for (int i = 0; i < 10; i++)
            {
                this.randomCallNumbers.Add(random.Next(100, 1000).ToString() + "." + random.Next(10, 100) + RandomString());
            }
            return this.randomCallNumbers;
        }
        //----------------------------------------------------------------------------------------------//
    }
    //------------------------------------------------END-----------------------------------------------//
}
