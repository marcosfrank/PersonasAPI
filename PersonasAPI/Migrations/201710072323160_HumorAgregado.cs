namespace PersonasAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HumorAgregado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "Humor", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personas", "Humor");
        }
    }
}
