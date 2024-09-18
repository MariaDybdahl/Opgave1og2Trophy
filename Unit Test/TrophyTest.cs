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
        Trophy trophyYearLess1970 = new Trophy(5, "L�bning", 1940);
        Trophy trophyYear1970 = new Trophy(6, "Sv�mming", 1970);
        Trophy trophyYearAfter2024 = new Trophy(7, "L�bning", 2027);
        Trophy trophyYear2024 = new Trophy(8, "G�r", 2024);

        [TestMethod]
        public void ToStringTest()
        {
            string str = trophy.ToString();   // act
            Assert.AreEqual("1 Sv�mmning 2000", str);  // assert
        }

        [TestMethod]
        public void ValidateCompetitionTest()
        {
            trophy.ValidateCompetition();
            Assert.ThrowsException<ArgumentNullException>(() => trophyCompetitionNull.ValidateCompetition());
            Assert.ThrowsException<ArgumentException>(() => trophyCompetitionLessThen3.ValidateCompetition());
            trophyCompetition3.ValidateCompetition(); //Bare for at test at den godt m� v�re 3 tegn.

        }
        [TestMethod]
        public void ValidateYearTest()
        {
            //Tester alle som virker
            trophy.ValidateYear();
            trophyYear1970.ValidateYear();
            trophyYear2024.ValidateYear();

            //Year som har noget galt

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyYearLess1970.ValidateYear());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyYearAfter2024.ValidateYear());

        }
        [TestMethod]
        public void ValidateTest()
        {
            trophy.Validate();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyYearLess1970.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyYearAfter2024.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => trophyCompetitionNull.Validate());
            Assert.ThrowsException<ArgumentException>(() => trophyCompetitionLessThen3.Validate());
        }
    }
}