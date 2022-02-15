namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontactdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContentDate");
        }
    }
}
