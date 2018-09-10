using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models.Profile
{
    public class AddContactsView
    {
        public IEnumerable<ContactView> Contacts  { get; set; }
    }
}
