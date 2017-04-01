
namespace TeamBuilder.App
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommandHelper
    {
        bool IsTeamExisting(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName);
            }
        }

        bool IsUserExisting(string username)
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

        }

        bool IsUserCreatorOfEvent(string eventName, User user)
        {

        }

        bool IsMemberOfTeam(string teamName, string username)
        {

        }

        bool IsEventExisting(string eventName)
        {

        }

    }
}
