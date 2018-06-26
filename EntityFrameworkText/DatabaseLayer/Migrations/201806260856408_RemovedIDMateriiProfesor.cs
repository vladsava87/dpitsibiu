namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedIDMateriiProfesor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.t_profesor", "IdMaterii");
        }
        
        public override void Down()
        {
            AddColumn("dbo.t_profesor", "IdMaterii", c => c.Int(nullable: false));
        }
    }
}
