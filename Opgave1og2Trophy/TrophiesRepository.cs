using System.Collections.Generic;

namespace Opgave1og2Trophy
{
    public class TrophiesRepository
    { //Klassen skal indeholde en liste af Trophy objekter. Indsæt mindst 5 objekter i listen.
        private List<Trophy> Trophies = new List<Trophy>()
        { 
        new Trophy(1, "Gårture", 2013),
        new Trophy(2, "Svømming", 2002),
        new Trophy(3, "Fodbold", 2020),
        new Trophy(4, "Badminton", 2017),
        new Trophy(5, "Tegning", 2008)

        };
        private int _nextId = 1;

        //Get() Returnerer en kopi af listen af alle Trophy objekter: Brug en copy constructor.

        public IEnumerable<Trophy> Get(int? yearAfter = null, int? yearBefore = null, string? orderBy = null)
        {
            //Laver en kopi af listen af alle Trophy objekter
            IEnumerable<Trophy> result = Trophies.Select(t => new Trophy(t)).ToList();

            //Filtering
            if (yearAfter != null)
            {
                result = result.Where(m => m.Year > yearAfter);
            }
            if (yearBefore != null)
            {
                result = result.Where(m => m.Year < yearBefore);
            }



            //Sorting
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "competition": // fall through to next case
                    case "competition_asc":
                        result = result.OrderBy(m => m.Competition);
                        break;
                    case "competition_desc":
                        result = result.OrderByDescending(m => m.Competition);
                        break;
                    case "year":
                    case "year_asc":
                        result = result.OrderBy(m => m.Year);
                        break;
                    case "year_desc":
                        result = result.OrderByDescending(m => m.Year);
                        break;
                    default:
                        break; // do nothing
                }


            }
            return result;

        }


        public Trophy GetTrophyById(int id)
        {
           
           if (id != null)
            { 
                //returnerer det første objekt i listen, som har det samme id som det angivne id.
                return Trophies.FirstOrDefault(t => t.Id == id);
            }
            return null;
        }


        public Trophy AddTrophy(Trophy trophy)
        {
            //Tildeler et id til det nye Trophy objekt.
            trophy.Id = _nextId;
            //Incrementer _nextId
            _nextId++; 
            //Tilføjer et Trophy objekt til listen.
            Trophies.Add(trophy);
            //Returnerer det nye Trophy objekt.
            return trophy;
        }
        public Trophy RemoveTrophy(int id) 
        {
            
            //Finder det første objekt i listen, som har det samme id som det angivne id.
            Trophy trophy = Trophies.FirstOrDefault(t => t.Id == id);
                //Hvis den ikke er null vil den gå ind og fjerne obejktet fra listen.
            if (trophy != null)
            {
                Trophies.Remove(trophy);
                return trophy;
            }
            
            return null;
        }
        public Trophy UpdateTrophy(int id, Trophy values)
        {
            
            values.Validate();
            //Finder det første objekt i listen, som har det samme id som det angivne id.
            Trophy trophy = Trophies.FirstOrDefault(t => t.Id == id);
             //hvis det nyt value og det gamle trophy obejkt ikke er null.
            if (trophy != null && values!=null)
            {  
                //Opdaterer objektet med værdierne fra det angivne Trophy objekt.
                trophy.Competition = values.Competition;
                trophy.Year = values.Year; 
                //return obejkt
                return trophy;
            }
           
     
            return null;
        }
    }
}
