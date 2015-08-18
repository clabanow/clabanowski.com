namespace CLabanowski.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class security : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        RouteName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PortfolioProjects",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Technologies = c.String(),
                        Description = c.String(),
                        LinkUrl = c.String(),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PortfolioProjects");
            DropTable("dbo.BlogPosts");
        }
    }
}
