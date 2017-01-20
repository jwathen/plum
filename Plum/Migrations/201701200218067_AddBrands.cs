namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrands : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Name = c.String(),
                        BrandColor = c.String(),
                        JumboColor = c.String(),
                        JumboImage = c.Binary(),
                        FontUrl = c.String(),
                        FontName = c.String(),
                        DomainNames = c.String()
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("Brands");
        }
    }
}
