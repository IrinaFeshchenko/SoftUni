namespace One_to_Many_Relation
{
    using System;

    public class Program
    {
         public static void Main()
        {
            AppDbContext context = new AppDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}