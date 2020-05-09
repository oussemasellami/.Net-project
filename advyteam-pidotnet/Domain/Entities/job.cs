namespace Data
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class job
    {
        
        [Key]
        public int id { get; set; }

        
        public string competencedef { get; set; }

        
        public string department { get; set; }

        
        public string description { get; set; }

        public int level { get; set; }

    
        public string nom { get; set; }

        public virtual utlisateur utlisateur { get; set; }
        //? nullable
        //FK 2/2
        
        
        [ForeignKey("utlisateur")]
        public int? cin { get; set; }


            
            /// /////////////////////////////////////////////////
            

        public virtual skills skills { get; set; }
        //? nullable
        //FK 2/2


        [ForeignKey("skills")]
        public int? idskill { get; set; }

    }
}
