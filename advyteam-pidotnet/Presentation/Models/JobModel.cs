using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Models
{
    public class JobModel
    {
        

        [StringLength(255)]
        public string competencedef { get; set; }

        [StringLength(255)]
        public string department { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int level { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        public virtual utlisateur utlisateur { get; set; }
        //? nullable
        //FK 2/2
        [Display(Name ="choisir l utilisateur a affecter ")]
        public int cin { get; set; }
        
        public IEnumerable<SelectListItem> utilisateurs { get; set; }

        
        public virtual skills skills { get; set; }
        //? nullable
        //FK 2/2
        [Display(Name = "choisir le skills a affecter ")]
        public int idskill { get; set; }

        public IEnumerable<SelectListItem> listSkills { get; set; }
    }
}