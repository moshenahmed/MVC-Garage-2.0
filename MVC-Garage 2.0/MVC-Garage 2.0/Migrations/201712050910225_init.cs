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
                        Type = c.String(),
                        RegNumber = c.String(),
                        Colour = c.String(),
                        Brand = c.String(),
                        Model = c.String(),
                        NoOfWheels = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParkedVehicles");
        }
    }
}
