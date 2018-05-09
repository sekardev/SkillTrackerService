using SkillTrackerDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDb
{
   public class AssociateSummary
    {
        MyContext db = null;
        public AssociateSummary()
        {
            db = new MyContext();
        }

        public Summary GetSummary()
        {
            Summary model = new Summary();
            try
            {
                Chart chart = new Chart();
                chart.Label = new List<string>();
                chart.Values = new List<int>();
                foreach (Skills skill in db.Skills)
                {
                    var db1 = new MyContext();
                    chart.Label.Add(skill.SkillName);
                    chart.Values.Add(db1.Associate_Skills.Where(a => a.Skill_ID == skill.SkillId).ToList().Count);
                }
                model.skillChart = chart;

                model.RegisteredCandidates = db.Associates.Count();
                if (model.RegisteredCandidates > 0)
                {
                    int totalMaleCandidate = db.Associates.Where(a => a.Gender == "M").Count();
                    int totalFeMaleCandidate = db.Associates.Where(a => a.Gender == "F").Count();
                    int l1ratedcandidate = db.Associates.Where(a => a.Level_1 == 1).Count();
                    int l2ratedcandidate = db.Associates.Where(a => a.Level_2 == 1).Count();
                    int l3ratedcandidate = db.Associates.Where(a => a.Level_3 == 1).Count();
                    int ratedcandidate = db.Associate_Skills.Select(a => a.Associate_ID).Distinct().Count();
                    int maleratedcandidate = (from t1 in db.Associates
                                              join t2 in db.Associate_Skills
                                              on t1.Id equals t2.Associate_ID
                                              where t1.Gender == "M"
                                              select t2.Associate_ID).Distinct().Count();
                    int femaleratedcandidate = (from t1 in db.Associates
                                                join t2 in db.Associate_Skills
                                                on t1.Id equals t2.Associate_ID
                                                where t1.Gender == "F"
                                                select t2.Associate_ID).Distinct().Count();
                    model.MaleCandidates = Convert.ToInt32(((Convert.ToDouble(totalMaleCandidate) / model.RegisteredCandidates)) * 100);
                    model.FemaleCandidates = Convert.ToInt32(Convert.ToDouble((Convert.ToDouble(totalFeMaleCandidate) / model.RegisteredCandidates)) * 100);
                    model.L1RatedCandidates = Convert.ToInt32(((Convert.ToDouble(l1ratedcandidate) / model.RegisteredCandidates)) * 100);
                    model.L2RatedCandidates = Convert.ToInt32(((Convert.ToDouble(l2ratedcandidate) / model.RegisteredCandidates)) * 100);
                    model.L3RatedCandidates = Convert.ToInt32(((Convert.ToDouble(l3ratedcandidate) / model.RegisteredCandidates)) * 100);
                    model.FresherCandidates = Convert.ToInt32((Convert.ToDouble(db.Associates.Where(a => a.Level_1 == 1).Count()) / (model.RegisteredCandidates)) * 100);
                    model.RatedCandidates = Convert.ToInt32(((Convert.ToDouble(ratedcandidate) / model.RegisteredCandidates)) * 100);

                    model.MaleRatedCandidates = Convert.ToInt32(((Convert.ToDouble(maleratedcandidate) / model.RegisteredCandidates)) * 100);
                    model.FemaleRatedCandidates = Convert.ToInt32(((Convert.ToDouble(femaleratedcandidate) / model.RegisteredCandidates)) * 100);

                }

            }
            catch (Exception ex)
            {
              model =  new Summary();
            }
            return model;
        }



    }
}
