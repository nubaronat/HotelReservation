namespace EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VeriTabaniGüncellemesi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Hotels", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Hotels", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Hotels", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Hotels", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Hotels", "Country", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Hotels", "Phone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Hotels", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Reservations", "TotalPrice", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Rooms", "Price", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Reservations", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Hotels", "Email", c => c.String());
            AlterColumn("dbo.Hotels", "Phone", c => c.String());
            AlterColumn("dbo.Hotels", "Country", c => c.String());
            AlterColumn("dbo.Hotels", "City", c => c.String());
            AlterColumn("dbo.Hotels", "Address", c => c.String());
            AlterColumn("dbo.Hotels", "Description", c => c.String());
            AlterColumn("dbo.Hotels", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
