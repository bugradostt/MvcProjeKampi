namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_about_yetenek_update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.YetenekHeadings", "YetenekHeadingTitleName", c => c.String(maxLength: 150));
            AlterColumn("dbo.YetenekHeadings", "YetenekHeadingName", c => c.String(maxLength: 150));
            AlterColumn("dbo.YetenekHeadings", "YetenekHeadingUnvan", c => c.String(maxLength: 150));
            AlterColumn("dbo.YetenekHeadings", "YetenekHeadingImg", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.YetenekHeadings", "YetenekHeadingImg", c => c.String());
            AlterColumn("dbo.YetenekHeadings", "YetenekHeadingUnvan", c => c.String());
            AlterColumn("dbo.YetenekHeadings", "YetenekHeadingName", c => c.String());
            AlterColumn("dbo.YetenekHeadings", "YetenekHeadingTitleName", c => c.String());
        }
    }
}
