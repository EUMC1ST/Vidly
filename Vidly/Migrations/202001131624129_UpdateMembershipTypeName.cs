namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE MembershipTypes SET Name = 'Pay as you go' WHERE SignUpFee = 0");
            Sql(@"UPDATE MembershipTypes SET Name = 'Monthly' WHERE SignUpFee = 30");
            Sql(@"UPDATE MembershipTypes SET Name = 'Quarterly' WHERE SignUpFee = 90");
            Sql(@"UPDATE MembershipTypes SET Name = 'Annual go' WHERE SignUpFee = 300");
        }
        
        public override void Down()
        {
        }
    }
}
