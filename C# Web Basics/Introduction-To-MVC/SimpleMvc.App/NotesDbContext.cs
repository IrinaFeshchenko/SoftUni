namespace SimpleMvc.App
{
    using SimpleMvc.App.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NotesDbContext : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<User> Users { get; set; }

        public void SaveChanges()
        {

        }
    }
}
