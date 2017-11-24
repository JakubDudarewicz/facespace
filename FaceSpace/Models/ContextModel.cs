using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ContextModel : DbContext
    {
        public ContextModel(): base("MigraInit")
        {
            Database.Initialize(false);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ActivityModel> Activity { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<FriendModel> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<aspnet_UsersInRoles>().HasMany(i => i.Users).WithRequired().WillCascadeOnDelete(false);


            //  base.OnModelCreating(modelBuilder);
            //     modelBuilder.Entity<aspnet_UsersInRoles>().HasMany(i => i.Users).WithRequired().WillCascadeOnDelete(false);

            modelBuilder.Entity<CommentModel>()
                .HasRequired<UserModel>(p => p.User)
                .WithMany(e => e.Comments)
                .HasForeignKey<int>(p => p.UserID);

            modelBuilder.Entity<FriendModel>()
                .HasRequired<UserModel>(p => p.User)
                .WithMany(e => e.Friends)
                .HasForeignKey<int>(p => p.UserID);

            modelBuilder.Entity<PostModel>()
               .HasRequired<UserModel>(p => p.User)
               .WithMany(e => e.Posts)
               .HasForeignKey<int>(p => p.UserID);

            modelBuilder.Entity<CommentModel>()
               .HasRequired<PostModel>(p => p.Post)
               .WithMany(e => e.Comments)
               .HasForeignKey<int>(p => p.PostID);

            modelBuilder.Entity<ActivityModel>()
               .HasOptional(p => p.User)
               .WithRequired(e => e.Activity);
        }

        }
    }