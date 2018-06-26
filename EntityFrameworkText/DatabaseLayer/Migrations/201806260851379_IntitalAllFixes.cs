namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntitalAllFixes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_absenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Motivata = c.Boolean(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Semestrul = c.Int(nullable: false),
                        MaterieID = c.Int(nullable: false),
                        ProfesorID = c.Int(nullable: false),
                        ElevID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_elev", t => t.ElevID, cascadeDelete: false)
                .ForeignKey("dbo.t_profesor", t => t.ProfesorID, cascadeDelete: false)
                .ForeignKey("dbo.t_materie", t => t.MaterieID, cascadeDelete: false)
                .Index(t => t.MaterieID)
                .Index(t => t.ProfesorID)
                .Index(t => t.ElevID);
            
            CreateTable(
                "dbo.t_elev",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        Date = c.DateTime(nullable: false),
                        Telefon = c.Int(nullable: false),
                        Email = c.String(),
                        Numar_Matricol = c.Int(nullable: false),
                        ClasaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_clasa", t => t.ClasaID, cascadeDelete: false)
                .Index(t => t.ClasaID);
            
            CreateTable(
                "dbo.t_clasa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numar = c.Int(nullable: false),
                        Serie = c.String(),
                        An = c.Int(nullable: false),
                        ProfilID = c.Int(nullable: false),
                        DiriginteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_profesor", t => t.DiriginteID, cascadeDelete: false)
                .ForeignKey("dbo.t_profil", t => t.ProfilID, cascadeDelete: false)
                .Index(t => t.ProfilID)
                .Index(t => t.DiriginteID);
            
            CreateTable(
                "dbo.t_profesor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        Prenume = c.String(),
                        Telefon = c.Int(nullable: false),
                        Email = c.String(),
                        IdMaterii = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_profesor_materie",
                c => new
                    {
                        MaterieID = c.Int(nullable: false),
                        ProfesorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaterieID, t.ProfesorID })
                .ForeignKey("dbo.t_materie", t => t.MaterieID, cascadeDelete: false)
                .ForeignKey("dbo.t_profesor", t => t.ProfesorID, cascadeDelete: false)
                .Index(t => t.MaterieID)
                .Index(t => t.ProfesorID);
            
            CreateTable(
                "dbo.t_materie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        Optional = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_nota",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nota = c.Double(nullable: false),
                        Teza = c.Boolean(nullable: false),
                        Semestrul = c.Int(nullable: false),
                        ElevID = c.Int(nullable: false),
                        MaterieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_elev", t => t.ElevID, cascadeDelete: false)
                .ForeignKey("dbo.t_materie", t => t.MaterieID, cascadeDelete: false)
                .Index(t => t.ElevID)
                .Index(t => t.MaterieID);
            
            CreateTable(
                "dbo.t_observatie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Text = c.String(),
                        ProfesorID = c.Int(nullable: false),
                        ElevID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_elev", t => t.ElevID, cascadeDelete: false)
                .ForeignKey("dbo.t_profesor", t => t.ProfesorID, cascadeDelete: false)
                .Index(t => t.ProfesorID)
                .Index(t => t.ElevID);
            
            CreateTable(
                "dbo.t_profil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_clasa", "ProfilID", "dbo.t_profil");
            DropForeignKey("dbo.t_elev", "ClasaID", "dbo.t_clasa");
            DropForeignKey("dbo.t_clasa", "DiriginteID", "dbo.t_profesor");
            DropForeignKey("dbo.t_observatie", "ProfesorID", "dbo.t_profesor");
            DropForeignKey("dbo.t_observatie", "ElevID", "dbo.t_elev");
            DropForeignKey("dbo.t_profesor_materie", "ProfesorID", "dbo.t_profesor");
            DropForeignKey("dbo.t_profesor_materie", "MaterieID", "dbo.t_materie");
            DropForeignKey("dbo.t_nota", "MaterieID", "dbo.t_materie");
            DropForeignKey("dbo.t_nota", "ElevID", "dbo.t_elev");
            DropForeignKey("dbo.t_absenta", "MaterieID", "dbo.t_materie");
            DropForeignKey("dbo.t_absenta", "ProfesorID", "dbo.t_profesor");
            DropForeignKey("dbo.t_absenta", "ElevID", "dbo.t_elev");
            DropIndex("dbo.t_observatie", new[] { "ElevID" });
            DropIndex("dbo.t_observatie", new[] { "ProfesorID" });
            DropIndex("dbo.t_nota", new[] { "MaterieID" });
            DropIndex("dbo.t_nota", new[] { "ElevID" });
            DropIndex("dbo.t_profesor_materie", new[] { "ProfesorID" });
            DropIndex("dbo.t_profesor_materie", new[] { "MaterieID" });
            DropIndex("dbo.t_clasa", new[] { "DiriginteID" });
            DropIndex("dbo.t_clasa", new[] { "ProfilID" });
            DropIndex("dbo.t_elev", new[] { "ClasaID" });
            DropIndex("dbo.t_absenta", new[] { "ElevID" });
            DropIndex("dbo.t_absenta", new[] { "ProfesorID" });
            DropIndex("dbo.t_absenta", new[] { "MaterieID" });
            DropTable("dbo.t_profil");
            DropTable("dbo.t_observatie");
            DropTable("dbo.t_nota");
            DropTable("dbo.t_materie");
            DropTable("dbo.t_profesor_materie");
            DropTable("dbo.t_profesor");
            DropTable("dbo.t_clasa");
            DropTable("dbo.t_elev");
            DropTable("dbo.t_absenta");
        }
    }
}
