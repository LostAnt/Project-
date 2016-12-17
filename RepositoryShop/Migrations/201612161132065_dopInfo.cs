namespace RepositoryShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dopInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Login", c => c.String());
            AddColumn("dbo.People", "Email", c => c.String());
            AddColumn("dbo.People", "Password", c => c.String());
            AddColumn("dbo.People", "Birthdate", c => c.String());
            AddColumn("dbo.People", "Male", c => c.String());
            AddColumn("dbo.Properties", "Describe", c => c.String());
            AddColumn("dbo.People", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Role");
            DropColumn("dbo.Properties", "Describe");
            DropColumn("dbo.People", "Male");
            DropColumn("dbo.People", "Birthdate");
            DropColumn("dbo.People", "Password");
            DropColumn("dbo.People", "Email");
            DropColumn("dbo.People", "Login");
        }
    }
}
