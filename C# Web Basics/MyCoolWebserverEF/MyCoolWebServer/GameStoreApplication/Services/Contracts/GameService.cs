namespace MyCoolWebServer.GameStoreApplication.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MyCoolWebServer.GameStoreApplication.Data;
    using MyCoolWebServer.GameStoreApplication.Models;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;

    public class GameService : IGameService
    {
        public void Create(string title, string description, string image, decimal price, DateTime releaseDate, double size, string videoId)
        {
            using (var db = new GameStoreDbContext())
            {
                var game = new Game
                               {
                                   Title = title,
                                   Description = description,
                                   Image = image,
                                   Price = price,
                                   ReleaseDate = releaseDate,
                                   Size = size,
                                   VideoId = videoId
                               };
                db.Add(game);
                db.SaveChanges();
            }
        }

        public IEnumerable<AdminListGameViewModel> All()
        {
            using (var db = new GameStoreDbContext())
            {
                return db
                    .Games
                    .Select(g => new AdminListGameViewModel
                                     {
                                         Id = g.Id,
                                         Name = g.Title,
                                         Price = g.Price,
                                         Size = g.Size
                                     })
                                     .ToList();
            }
        }
    }
}
