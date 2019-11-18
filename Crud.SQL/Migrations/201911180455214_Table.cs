namespace Crud.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                        Category = c.String(),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Category = c.String(),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostCategories");
            DropTable("dbo.Posts");
        }
    }
}
