using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class utlisateurmodel
    {
        
        public string cin { get; set; }

        public string nom { get; set; }

        public virtual ICollection<job> job { get; set; }
    }
}