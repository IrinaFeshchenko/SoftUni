using _5.Photographers.Attributes;
using System.Collections.Generic;

namespace _5.Photographers.Models
{
    public class Tag
    {
        public Tag()
        {
            Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Tag]
        public string Label { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
