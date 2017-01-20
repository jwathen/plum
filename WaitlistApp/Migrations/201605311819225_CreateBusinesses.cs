namespace WaitlistApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateBusinesses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Businesses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                    Account_EmailAddress = c.String(nullable: false, maxLength: 128),
                    Account_PasswordHash = c.String(nullable: false),
                    Account_PasswordSalt = c.String(nullable: false),
                    Account_PasswordIterations = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateIndex(
                name: "UK_Businesses_Account_EmailAddress",
                table: "Businesses",
                column: "Account_EmailAddress",
                unique: true);
        }

        public override void Down()
        {
            DropIndex("Businesses", "UK_Businesses_Account_EmailAddress");
            DropTable("Businesses");
        }
    }
}
