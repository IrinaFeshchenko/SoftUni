using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CameraBazaar.Data.Models
{
    public class User : IdentityUser
    {
        public List<Camera> Cameras { get; set; }
    }
}
