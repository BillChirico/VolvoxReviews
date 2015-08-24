namespace Volvox.Reviews.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Products", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Reviews", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Reviews", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reviews", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
