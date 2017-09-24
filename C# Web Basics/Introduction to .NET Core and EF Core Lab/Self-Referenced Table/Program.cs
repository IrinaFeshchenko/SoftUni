namespace Self_Referenced_Table
{
    public class Program
    {
        public static void Main()
        {
            AppDbContext context = new AppDbContext();
            context.Database.EnsureCreated();
        }
    }
}
