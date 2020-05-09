using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class SkillsModels
    {
        [Key]
        public int idskill { get; set; }

        [StringLength(255)]
        public string descreption { get; set; }

        [StringLength(255)]
        public string note { get; set; }

        [StringLength(255)]
        public string skillsname { get; set; }
    }
}