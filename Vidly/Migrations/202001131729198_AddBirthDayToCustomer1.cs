namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDayToCustomer1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE Customers Set BirthDay = '1993-02-05' where name = 'Mary Williams'");
        }
        
        public override void Down()
        {
        }
    }
}
