using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerServiceTests.Controllers
{
    public class AssociateSummaryControllerTests
    {
        SkillTrackerDb.AssociateSummary associateSummary = new SkillTrackerDb.AssociateSummary();
        [TestMethod()]
        public void Get_AssociateSummary_Test()
        {
            int expectedCount = 2;
            int actualCount = associateSummary.GetSummary().RegisteredCandidates;
            Assert.AreEqual(expectedCount, actualCount);

        }
    }
}
