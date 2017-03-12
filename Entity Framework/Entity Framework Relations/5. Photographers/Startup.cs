using _5.Photographers.Data;
using _5.Photographers.Models;
using System.Data.Entity.Validation;
using System.Linq;

namespace _5.Photographers
{
    class Startup
    {
        static void Main()
        {
            var context = new PhotographerContext();
            Tag tag = new Tag() { Label = "#adf adfadf" };
            context.Tags.Add(tag);
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                tag.Label = TagTransformer.Transform(tag.Label);
                context.SaveChanges();
            }

           System.Console.WriteLine(context.Photographers.Count());
        }
    }
}
