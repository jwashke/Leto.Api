namespace Leto.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Users", "PasswordHash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "Password");
        }
    }
}
