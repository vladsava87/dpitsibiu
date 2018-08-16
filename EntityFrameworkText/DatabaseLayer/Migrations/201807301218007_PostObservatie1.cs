namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostObservatie1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_elev", "Data", c => c.DateTime(nullable: false));
            AddColumn("dbo.t_elev", "Parola", c => c.String());
            AddColumn("dbo.t_profesor", "Parola", c => c.String());
            DropColumn("dbo.t_elev", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.t_elev", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.t_profesor", "Parola");
            DropColumn("dbo.t_elev", "Parola");
            DropColumn("dbo.t_elev", "Data");
        }
    }
}
