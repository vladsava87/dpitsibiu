namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaterieNametoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.t_materie", "Nume", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.t_materie", "Nume", c => c.Int(nullable: false));
        }
    }
}
