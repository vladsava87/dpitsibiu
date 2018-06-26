namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfilNameMissing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_profil", "Nume", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.t_profil", "Nume");
        }
    }
}
