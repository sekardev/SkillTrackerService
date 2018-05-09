using SkillTrackerDb.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDb
{
    public class MyContext : DbContext
    {

        public MyContext() : base("SkillTracker_sekar")
        {
            Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
        }

        public DbSet<Skills> Skills { get; set; }
        public DbSet<Associate> Associates { get; set; }

        public DbSet<Associate_Skill> Associate_Skills { get; set; }




    }
}
