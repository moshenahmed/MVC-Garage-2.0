namespace MVC_Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        RegNumber = c.String(nullable: false, maxLength: 50),
                        Colour = c.String(),
                        Brand = c.String(),
                        Model = c.String(),
                        NoOfWheels = c.Int(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.MemberId)
                .Index(t => t.RegNumber, unique: true, name: "Ix_RegNum");
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Personnumber = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        TelephoneNumber = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicles", "TypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.ParkedVehicles", "MemberId", "dbo.Members");
            DropIndex("dbo.ParkedVehicles", "Ix_RegNum");
            DropIndex("dbo.ParkedVehicles", new[] { "MemberId" });
            DropIndex("dbo.ParkedVehicles", new[] { "TypeId" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Members");
            DropTable("dbo.ParkedVehicles");
        }
    }
}
