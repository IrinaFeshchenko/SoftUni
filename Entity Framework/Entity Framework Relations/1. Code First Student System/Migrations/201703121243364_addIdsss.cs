namespace _1.Code_First_Student_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIdsss : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Licenses", name: "Resource_Id", newName: "ResourceId");
            RenameIndex(table: "dbo.Licenses", name: "IX_Resource_Id", newName: "IX_ResourceId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Licenses", name: "IX_ResourceId", newName: "IX_Resource_Id");
            RenameColumn(table: "dbo.Licenses", name: "ResourceId", newName: "Resource_Id");
        }
    }
}
