using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            if (Competition == null)
            {
                throw new ArgumentNullException("Kan ikke være null");

            }

            if (Competition.Length < 3)
            {
                throw new ArgumentException("Skal være større end eller lige med 3");
            }
            
        }
        public void ValidateYear()
        {
           if ((Year < 1970 ) || (Year > 2024))
            {
                throw new ArgumentOutOfRangeException("Året skal være mellem 1970 til 2024");
                //Overveje om det er ArgumentOutOfRangeException
            }

        }
        public override string ToString()
        {
            return Id + " " + Competition + " " + Year;
        }
        public void Validate()
        {
            ValidateCompetition();
            ValidateYear();
        }
    }
}
