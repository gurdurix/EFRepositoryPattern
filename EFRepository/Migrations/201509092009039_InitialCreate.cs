namespace EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        UserProfileId = c.Guid(nullable: false),
                        Active = c.Boolean(nullable: false, defaultValueSql: "1"),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false, defaultValueSql: "1"),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(),
                        CreatedBy = c.Guid(nullable: false),
                        UpdatedBy = c.Guid(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "UserProfileId", "dbo.UserProfile");
            DropIndex("dbo.User", new[] { "UserProfileId" });
            DropTable("dbo.UserProfile");
            DropTable("dbo.User");
        }
    }
}
