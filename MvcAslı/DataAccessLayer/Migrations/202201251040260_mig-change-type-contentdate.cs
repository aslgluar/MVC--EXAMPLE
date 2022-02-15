namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migchangetypecontentdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "ContentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "ContentDate", c => c.String());
        }
    }
}
