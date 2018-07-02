namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TelephoneNrToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_elev", "Prenume", c => c.String());
            AlterColumn("dbo.t_elev", "Telefon", c => c.String());
            AlterColumn("dbo.t_profesor", "Telefon", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.t_profesor", "Telefon", c => c.Int(nullable: false));
            AlterColumn("dbo.t_elev", "Telefon", c => c.Int(nullable: false));
            DropColumn("dbo.t_elev", "Prenume");
        }
    }
}
