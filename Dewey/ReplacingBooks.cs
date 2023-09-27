
using System;
using System.Collections.Generic;
using System.Text;

namespace Dewey
{
    public class ReplacingBooks
    {
        //Contructor
        public ReplacingBooks(double code, string surname)
        {
            this.code = code;
            this.surname = surname;
        }

        //Getters & Setters
        public double code { get; set; }
        public string surname { get; set; }

    }
}
