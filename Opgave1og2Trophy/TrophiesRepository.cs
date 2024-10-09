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
            //hvis yearAfter ikke er null
            if (yearAfter != null)
            {
                // Filtrer resultaterne for at få trofæer med årstal større end yearAfter hvor vi bruger et lambda-udtryk 
                result = result.Where(m => m.Year > yearAfter);
            }
            //yearBefore ikke er null
            if (yearBefore != null)
            {
                // Filtrer resultaterne for at få trofæer med årstal mindre end yearBefore hvor vi bruger et lambda-udtryk 
                result = result.Where(m => m.Year < yearBefore);
            }



            //Sorting
            //Hvis orderBy ikke er null
            if (orderBy != null)
            {// fall through to next case
                //Sætter orderby til lowercase
                orderBy = orderBy.ToLower();
                //Laver en swich case for orderBy
                switch (orderBy)
                {
                    // Hvis "orderBy" er "competition" eller "competition_asc", sorter stigende efter "Competition"
                    case "competition": 
                    case "competition_asc":
                        result = result.OrderBy(m => m.Competition);
                        break;

                    // Hvis "orderBy" er "competition_desc", sorter faldende efter "Competition"
                    case "competition_desc":
                        result = result.OrderByDescending(m => m.Competition);
                        break;
                    // Hvis "orderBy" er "year" eller "year_asc", sorter stigende efter "Year"
                    case "year":
                    case "year_asc":
                        result = result.OrderBy(m => m.Year);
                        break;
                    // Hvis "orderBy" er "year_desc", sorter faldende efter "Year"
                    case "year_desc":
                        result = result.OrderByDescending(m => m.Year);
                        break;
                    default:
                        break; //Æaver et break så den stopper hvis den ikke rammer noget
                }


            }
            //Returner en list af Tropy obejkt  med det som macther.
            return result;

        }


        public Trophy GetTrophyById(int id)
        { 
                //returnerer det første objekt i listen, som har det samme id som det angivne id.
                return Trophies.FirstOrDefault(t => t.Id == id);
        }


        public Trophy AddTrophy(Trophy trophy)
        {
            //Tildeler et id til det nye Trophy objekt.
            trophy.Id = _nextId;
            //Incrementer _nextId
            _nextId++; 
            //Tilføjer et Trophy objekt til listen.
            Trophies.Add(trophy);
            //Returnerer det nye Trophy objekt som er tilføjt.
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
             //hvis det nyt value og det gamle trophy obejkt ikke er null, og listen ikke er null, da hvis n.
            if (trophy != null && values!=null)
            {  
                //Opdaterer objektet med værdierne fra det angivne Trophy objekt.
                trophy.Competition = values.Competition;
                trophy.Year = values.Year; 
                //return obejkt
                return trophy;
            }
           
     //returner null hvis den ikke gå igennem
            return null;
        }
    }
}
