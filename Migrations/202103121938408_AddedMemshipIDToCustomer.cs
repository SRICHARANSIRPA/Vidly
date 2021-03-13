namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMemshipIDToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MemberShipId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MemberShipId");
        }
    }
}
