namespace _5.Photographers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class albumsAndPictures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "Caption", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pictures", "Caption");
        }
    }
}
