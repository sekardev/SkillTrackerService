using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerServiceTests.Controllers
{
    public class AssociateSkillControllerTests
    {
        SkillTrackerDb.AssociateSkillDb associateSkill = new SkillTrackerDb.AssociateSkillDb();
        [TestMethod()]
        public void Get_All_AssociateSkills()
        {
            int expectedCount = 2;
            int actualCount = associateSkill.GetAll().Count;
            Assert.AreEqual(expectedCount, actualCount);

        }

        [TestMethod()]
        public void Get_AssociateName_ById()
        {
            int assoicateId = 2;
            string expectedAssociateName = "Mathew";
            string actualName = associateSkill.GetAll().FirstOrDefault(a => a.Associate_ID == assoicateId).Name;
            Assert.AreEqual(expectedAssociateName, actualName);

        }
    }
}
