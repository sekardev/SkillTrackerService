using SkillTrackerDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDb
{
  public  class AssociateSkillDb
    {
        MyContext db = null;
        public AssociateSkillDb()
        {
            db = new MyContext();
        }

        public List<AssociateVM> GetAll()
        {
            try
            {
                List<AssociateVM> results = new List<AssociateVM>();

                foreach (var item in db.Associates.ToList())
                {
                    List<AssociateSkillVM> associateskills = new List<AssociateSkillVM>();

                    associateskills = (from t1 in db.Associate_Skills
                                       join t2 in db.Skills
                                        on t1.Skill_ID equals t2.SkillId
                                       where t1.Associate_ID == item.Id 
                                       select new AssociateSkillVM
                                       {
                                           Associate_ID = t1.Associate_ID,
                                           Id = t1.Id,
                                           Rating = t1.Rating,
                                           SkillName = t2.SkillName,
                                           Skill_ID = t1.Skill_ID
                                       }).ToList();

                    string strongSkills = String.Join(",", associateskills.Where(a=>a.Rating>=15).Select(a => a.SkillName));


                    results.Add(new AssociateVM
                    {
                        Id = item.Id,
                        Associate_ID = item.Associate_ID,
                        Name = item.Name,
                        Gender = item.Gender,
                        Email = item.Email,
                        Level_1 = item.Level_1,
                        Level_2 = item.Level_2,
                        Level_3 = item.Level_3,
                        Mobile = item.Mobile,
                        Pic = item.Pic,
                        Remark = item.Remark,
                        Status_Blue = item.Status_Blue,
                        Status_Green = item.Status_Green,
                        Status_Red = item.Status_Red,
                        Strength = item.Strength,
                        Weakness = item.Weakness,
                        Skills = associateskills,
                        StrongSkills = strongSkills
                    });
                }
                return results;


            }
            catch (Exception ex)
            {
                return new List<AssociateVM>();
            }
        }


        public Associate_Skill CheckAssociateSkill(int Id)
        {
            try
            {
                Associate_Skill result = new Associate_Skill();
                result = db.Associate_Skills.FirstOrDefault(a => a.Skill_ID == Id); 
                if(result==null)
                {
                    result = new Associate_Skill();
                }
                return result;
            }
            catch (Exception ex)
            {
                return new Associate_Skill();
            }
        }

        public AssociateVM GetById(int Id)
        {
            try
            {
                AssociateVM result = new AssociateVM();

                foreach (var item in db.Associates.Where(a=>a.Id==Id).ToList())
                {
                    List<AssociateSkillVM> associateskills = new List<AssociateSkillVM>();

                    associateskills = (from t1 in db.Associate_Skills
                                       join t2 in db.Skills
                                        on t1.Skill_ID equals t2.SkillId
                                       where t1.Associate_ID == item.Id
                                       select new AssociateSkillVM
                                       {
                                           Associate_ID = t1.Associate_ID,
                                           Id = t1.Id,
                                           Rating = t1.Rating,
                                           SkillName = t2.SkillName,
                                           Skill_ID = t1.Skill_ID
                                       }).ToList();

                    string strongSkills = String.Join(",", associateskills.Where(a => a.Rating >= 15).Select(a => a.SkillName));


                    result = new AssociateVM()
                    {
                        Id = item.Id,
                        Associate_ID = item.Associate_ID,
                        Name = item.Name,
                        Gender = item.Gender,
                        Email = item.Email,
                        Level_1 = item.Level_1,
                        Level_2 = item.Level_2,
                        Level_3 = item.Level_3,
                        Mobile = item.Mobile,
                        Pic = item.Pic,
                        Remark = item.Remark,
                        Status_Blue = item.Status_Blue,
                        Status_Green = item.Status_Green,
                        Status_Red = item.Status_Red,
                        Strength = item.Strength,
                        Weakness = item.Weakness,
                        Skills = associateskills,
                        StrongSkills = strongSkills
                    };
                }
                return result;


            }
            catch (Exception ex)
            {
                return new AssociateVM();
            }
        }

        public bool Add(AssociateVM model)
        {
            try
            {
                if (model.Id > 0)
                {
                    Associate editAssociate = db.Associates.Find(model.Id);
                    db.Entry(editAssociate).CurrentValues.SetValues(model);
                    db.SaveChanges();

                    if (db.Associate_Skills.Any(a => a.Associate_ID == model.Id))
                    {
                        db.Associate_Skills.RemoveRange(db.Associate_Skills.Where(a => a.Associate_ID == model.Id).ToList());
                        db.SaveChanges();
                    }
                    foreach (AssociateSkillVM data in model.Skills)
                    {
                        db.Associate_Skills.Add(new Associate_Skill
                        {
                            Skill_ID = data.Skill_ID,
                            Associate_ID = model.Id,
                            Rating = data.Rating,
                            Created = DateTime.Now
                        });
                        db.SaveChanges();
                    }


                }
                else
                {
                    Associate associate = new Associate()
                    {                        
                        Associate_ID = model.Associate_ID,
                        Name = model.Name,
                        Gender = model.Gender,
                        Email = model.Email,
                        Level_1 = model.Level_1,
                        Level_2 = model.Level_2,
                        Level_3 = model.Level_3,
                        Mobile = model.Mobile,
                        Pic = model.Pic,
                        Remark = model.Remark,
                        Status_Blue = model.Status_Blue,
                        Status_Green = model.Status_Green,
                        Status_Red = model.Status_Red,
                        Strength = model.Strength,
                        Weakness = model.Weakness,
                        Created = DateTime.Now
                    };
                    db.Associates.Add(associate);
                    db.SaveChanges();
                    foreach (AssociateSkillVM data in model.Skills)
                    {
                        db.Associate_Skills.Add(new Associate_Skill
                        {
                            Skill_ID = data.Skill_ID,
                            Associate_ID = associate.Id,
                            Rating = data.Rating,
                            Created = DateTime.Now
                        });
                        db.SaveChanges();
                    }

                }

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
                Associate associate = db.Associates.FirstOrDefault(a => a.Associate_ID == Id);
                db.Associates.Remove(associate);
                if(db.Associate_Skills.Any(a=>a.Associate_ID==Id))
                {
                    db.Associate_Skills.RemoveRange(db.Associate_Skills.Where(a => a.Associate_ID == Id));
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
