namespace MVC_Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ParkedVehicles", name: "TypeId", newName: "Type");
            RenameIndex(table: "dbo.ParkedVehicles", name: "IX_TypeId", newName: "IX_Type");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ParkedVehicles", name: "IX_Type", newName: "IX_TypeId");
            RenameColumn(table: "dbo.ParkedVehicles", name: "Type", newName: "TypeId");
        }
    }
}
