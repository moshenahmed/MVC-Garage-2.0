namespace MVC_Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "DateOfBirth", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ParkedVehicles", "CheckIn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.VehicleTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleTypes", "Name", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "CheckIn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Members", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
