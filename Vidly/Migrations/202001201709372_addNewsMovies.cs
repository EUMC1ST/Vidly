namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewsMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MOVIES(Name,GenreTypeId,ReleaseDate)VALUES('MadMax',(SELECT Id from Genretypes where name = 'Action'),'2019-08-10')");
            Sql("INSERT INTO MOVIES(Name,GenreTypeId,ReleaseDate)VALUES('IT',(SELECT Id from Genretypes where name = 'Horror'),'2019-08-10')");
            Sql("INSERT INTO MOVIES(Name,GenreTypeId,ReleaseDate)VALUES('Booksmart',(SELECT Id from Genretypes where name = 'Comedy'),'2019-08-10')");

        }
        
        public override void Down()
        {
        }
    }
}
