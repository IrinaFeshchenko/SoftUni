namespace Many_to_Many_Relation
{
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
