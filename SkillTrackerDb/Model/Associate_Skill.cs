using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDb.Model
{
    [Table("Associate_Skill")]
    public class Associate_Skill
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "INT")]
        public int Id { get; set; }

        [ForeignKey("Associate")]
        [Column("Associate_ID", TypeName = "INT")]
        public int Associate_ID { get; set; }

        [ForeignKey("Skills")]
        [Column("Skill_ID", TypeName = "INT")]
        public int Skill_ID { get; set; }

        [Column("Rating", TypeName = "INT")]
        public int Rating { get; set; }


        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }


        public Associate Associate { get; set; }

        public Skills Skills { get; set; }

    }

    public class AssociateSkillVM
    {
        public int Id { get; set; }
        public int Associate_ID { get; set; }
        public int Skill_ID { get; set; }
        public string SkillName { get; set; }
        public int Rating { get; set; }
    }

}
