using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTheBooks.Classes
{
    //-----------------------------------------------START---------------------------------------------//
    internal class Identify
    {
        // Declare our dictionary that will hold the call numbers and their definitions.
        IDictionary<string, string> matchColumns;
        // Declare a dictionary that holds the values as keys and the keys as values
        IDictionary<string, string> oppColumns;
        //----------------------------------------------------------------------------------------------//
        // Method to initialize the dictionary
        public void InitDict()
        {
            // Initialising our dictionaries
            this.matchColumns = new Dictionary<string, string>();
            this.oppColumns = new Dictionary<string, string>();
            this.matchColumns.Clear();
            this.oppColumns.Clear();
        }
        //----------------------------------------------------------------------------------------------//
        // Populate our dictionary with call numbers and their definitions
        public IDictionary<string, string> PopDict()
        {
            // Call method that initialises our dictionary
            InitDict();

            // Adding a key/value using the Add() method
            this.matchColumns.Add("000-099", "General Works, Computer Science & Information");
            this.matchColumns.Add("100-199", "Philosophy & Psychology");
            this.matchColumns.Add("200-299", "Religion");
            this.matchColumns.Add("300-399", "Social sciences");
            this.matchColumns.Add("400-499", "Language");
            this.matchColumns.Add("500-599", "Science");
            this.matchColumns.Add("600-699", "Technology");
            this.matchColumns.Add("700-799", "Arts & recreation");
            this.matchColumns.Add("800-899", "Literature");
            this.matchColumns.Add("900-999", "History & Geography"); 

            Random rand = new Random();
            this.matchColumns = this.matchColumns.OrderBy(x => rand.Next()).ToDictionary(item => item.Key, item => item.Value);

            return this.matchColumns;
        }
        //----------------------------------------------------------------------------------------------//
        public IDictionary<string, string> PopOppDict()
        {
            // Adding a key/value using the Add() method
            this.oppColumns.Add("General Works, Computer Science & Information", "000-099");
            this.oppColumns.Add("Philosophy & Psychology", "100-199");
            this.oppColumns.Add("Religion", "200-299");
            this.oppColumns.Add("Social sciences", "300-399");
            this.oppColumns.Add("Language", "400-499");
            this.oppColumns.Add("Science", "500-599");
            this.oppColumns.Add("Technology", "600-699");
            this.oppColumns.Add("Arts & recreation", "700-799");
            this.oppColumns.Add("Literature", "800-899");
            this.oppColumns.Add("History & Geography", "900-999");

            return this.oppColumns;
        }
    }
    //------------------------------------------------END-----------------------------------------------//
}
/*
000 - 099 = General Works, Computer Science & Information
100 - 199 = Philosophy & Psychology
200 - 299 = Religion
300 - 399 = Social sciences
400 - 499 = Language
500 - 599 = Science
600 - 699 = Technology
700 - 799 = Arts & recreation
800 - 899 = Literature
900 - 999 = History & Geography
 */