namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers(Name,IsSubscribedToNewsletter,MembershipTypeId,BirthDay) VALUES('Luis Santos',1,(SELECT Id From MembershipTypes where Id = 1),null)");

        }

        public override void Down()
        {
        }
    }
}
