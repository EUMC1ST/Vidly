namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMoviesGenreAndReleaseDate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre_IdGenre = c.Int(nullable: false),
                        Genre_Name = c.String(),
                        GenreTypeId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
