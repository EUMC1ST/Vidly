namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReleaseDateToMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MOVIES(Name,GenreTypeId,ReleaseDate)VALUES('IT',(SELECT Id from Genretypes where name = 'Horror'),'2019-08-10')");
        }
        
        public override void Down()
        {
        }
    }
}
