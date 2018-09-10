using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models.Profile
{
    public class ProfileIndexView
    {
        public string Id { get; set; }
        public string Avatar { get; set; }

        public string NickName { get; set; }

        public string RegisteredOn { get; set; }

        public IEnumerable<ContactView> Contacts { get; set; }
    }
}