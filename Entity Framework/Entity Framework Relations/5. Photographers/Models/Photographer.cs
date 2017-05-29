namespace _5.Photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Photographer
    {
        public Photographer()
        {
            Albums = new HashSet<PhotographerAlbum>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegistereDate { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<PhotographerAlbum> Albums { get; set; }
    }
}
