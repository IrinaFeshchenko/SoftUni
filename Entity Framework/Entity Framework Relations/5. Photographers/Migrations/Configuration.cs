namespace _5.Photographers.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_5.Photographers.Data.PhotographerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_5.Photographers.Data.PhotographerContext context)
        {
            Photographer teo = new Photographer
            {
                Username = "teo",
                Password = "asdfadfadf",
                Email = "teo@softuni.bg",
                BirthDate = DateTime.Now,
                RegistereDate = DateTime.Now.AddDays(-20)
            };

            Photographer jim = new Photographer
            {
                Username = "jim",
                Password = "lkljklj",
                Email = "jim@softuni.bg",
                BirthDate = DateTime.Now,
                RegistereDate = DateTime.Now.AddDays(-20)
            };

            context.Photographers.AddOrUpdate(p=>p.Username,teo,jim);

            var demoPicture = new Picture()
            {
                Title = "Demo",
                Caption = "Demo",
                FileSystemPath = "../images/demo.png"
            };
            context.Pictures.AddOrUpdate(p=>p.Title, demoPicture);

            var vitosha = new Album()
            {
                Name = "Vitosha",
                BackgroundColor = "Black",
                IsPublic = true,
            };
            context.Albums.AddOrUpdate(a => a.Name, vitosha);
            vitosha.Pictures.Add(demoPicture);
            context.SaveChanges();

            PhotographerAlbum ph = new PhotographerAlbum()
            {
                Photographer_Id = teo.Id,
                Album_Id = vitosha.Id,
                Role = Role.Viewer
            };
            vitosha.Photographers.Add(ph);
            context.PhotographerAlbums.Add(ph);

            var mountainTag = new Tag()
            {
                Label = "#mountain"
            };

            context.Tags.AddOrUpdate(t => t.Label, mountainTag);
            mountainTag.Albums.Add(vitosha);
            context.SaveChanges();
        }
    }
}
