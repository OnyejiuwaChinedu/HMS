namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicEntities : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccomodationTypes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AccomodationTypes", "Description", c => c.Int(nullable: false));
        }
    }
}
