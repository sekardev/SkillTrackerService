using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillTrackerService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillTrackerDb.Model;
namespace SkillTrackerService.Controllers.Tests
{
    [TestClass()]
    public class SkillControllerTests
    {
        SkillTrackerDb.SkillDb skills = new SkillTrackerDb.SkillDb();
        [TestMethod()]
        public void GetTest()
        {
            int expectedCount = 2;
            int actualCount = skills.GetAll().Count;
            Assert.AreEqual(expectedCount, actualCount);

        }

        [TestMethod()]
        public void GetByIdTest()
        {
            string skillName = "AngularJS";
            string actualSkillName  = skills.GetAll().First(a=>a.SkillId == 1).SkillName;
            Assert.AreEqual(skillName, actualSkillName);
        }


    }
}