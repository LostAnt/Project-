namespace RepositoryShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyId = c.Long(nullable: false, identity: true),
                        Bedrooms = c.Int(nullable: false),
                        Bathrooms = c.Int(nullable: false),
                        LivArea = c.Double(nullable: false),
                        LandArea = c.Double(nullable: false),
                        Price = c.Long(nullable: false),
                        Type = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.PropertyId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Buyer = c.String(),
                        Seller = c.String(),
                        Property = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Purchases");
            DropTable("dbo.Properties");
            DropTable("dbo.People");
        }
    }
}
