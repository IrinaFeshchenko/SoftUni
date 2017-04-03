
namespace TeamBuilder.App.Utilities
{
    using Data;
    using Models;
    using System.Linq;

    public class CommandHelper
    {
        bool IsTeamExisting(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName);
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Users.Any(t => t.Username == username);
            }
        }

        bool IsInviteExisting(string teamName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Invitations.Any(i => i.team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive);
            }
        }

        bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName && t.Creator.Id == user.Id);
            }
        }

        bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Events.Any(e => e.Name == eventName && e.Creator.Id == user.Id);
            }
        }

        bool IsMemberOfTeam(string teamName, string username)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Teams.Any(t =>t.Name==teamName && t.Members.Any(m=>m.Username == username));
            }
        }

        bool IsEventExisting(string eventName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Events.Any(e=>e.Name == eventName);
            }
        }

    }
}
