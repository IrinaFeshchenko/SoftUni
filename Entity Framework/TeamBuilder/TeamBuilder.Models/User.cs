
namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum Gender
    {
        Male, Female
    }

    public class User
    {
        public User()
        {
            CreatedEvents = new HashSet<Event>();
            Teams = new HashSet<Team>();
            CreatedTeams = new HashSet<Team>();
            ReceivedInvitations = new HashSet<Invitation>();
        }

        public int Id { get; set; }

        [MinLength(3), MaxLength(25), Required, Index(IsUnique = true)]
        public string Username { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Event> CreatedEvents { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Team> CreatedTeams { get; set; }

        public virtual ICollection<Invitation> ReceivedInvitations { get; set; }
    }
}
