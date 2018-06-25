namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        IdMaterie = c.Int(nullable: false),
                        IdProfesor = c.Int(nullable: false),
                        IdElev = c.Int(nullable: false),
                        Elev_Id = c.Int(),
                        Materie_Id = c.Int(),
                        Profesor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_elev", t => t.Elev_Id)
                .ForeignKey("dbo.t_materie", t => t.Materie_Id)
                .ForeignKey("dbo.t_profesor", t => t.Profesor_Id)
                .Index(t => t.Elev_Id)
                .Index(t => t.Materie_Id)
                .Index(t => t.Profesor_Id);
            
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
                        Clasa = c.Int(nullable: false),
                        t_clasa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_clasa", t => t.t_clasa_Id)
                .Index(t => t.t_clasa_Id);
            
            CreateTable(
                "dbo.t_nota",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nota = c.Double(nullable: false),
                        Teza = c.Boolean(nullable: false),
                        Semestrul = c.Int(nullable: false),
                        IdElev = c.Int(nullable: false),
                        IdMaterie = c.Int(nullable: false),
                        Elev_Id = c.Int(),
                        Materie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_elev", t => t.Elev_Id)
                .ForeignKey("dbo.t_materie", t => t.Materie_Id)
                .Index(t => t.Elev_Id)
                .Index(t => t.Materie_Id);
            
            CreateTable(
                "dbo.t_materie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.Int(nullable: false),
                        Optional = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_profesor_materie",
                c => new
                    {
                        IdMaterie = c.Int(nullable: false),
                        IdProfesor = c.Int(nullable: false),
                        Materie_Id = c.Int(),
                        Profesor_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdMaterie, t.IdProfesor })
                .ForeignKey("dbo.t_materie", t => t.Materie_Id)
                .ForeignKey("dbo.t_profesor", t => t.Profesor_Id)
                .Index(t => t.Materie_Id)
                .Index(t => t.Profesor_Id);
            
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
                "dbo.t_observatie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Text = c.String(),
                        IdProfesor = c.Int(nullable: false),
                        IdElev = c.Int(nullable: false),
                        Elev_Id = c.Int(),
                        Profesor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_elev", t => t.Elev_Id)
                .ForeignKey("dbo.t_profesor", t => t.Profesor_Id)
                .Index(t => t.Elev_Id)
                .Index(t => t.Profesor_Id);
            
            CreateTable(
                "dbo.t_clasa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numar = c.Int(nullable: false),
                        Serie = c.String(),
                        An = c.Int(nullable: false),
                        IdProfil = c.Int(nullable: false),
                        IdProfesor = c.Int(nullable: false),
                        Diriginte_Id = c.Int(),
                        Profil_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_profesor", t => t.Diriginte_Id)
                .ForeignKey("dbo.t_profil", t => t.Profil_Id)
                .Index(t => t.Diriginte_Id)
                .Index(t => t.Profil_Id);
            
            CreateTable(
                "dbo.t_profil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_clasa", "Profil_Id", "dbo.t_profil");
            DropForeignKey("dbo.t_elev", "t_clasa_Id", "dbo.t_clasa");
            DropForeignKey("dbo.t_clasa", "Diriginte_Id", "dbo.t_profesor");
            DropForeignKey("dbo.t_observatie", "Profesor_Id", "dbo.t_profesor");
            DropForeignKey("dbo.t_observatie", "Elev_Id", "dbo.t_elev");
            DropForeignKey("dbo.t_profesor_materie", "Profesor_Id", "dbo.t_profesor");
            DropForeignKey("dbo.t_absenta", "Profesor_Id", "dbo.t_profesor");
            DropForeignKey("dbo.t_profesor_materie", "Materie_Id", "dbo.t_materie");
            DropForeignKey("dbo.t_nota", "Materie_Id", "dbo.t_materie");
            DropForeignKey("dbo.t_absenta", "Materie_Id", "dbo.t_materie");
            DropForeignKey("dbo.t_nota", "Elev_Id", "dbo.t_elev");
            DropForeignKey("dbo.t_absenta", "Elev_Id", "dbo.t_elev");
            DropIndex("dbo.t_clasa", new[] { "Profil_Id" });
            DropIndex("dbo.t_clasa", new[] { "Diriginte_Id" });
            DropIndex("dbo.t_observatie", new[] { "Profesor_Id" });
            DropIndex("dbo.t_observatie", new[] { "Elev_Id" });
            DropIndex("dbo.t_profesor_materie", new[] { "Profesor_Id" });
            DropIndex("dbo.t_profesor_materie", new[] { "Materie_Id" });
            DropIndex("dbo.t_nota", new[] { "Materie_Id" });
            DropIndex("dbo.t_nota", new[] { "Elev_Id" });
            DropIndex("dbo.t_elev", new[] { "t_clasa_Id" });
            DropIndex("dbo.t_absenta", new[] { "Profesor_Id" });
            DropIndex("dbo.t_absenta", new[] { "Materie_Id" });
            DropIndex("dbo.t_absenta", new[] { "Elev_Id" });
            DropTable("dbo.t_profil");
            DropTable("dbo.t_clasa");
            DropTable("dbo.t_observatie");
            DropTable("dbo.t_profesor");
            DropTable("dbo.t_profesor_materie");
            DropTable("dbo.t_materie");
            DropTable("dbo.t_nota");
            DropTable("dbo.t_elev");
            DropTable("dbo.t_absenta");
        }
    }
}
