﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contactt_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "date");
        }
    }
}
