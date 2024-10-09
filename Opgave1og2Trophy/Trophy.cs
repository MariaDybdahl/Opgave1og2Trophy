using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Opgave1og2Trophy
{
    public class Trophy
    {
        //Id, et tal
        //Competition, tekst-streng, min 3 tegn langt, må ikke være null
        //Year, tal, 1970 <= year  <= 2024
        //samt en ToString() metode

        public int Id { get; set; }
        public string Competition { get; set; }
        public int Year { get; set; }

        public Trophy(int id, string competition, int year)
        {
            Id = id;
            Competition = competition;
            Year = year;
        }

        public Trophy(string competition, int year)
        {
            Competition = competition;
            Year = year;
        }
        //en tom konstrukter 
        public Trophy()
        {
        }
        public Trophy(Trophy original)
        {
            Competition = original.Competition;
            Year = original.Year;
            Id = original.Id;
        }
        public void ValidateCompetition()
        {
            //Ser om competition er null
            if (Competition == null)
            {
                //Jeg har valgt ArgumentNullException fordi vi tjekker om den er null, så den viser at vi har med en null værdi
                throw new ArgumentNullException("Kan ikke være null");

            }
            //ser om den er mindre end 3
            if (Competition.Length < 3)
            {
                //Jeg har valgt ArgumentException da vi bare en ting som den skal være indfor
                throw new ArgumentException("Skal være større end eller lige med 3");
            }
            
        }
        public void ValidateYear()
        {
            //Ser om år er er mindre end 1970 eller større end 2024
           if ((Year < 1970 ) || (Year > 2024))
            {
                //Jeg har valgt ArgumentOutOfRangeException da vi har et interval for Year den skal være indfor, derfor vil den vise at
                //det valgt tal ikke er i intervalt
                throw new ArgumentOutOfRangeException("Året skal være mellem 1970 til 2024");
            }

        }

        //En ToString() metoden
        public override string ToString()
        {
            return Id + " " + Competition + " " + Year;
        }
        //En validate metode som går ind i de andre validate metoder.
        public void Validate()
        {
            ValidateCompetition();
            ValidateYear();
        }
    }
}
