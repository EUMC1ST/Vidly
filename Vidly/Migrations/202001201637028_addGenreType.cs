namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenreType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre_IdGenre");
            DropColumn("dbo.Movies", "Genre_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre_Name", c => c.String());
            AddColumn("dbo.Movies", "Genre_IdGenre", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            DropTable("dbo.GenreTypes");
        }
    }
}
