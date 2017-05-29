namespace _5.Photographers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Owner_Id", "dbo.Photographers");
            DropIndex("dbo.Albums", new[] { "Owner_Id" });
            RenameColumn(table: "dbo.Albums", name: "Owner_Id", newName: "OwnerId");
            AlterColumn("dbo.Albums", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Albums", "OwnerId");
            AddForeignKey("dbo.Albums", "OwnerId", "dbo.Photographers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "OwnerId", "dbo.Photographers");
            DropIndex("dbo.Albums", new[] { "OwnerId" });
            AlterColumn("dbo.Albums", "OwnerId", c => c.Int());
            RenameColumn(table: "dbo.Albums", name: "OwnerId", newName: "Owner_Id");
            CreateIndex("dbo.Albums", "Owner_Id");
            AddForeignKey("dbo.Albums", "Owner_Id", "dbo.Photographers", "Id");
        }
    }
}
