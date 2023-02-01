namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_about_yetenek_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YetenekHeadings",
                c => new
                    {
                        YetenekHeadingId = c.Int(nullable: false, identity: true),
                        YetenekHeadingTitleName = c.String(),
                        YetenekHeadingName = c.String(),
                        YetenekHeadingUnvan = c.String(),
                        YetenekHeadingImg = c.String(),
                    })
                .PrimaryKey(t => t.YetenekHeadingId);
            
            CreateTable(
                "dbo.Yeteneklers",
                c => new
                    {
                        YeteneklerId = c.Int(nullable: false, identity: true),
                        YeteneklerName = c.String(maxLength: 150),
                        YeteneklerValue = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.YeteneklerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yeteneklers");
            DropTable("dbo.YetenekHeadings");
        }
    }
}
