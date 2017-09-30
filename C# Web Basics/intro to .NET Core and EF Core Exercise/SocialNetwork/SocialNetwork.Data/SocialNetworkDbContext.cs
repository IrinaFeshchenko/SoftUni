namespace SocialNetwork.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public class SocialNetworkDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server = COMP\SQLEXPRESS; Database = SocialNetworkDb; Integrated Security = true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Friendship>()
                .HasKey(f => new
                {
                    f.FromUserId,
                    f.ToUserId
                });

            builder
                .Entity<User>()
                .HasMany(u => u.FromFriends)
                .WithOne(u => u.FromUser)
                .HasForeignKey(u => u.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<User>()
                .HasMany(u => u.ToFriends)
                .WithOne(f => f.ToUser)
                .HasForeignKey(u => u.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var serviceProvider = this.GetService<IServiceProvider>();

            var items = new Dictionary<object, object>();

            foreach (var entry in this.ChangeTracker.Entries().Where(e => (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
                {
                    var entity = entry.Entity;

                    var context = new ValidationContext(entity, serviceProvider, items);

                    var results = new List<ValidationResult>();

                if (Validator.TryValidateObject(entity, context, results, true) == false)
                {
                    foreach (var result in results)
                    {
                        if (result != ValidationResult.Success)
                        {
                            throw new ValidationException(result.ErrorMessage);
                        }
                    }
                }
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}