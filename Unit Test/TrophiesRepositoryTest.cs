using Opgave1og2Trophy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    [TestClass]
    public class TrophiesRepositoryTest
    {
        private readonly Trophy TrophyWrongYear = new() { Competition = "Test", Year = 2025 };
        private TrophiesRepository _trophiesRepository;

        [TestInitialize]
        public void Setup()
        {
            _trophiesRepository = new TrophiesRepository();
        }
        [TestMethod]
        public void GetTest()
        {
            
            IEnumerable<Trophy> trophies = _trophiesRepository.Get(orderBy: "competition");
            Assert.AreEqual(trophies.First().Competition, "Badminton");

            trophies = _trophiesRepository.Get(orderBy: "year");
            Assert.AreEqual(trophies.First().Competition, "Svømming");

            trophies = _trophiesRepository.Get(yearAfter: 2007);
            Assert.AreEqual(4, trophies.Count());
            Assert.AreEqual(trophies.First().Year, 2013);


        }

        [TestMethod]
        public void UpdateTrophyTest()
        {
            Assert.AreEqual(5, _trophiesRepository.Get().Count());
            Trophy t = new() { Competition = "Test", Year = 2021 };
            Assert.IsNull(_trophiesRepository.UpdateTrophy(7, t));
            Assert.AreEqual(1, _trophiesRepository.UpdateTrophy(1, t)?.Id);
            Assert.AreEqual(5, _trophiesRepository.Get().Count());
           
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _trophiesRepository.UpdateTrophy(1, TrophyWrongYear));
        }
        [TestMethod()]
        public void RemoveTrophyTest()
        {
            Assert.IsNull(_trophiesRepository.RemoveTrophy(100));
            Assert.AreEqual(1, _trophiesRepository.RemoveTrophy(1)?.Id);
            Assert.AreEqual(4, _trophiesRepository.Get().Count());
        }
    }
}
