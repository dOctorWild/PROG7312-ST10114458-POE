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
        //----------------------------------------------------------------------------------------------//
        // Method to initialize the dictionary
        public void InitDict()
        {
            // Initialising our dictionary
            this.matchColumns = new Dictionary<string, string>();
            this.matchColumns.Clear();
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

            return this.matchColumns;
        }
        //----------------------------------------------------------------------------------------------//
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