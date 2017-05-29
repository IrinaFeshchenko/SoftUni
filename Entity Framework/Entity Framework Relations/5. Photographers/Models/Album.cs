namespace _5.Photographers.Models
{
    using System.Collections.Generic;

    public class Album
    {
        public Album()
        {
            Pictures = new HashSet<Picture>();
            Tags = new HashSet<Tag>();
            Photographers = new HashSet<PhotographerAlbum>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<PhotographerAlbum> Photographers { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
