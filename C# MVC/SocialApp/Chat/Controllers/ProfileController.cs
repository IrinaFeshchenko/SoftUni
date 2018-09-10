using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Chat.Models.Profile;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Chat.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private SocialAppDbContext db;

        private string currentUserId;

        public ProfileController(SocialAppDbContext db)
        {
            this.db = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Get user id   
            this.currentUserId = currentUserId ?? this.db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();
        }

        public IActionResult Index()
        {
            var currentUser = this.db.Users.Where(u => u.Id == this.currentUserId)
                .Select(u => new
                {
                    nickName = u.NickName,
                    avatar = u.Avatar,
                    registeredOn = u.RegisteredOn,
                    contacts = u.Contacts.Select(ur => new ContactView
                    {
                        Id = ur.Friend.Id,
                        Avatar = ur.Friend.Avatar,
                        NickName = ur.Friend.NickName
                    })
                })
                .First();

            var model = new ProfileIndexView()
            {
                Id = this.currentUserId,
                NickName = currentUser.nickName,
                Avatar = currentUser.avatar,
                RegisteredOn = currentUser.registeredOn.ToShortDateString(),
                Contacts = currentUser.contacts
            };

            return View(model);
        }

        public IActionResult AddContacts()
        {
            var users = new AddContactsView()
            {
                Contacts = db.Users
                        .Where(u => u.Id != this.currentUserId)
                        .Select(u => new ContactView
                        {
                            Id = u.Id,
                            Avatar = u.Avatar,
                            NickName = u.NickName
                        })
                        .ToList()
            };

            return View(users);
        }

        [HttpPost]
        public IActionResult AddToContacts(string FriendId)
        {
            if (!db.Contacts.Any(c => c.UserId == this.currentUserId && c.FriendId == FriendId))
            {
                var contact = new Data.Models.Contact
                {
                    UserId = this.currentUserId,
                    FriendId = FriendId
                };

                db.Add(contact);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpPost]
        public ActionResult AjaxGetProfileInfo(string selectedId)
        {
            if (selectedId == null)
            {
                return null;
            }

            var selectedUser = this.db.Users.Where(u => u.Id == selectedId)
               .Select(u => new
               {
                   name = u.NickName,
                   email = u.Email,
                   avatar = u.Avatar,
                   registeredOn = u.RegisteredOn.ToShortDateString(),
                   contactsCount = u.Contacts.Count()
               })
               .First();

            return Json(selectedUser);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AjaxRemoveContact(string contactId, string userId)
        {
            if (contactId == null || userId == null)
            {
                return null;
            }

            var contact = db.Contacts.FirstOrDefault(c => (c.UserId == userId) && (c.FriendId == contactId));

            if (contact == null)
            {
                return null;
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return Json("success");
        }
    }
}