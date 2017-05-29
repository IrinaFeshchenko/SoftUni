
namespace MassDefect.App
{
    using Data;

    class Startup
    {
        static void Main()
        {
            var context = new MassDefectContext();
            context.Database.Initialize(true);
        }
    }
}
