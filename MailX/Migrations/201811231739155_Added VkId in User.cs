namespace MailX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVkIdinUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "VkId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "VkId");
        }
    }
}
