using DiscussionBoard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiscussionBoard.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Forum> Forums { get; set; }
        public DbSet<DiscussionThread> DiscussionThreads { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DiscussionThread>()
                .HasOne(t => t.Forum)
                .WithMany(f => f.DiscussionThreads)
                .HasForeignKey(t => t.ForumId);

            builder.Entity<Post>()
                .HasOne(p => p.DiscussionThread)
                .WithMany(t => t.Posts)
                .HasForeignKey(p => p.DiscussionThreadId);

            builder.Entity<Post>()
                .HasOne(p => p.ParentPost)
                .WithMany(p => p.Replies)
                .HasForeignKey(p => p.ParentPostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DiscussionThread>()
                .HasOne(t => t.ApplicationUser)
                .WithMany(u => u.DiscussionThreads)
                .HasForeignKey(t => t.ApplicationUserId);

            builder.Entity<Post>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.ApplicationUserId);
        }
    }
}
