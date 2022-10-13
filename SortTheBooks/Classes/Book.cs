using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTheBooks.Classes
{
    //-----------------------------------------------START---------------------------------------------//
    internal class Book
    {
        //----------------------------------------------------------------------------------------------//
        public class Books
        {
            public string callNumber;
            public string initials;
            //----------------------------------------------------------------------------------------------//
            public Books(string callNum, string initials)
            {
                this.callNumber = callNum;
                this.initials = initials;
            }
            //----------------------------------------------------------------------------------------------//
        }
        //----------------------------------------------------------------------------------------------//
    }
    //------------------------------------------------END-----------------------------------------------//
}
