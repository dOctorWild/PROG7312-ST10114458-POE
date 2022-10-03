using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTheBooks.Classes
{
    internal class Replace
    {
        //----------------------------------------------------------------------------------------------//
        // Declaring variables
        private Random random;
        private List<string> randomCallNumbers = new List<string>();
        private List<string> userSorted = new List<string>();
        //----------------------------------------------------------------------------------------------//
        //Method to intialise the random
        private void InitDict()
        {
            this.random = new Random();
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
        // Method that sorts the random list to check with the user sorted list
        public void SortAndCheckList()
        {
            this.randomCallNumbers.Sort();
            int i = 0;
            int points = 0;

            foreach (string callStr in this.randomCallNumbers)
            {
                if (callStr == this.userSorted[i])
                {
                    points++;
                }
                i++;
            }

            if (points == 10)
            {
                //ShowSuccessPage();
            }
            else
            {
                //ShowIncorrectOrder();
            }
        }
    }
}
