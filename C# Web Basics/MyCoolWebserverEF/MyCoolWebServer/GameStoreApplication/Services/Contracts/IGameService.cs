namespace MyCoolWebServer.GameStoreApplication.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;

    public interface IGameService
    {
        void Create(string title, string description, string image, decimal price, DateTime releaseDate, double size, string videoId);

        IEnumerable<AdminListGameViewModel> All();
    }
}
