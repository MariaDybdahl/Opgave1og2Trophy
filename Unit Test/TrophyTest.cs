using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opgave1og2Trophy;
namespace Unit_Test
{
    [TestClass]
    public class TrophyTest
    {
        Trophy trophy = new Trophy(1,"Sv�mmning", 2000);
        Trophy trophyCompetitionNull = new Trophy(2, null, 2013);
        Trophy trophyCompetitionLessThen3 = new Trophy(3, "G�", 2012);
        Trophy trophyCompetition3 = new Trophy(4, "G�r", 2015);
        Trophy trophyCompetition4 = new Trophy(5, "G�r3", 2015);
        Trophy trophyYearLess1970 = new Trophy(6, "L�bning", 1940);
        Trophy trophyYear1970 = new Trophy(7, "Sv�mming", 1970);
        Trophy trophyYearAfter2024 = new Trophy(8, "L�bning", 2025);
        Trophy trophyYear2024 = new Trophy(9, "G�r", 2024);
        private Trophy trophyYear1971 = new Trophy(10, "JJJ", 1971);
        private Trophy trophyYear2023 = new Trophy(11, "dddd", 2023);

        [TestMethod]
        public void ToStringTest()
        {
            //laver en string af trophy tostring
            string str = trophy.ToString();   // act
            //Derefter ser om de er ens.
            Assert.AreEqual("1 Sv�mmning 2000", str);  // assert
        }

        [TestMethod]
        public void ValidateCompetitionTest()
        {
            trophy.ValidateCompetition();

            //Gr�nsev�rdi test. tester under, p� og lige over
            Assert.ThrowsException<ArgumentNullException>(() => trophyCompetitionNull.ValidateCompetition());
            Assert.ThrowsException<ArgumentException>(() => trophyCompetitionLessThen3.ValidateCompetition());
            trophyCompetition3.ValidateCompetition(); 
            trophyCompetition4.ValidateCompetition();

        }

        [TestMethod]
        public void ValidateYearTest()
        {
            //Gr�nsev�rdi test. tester under, p� og lige over
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyYearLess1970.ValidateYear());
            trophyYear1970.ValidateYear();
            trophyYear1971.ValidateYear();
            trophyYear2023.ValidateYear();
            trophyYear2024.ValidateYear();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyYearAfter2024.ValidateYear());


        }

        [TestMethod]
        public void ValidateTest()
        {
            trophy.Validate();
       
            //Gr�nsev�rdi test. tester under, p� og lige over
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyYearLess1970.Validate());
            trophyYear1970.Validate();
            trophyYear1971.Validate();
            trophyYear2023.Validate();
            trophyYear2024.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyYearAfter2024.Validate());
            
            //Gr�nsev�rdi test. tester under, p� og lige over
            Assert.ThrowsException<ArgumentNullException>(() => trophyCompetitionNull.Validate());
            Assert.ThrowsException<ArgumentException>(() => trophyCompetitionLessThen3.Validate());
            trophyCompetition3.Validate(); 
            trophyCompetition4.Validate();
        }
    }
}