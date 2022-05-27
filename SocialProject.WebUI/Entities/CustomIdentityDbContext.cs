using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.WebUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialProject.WebUI.Entities
{
    public class CustomIdentityDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options)
            : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Notfication> Notfications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Friend>()
                .HasOne(fs => fs.SenderUser)
                .WithMany(u => u.SenderUsers)
                .HasForeignKey(fs => fs.SenderId);

            builder.Entity<Friend>()
                .HasOne(fs => fs.ReceiverUser)
                .WithMany(u => u.FriendsUsers)
                .HasForeignKey(fs => fs.Id);

            builder.Entity<Notfication>()
                .HasOne(ns => ns.FromUser)
                .WithMany(i => i.FromNotfications)
                .HasForeignKey(cs => cs.FromUserId);

            builder.Entity<Notfication>()
                .HasOne(ns => ns.ToUser)
                .WithMany(i => i.ToNotfications)
                .HasForeignKey(cs => cs.ToUserId);
        }
         
        


    }

}

