using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDb.Model
{
    [Table("Associate")]
    public class Associate
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "INT")]
        public int Id { get; set; }

        
        
        [Column("Associate_ID", TypeName = "INT")]
        public int Associate_ID { get; set; }


        [Column("Name", TypeName = "VARCHAR")]
        [StringLength(128)]
        public string Name { get; set; }

        [Column("Email", TypeName = "VARCHAR")]
        [StringLength(256)]
        public string Email { get; set; }

        [Column("Mobile", TypeName = "bigint")]
        public long Mobile { get; set; }

        [Column("Pic", TypeName = "VARCHAR")]
        [StringLength(128)]
        public string Pic { get; set; }


        [Column("Gender", TypeName = "VARCHAR")]
        [StringLength(1)]
        public string Gender { get; set; }


        [Column("Status_Green", TypeName = "BIT")]
        public bool Status_Green { get; set; }

        [Column("Status_Blue", TypeName = "BIT")]
        public bool Status_Blue { get; set; }


        [Column("Status_Red", TypeName = "BIT")]
        public bool Status_Red { get; set; }


        [Column("Level_1", TypeName = "INT")]
        public int Level_1 { get; set; }

        [Column("Level_2", TypeName = "INT")]
        public int Level_2 { get; set; }


        [Column("Level_3", TypeName = "INT")]
        public int Level_3 { get; set; }

        [Column("Remark", TypeName = "VARCHAR")]
        [StringLength(256)]
        public string Remark { get; set; }


        [Column("Strength", TypeName = "VARCHAR")]
        [StringLength(256)]
        public string Strength { get; set; }

        [Column("Weakness", TypeName = "VARCHAR")]
        [StringLength(256)]
        public string Weakness { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }


    }


    public class AssociateVM
    {

        public int Id { get; set; }

        public int Associate_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string Pic { get; set; }
        public string Gender { get; set; }
        public bool Status_Green { get; set; }
        public bool Status_Blue { get; set; }
        public bool Status_Red { get; set; }
        public int Level_1 { get; set; }
        public int Level_2 { get; set; }
        public int Level_3 { get; set; }
        public string Remark { get; set; }
        public string Strength { get; set; }
        public string Weakness { get; set; }
        public List<AssociateSkillVM> Skills { get; set; }

        public String StrongSkills { get; set; }


    }
}
