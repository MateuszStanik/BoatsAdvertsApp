using DomainModel;
using DomainModel.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Abstract
{
    public interface IEFDbContext : IDisposable
    {
        //---Entities
        DbSet<Advert> adverts { get; set; }
        DbSet<Subject> subjects { get; set; }
        DbSet<Engine> engines { get; set; }
        DbSet<Sail> sails { get; set; }
        DbSet<Boat> boats { get; set; }
        DbSet<Image> images { get; set; }
        //---Login entities
        DbSet<AspNetRoles> AspNetRoles { get; set; }
        DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        DbSet<AspNetUsers> AspNetUsers { get; set; }
        //---Dictionaries
        DbSet<DicCategories> dicCategories { get; set; }
        DbSet<DicYearbooks> dicYearbooks { get; set; }

        //Task<int> SaveChangesAsync();
    }
}
