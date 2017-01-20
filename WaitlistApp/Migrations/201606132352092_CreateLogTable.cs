namespace WaitlistApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLogTable : DbMigration
    {
        public override void Up()
        {
            string createLogTable =
@"CREATE TABLE [Log] (
        [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Logged] [datetime] NOT NULL,
        [Level] [nvarchar](50) NOT NULL,
        [Message] [nvarchar](max) NOT NULL,
        [UserName] [nvarchar](250) NULL,
        [ServerName] [nvarchar](max) NULL,
        [Port] [nvarchar](max) NULL,
        [Url] [nvarchar](max) NULL,
        [Https] [bit] NULL,
        [ServerAddress] [nvarchar](100) NULL,
        [RemoteAddress] [nvarchar](100) NULL,
        [Logger] [nvarchar](250) NULL,
        [Callsite] [nvarchar](max) NULL,
        [Exception] [nvarchar](max) NULL
)";
            Sql(createLogTable);

            string insertLogStatement = 
@"CREATE PROCEDURE insertLogStatment
(
  @logged datetime,
  @level nvarchar(50),
  @message nvarchar(max),
  @userName nvarchar(250),
  @serverName nvarchar(max),
  @port nvarchar(max),
  @url nvarchar(max),
  @https bit,
  @serverAddress nvarchar(100),
  @remoteAddress nvarchar(100),
  @logger nvarchar(250),
  @callSite nvarchar(max),
  @exception nvarchar(max)
)
as

INSERT INTO Log(Logged, Level, Message, UserName, ServerName, Port, Url, Https, ServerAddress, RemoteAddress, Logger, CallSite, Exception)
VALUES (@logged, @level, @message, @userName, @serverName, @port, @url, @https, @serverAddress, @remoteAddress, @logger, @callSite, @exception);";
            Sql(insertLogStatement);
        }
        
        public override void Down()
        {
            Sql("DROP PROCEDURE insertLogStatment");
            DropTable("Log");
        }
    }
}
