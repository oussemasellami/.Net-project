namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public  class skills
    {
       
  
        
        [Key]
        public int idskill { get; set; }

       
        public string descreption { get; set; }

       
        public string note { get; set; }

       
        public string skillsname { get; set; }

       

        public virtual ICollection<job> jobs { get; set; }
    }
}
