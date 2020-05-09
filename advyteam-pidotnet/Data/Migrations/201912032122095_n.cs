namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.jobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        competencedef = c.String(unicode: false),
                        department = c.String(unicode: false),
                        description = c.String(unicode: false),
                        level = c.Int(nullable: false),
                        nom = c.String(unicode: false),
                        cin = c.Int(),
                        idskill = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.skills", t => t.idskill)
                .ForeignKey("dbo.utlisateurs", t => t.cin)
                .Index(t => t.cin)
                .Index(t => t.idskill);
            
            CreateTable(
                "dbo.skills",
                c => new
                    {
                        idskill = c.Int(nullable: false, identity: true),
                        descreption = c.String(unicode: false),
                        note = c.String(unicode: false),
                        skillsname = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.idskill);
            
            CreateTable(
                "dbo.utlisateurs",
                c => new
                    {
                        cin = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        email = c.String(unicode: false),
                        firstname = c.String(unicode: false),
                        lastname = c.String(unicode: false),
                        phoneNumber = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.cin);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.jobs", "cin", "dbo.utlisateurs");
            DropForeignKey("dbo.jobs", "idskill", "dbo.skills");
            DropIndex("dbo.jobs", new[] { "idskill" });
            DropIndex("dbo.jobs", new[] { "cin" });
            DropTable("dbo.utlisateurs");
            DropTable("dbo.skills");
            DropTable("dbo.jobs");
        }
    }
}
