namespace RepositoryShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Person_Id", c => c.Long());
            CreateIndex("dbo.Properties", "Person_Id");
            AddForeignKey("dbo.Properties", "Person_Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "Person_Id", "dbo.People");
            DropIndex("dbo.Properties", new[] { "Person_Id" });
            DropColumn("dbo.Properties", "Person_Id");
            DropColumn("dbo.People", "Role");
        }
    }
}
