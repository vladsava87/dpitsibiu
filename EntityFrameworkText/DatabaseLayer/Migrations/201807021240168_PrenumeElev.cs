namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrenumeElev : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.t_nota", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.t_nota", "Data");
        }
    }
}
