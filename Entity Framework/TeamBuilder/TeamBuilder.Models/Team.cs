
namespace TeamBuilder.Models
{
    using System.Collections.Generic;

    public class Team
    {
        public Team()
        {
            Members = new HashSet<User>();
            ParticipatedEvents = new HashSet<Event>();
            Invitations = new HashSet<Invitation>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Desctiption { get; set; }

        public string Acronim { get; set; }

        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public ICollection<User> Members { get; set; }

        public ICollection<Event> ParticipatedEvents { get; set; }

        public ICollection<Invitation> Invitations { get; set; }
    }
}
