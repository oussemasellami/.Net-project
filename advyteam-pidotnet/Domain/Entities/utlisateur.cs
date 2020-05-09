using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class utlisateur
    {

        [Key]
        public int cin { get; set; }

        public string Name { get; set; }

      
        public string email { get; set; }

       
        public string firstname { get; set; }

        

     
        public string lastname { get; set; }

       

        
        public string phoneNumber { get; set; }

        public virtual ICollection<job> jobs { get; set; }

       
       
    }
}
