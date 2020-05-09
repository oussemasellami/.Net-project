namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Entities;
    using Data.Configurations;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {

            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());


        }

       
        public virtual DbSet<utlisateur> Utilisateur { get; set; }
       
        public virtual DbSet<skills> skills { get; set; }
        public virtual DbSet<job> jobs { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            
            modelBuilder.Configurations.Add(new productConfuguration());

            

           

            modelBuilder.Entity<skills>()
                .Property(e => e.descreption)
                .IsUnicode(false);

            modelBuilder.Entity<skills>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<skills>()
                .Property(e => e.skillsname)
                .IsUnicode(false);

          
           


        }
    }
}
