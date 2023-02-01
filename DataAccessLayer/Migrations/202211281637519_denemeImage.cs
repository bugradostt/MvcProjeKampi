namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class denemeImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageFiles", "DenemeImage_ImageId", c => c.Int());
            CreateIndex("dbo.ImageFiles", "DenemeImage_ImageId");
            AddForeignKey("dbo.ImageFiles", "DenemeImage_ImageId", "dbo.ImageFiles", "ImageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageFiles", "DenemeImage_ImageId", "dbo.ImageFiles");
            DropIndex("dbo.ImageFiles", new[] { "DenemeImage_ImageId" });
            DropColumn("dbo.ImageFiles", "DenemeImage_ImageId");
        }
    }
}
