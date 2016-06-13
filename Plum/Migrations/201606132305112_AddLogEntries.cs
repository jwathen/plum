namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogEntries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "LogEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        Level = c.String(maxLength: 12, unicode: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("LogEntries");
        }
    }
}
