namespace _5.Photographers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class albumsAndPictures1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "OwnerId", "dbo.Photographers");
            DropIndex("dbo.Albums", new[] { "OwnerId" });
            RenameColumn(table: "dbo.Albums", name: "OwnerId", newName: "Owner_Id");
            AlterColumn("dbo.Albums", "Owner_Id", c => c.Int());
            CreateIndex("dbo.Albums", "Owner_Id");
            AddForeignKey("dbo.Albums", "Owner_Id", "dbo.Photographers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Owner_Id", "dbo.Photographers");
            DropIndex("dbo.Albums", new[] { "Owner_Id" });
            AlterColumn("dbo.Albums", "Owner_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Albums", name: "Owner_Id", newName: "OwnerId");
            CreateIndex("dbo.Albums", "OwnerId");
            AddForeignKey("dbo.Albums", "OwnerId", "dbo.Photographers", "Id", cascadeDelete: true);
        }
    }
}
