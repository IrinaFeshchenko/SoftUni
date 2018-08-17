using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SocialApp.Data
{
    public class SocialAppDbContext : IdentityDbContext
    {
        public SocialAppDbContext(DbContextOptions<SocialAppDbContext> options)
            : base(options)
        {
        }
    }
}
