namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Image", c => c.String());
            AlterColumn("dbo.Manufacturers", "Logo", c => c.String());
            AlterColumn("dbo.ProductImages", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductImages", "Image", c => c.Binary());
            AlterColumn("dbo.Manufacturers", "Logo", c => c.Binary());
            AlterColumn("dbo.Categories", "Image", c => c.Binary());
        }
    }
}
