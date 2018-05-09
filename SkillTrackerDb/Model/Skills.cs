using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDb.Model
{
    [Table("Skills")]
    public class Skills
    {
        public Skills() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Skill_ID", TypeName = "INT")]
        public int SkillId { get; set; }



        [Column("Skill_Name", TypeName = "VARCHAR")]
        [StringLength(65)]
        public string SkillName { get; set; }


        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }



    }
}
