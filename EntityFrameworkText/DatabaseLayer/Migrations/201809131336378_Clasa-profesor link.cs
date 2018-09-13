namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clasaprofesorlink : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_profesor_clasa",
                c => new
                    {
                        ClasaID = c.Int(nullable: false),
                        ProfesorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClasaID, t.ProfesorID })
                .ForeignKey("dbo.t_clasa", t => t.ClasaID, cascadeDelete: false)
                .ForeignKey("dbo.t_profesor", t => t.ProfesorID, cascadeDelete: false)
                .Index(t => t.ClasaID)
                .Index(t => t.ProfesorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_profesor_clasa", "ProfesorID", "dbo.t_profesor");
            DropForeignKey("dbo.t_profesor_clasa", "ClasaID", "dbo.t_clasa");
            DropIndex("dbo.t_profesor_clasa", new[] { "ProfesorID" });
            DropIndex("dbo.t_profesor_clasa", new[] { "ClasaID" });
            DropTable("dbo.t_profesor_clasa");
        }
    }
}
