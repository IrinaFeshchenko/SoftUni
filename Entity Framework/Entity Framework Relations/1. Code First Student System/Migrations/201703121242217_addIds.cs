namespace _1.Code_First_Student_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIds : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Resources", name: "Course_Id", newName: "CourseId");
            RenameIndex(table: "dbo.Resources", name: "IX_Course_Id", newName: "IX_CourseId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Resources", name: "IX_CourseId", newName: "IX_Course_Id");
            RenameColumn(table: "dbo.Resources", name: "CourseId", newName: "Course_Id");
        }
    }
}
