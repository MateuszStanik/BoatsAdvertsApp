using DomainModel;
using DomainModel.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
            Database.SetInitializer<EFDbContext>(null);

            this.Configuration.LazyLoadingEnabled = true;
        }
        //---Entities
        public DbSet<Advert> adverts { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Engine> engines { get; set; }
        public DbSet<Sail> sails { get; set; }
        public DbSet<Boat> boats { get; set; }
        public DbSet<Image> images { get; set; }
        //---Login entities
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        //---Dictionaries
        public DbSet<DicCategories> dicCategories { get; set; }
        public DbSet<DicYearbooks> dicYearbooks { get; set; }
        //public override Task<int> SaveChangesAsync()
        //{
        //    try
        //    {
        //        return base.SaveChangesAsync();

        //    }
        //    catch(DbEntityValidationException ex)
        //    {
        //        var exMessage = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Aggregate(String.Empty, (current, error) => current + String.Format("{0}: {1}\n", error.PropertyName, error.ErrorMessage));
        //        throw new DbEntityValidationException(exMessage, ex.EntityValidationErrors);
        //    }
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties<string>().Configure(x => x.IsUnicode(false));


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
