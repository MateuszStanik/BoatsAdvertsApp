using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Abstract;

namespace UnitOfWork
{
    public class EFDbContext : DbContext, IEFDbContext
    {
        public EFDbContext() : base("name=BoatsAdverts")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        //---Entities
        public DbSet<Advert> adverts { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Engine> engines { get; set; }
        public DbSet<Sail> sails { get; set; }
        public DbSet<Boat> boats { get; set; }
        //---Login entities
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        //---Dictionaries
        public DbSet<DicCategories> dicCategories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(x => x.IsUnicode(false));
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<AspNetRoles>()
               .HasMany(e => e.AspNetUsers)
               .WithMany(e => e.AspNetRoles)
               .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);
        }

    }
}
