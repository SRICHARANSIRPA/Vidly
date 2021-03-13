﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberShiptypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShiptypes (SignUpFee,DurationInMonths,DiscountRate) VALUES(0,0,0)");
            Sql("INSERT INTO MemberShiptypes (SignUpFee,DurationInMonths,DiscountRate) VALUES(30,1,10)");
            Sql("INSERT INTO MemberShiptypes (SignUpFee,DurationInMonths,DiscountRate) VALUES(90,3,15)");
            Sql("INSERT INTO MemberShiptypes (SignUpFee,DurationInMonths,DiscountRate) VALUES(100,4,20)");
        }
        
        public override void Down()
        {
        }
    }
}
