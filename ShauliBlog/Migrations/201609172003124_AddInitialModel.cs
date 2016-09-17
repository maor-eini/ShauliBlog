namespace ShauliBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        Title = c.String(),
                        Writer = c.String(),
                        WriterWebsite = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        AuthorWebsite = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Text = c.String(),
                        Image = c.String(),
                        Video = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        LastName = c.String(nullable: false, maxLength: 256),
                        Gender = c.String(nullable: false, maxLength: 1),
                        DateOfBirth = c.DateTime(nullable: false),
                        SeniorityInYears = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropTable("dbo.Fans");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
