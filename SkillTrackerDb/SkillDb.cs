using SkillTrackerDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDb
{
  public  class SkillDb
    {
        MyContext db = null;
        public SkillDb()
        {
            db = new MyContext();
        }

        public List<Skills> GetAll()
        {
            try
            {
                return db.Skills.ToList();
            }
            catch (Exception ex)
            {
                return new List<Skills>();
            }
        }


        public Skills GetById(int Id)
        {
            try
            {
                return db.Skills.Find(Id);
            }
            catch (Exception ex)
            {
                return new Skills();
            }
        }

       

        public bool Add(Skills model)
        {
            try
            {
                if (model.SkillId > 0)
                {
                    model.Updated = DateTime.Now;
                    Skills editSkill = db.Skills.Find(model.SkillId);
                    db.Entry(editSkill).CurrentValues.SetValues(model);
                }
                else
                {
                    model.Created = DateTime.Now;
                    db.Skills.Add(model);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Delete(int Id)
        {
            try
            {
                Skills category = db.Skills.Find(Id);
                db.Skills.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<Skills> GetByName(string skillName)
        {
            try
            {
                return db.Skills.Where(a => a.SkillName.ToLower().Contains(skillName.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                return new List<Skills>();
            }
        }
    }
}
