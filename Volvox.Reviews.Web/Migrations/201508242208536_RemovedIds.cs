namespace Volvox.Reviews.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedIds : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "MovieId");
            DropColumn("dbo.Products", "TelevisionShowId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "TelevisionShowId", c => c.Int());
            AddColumn("dbo.Products", "MovieId", c => c.Int());
        }
    }
}
