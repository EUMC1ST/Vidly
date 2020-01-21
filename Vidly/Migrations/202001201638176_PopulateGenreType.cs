namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRETYPES(Name) VALUES('Action')");
            Sql("INSERT INTO GENRETYPES(Name) VALUES('Comedy')");
            Sql("INSERT INTO GENRETYPES(Name) VALUES('Romace')");
            Sql("INSERT INTO GENRETYPES(Name) VALUES('Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
