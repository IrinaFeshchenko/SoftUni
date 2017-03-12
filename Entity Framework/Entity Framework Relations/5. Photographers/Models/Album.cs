namespace _5.Photographers.Models
{
    using System.Collections.Generic;

    public class Album
    {
        public Album()
        {
            Pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual Photographer Owner { get; set; }

        public int OwnerId { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
