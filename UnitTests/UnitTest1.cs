using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainModel;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using UnitOfWork.Abstract;
using AutoMapper;
using NSubstitute;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        IQueryable<Advert> listAdvert;
        IQueryable<Subject> listSubject;
        DbSet<Advert> mockSetAdvert;
        DbSet<Subject> mockSetSubject;
        IMapper _mapper;
        IEFDbContext _context;

        [TestInitialize]
        [Owner("Mateusz Stanik")]
        public void initContext()
        {
            mockSetAdvert = Substitute.For<DbSet<Advert>, IQueryable<Advert>>();
            mockSetSubject = Substitute.For<DbSet<Subject>, IQueryable<Subject>>();

            //deklaracja oraz przypisanie wartości obiektom tymczasowej bazy danych 

            _mapper = Substitute.For<IMapper>();
            _context = Substitute.For<IEFDbContext>();

            _context.adverts.Returns(mockSetAdvert);
            _context.subjects.Returns(mockSetSubject);
        }

        [TestCleanup]
        public void cleanUpTest()
        {
            listAdvert = null;
            listSubject = null;
            mockSetAdvert = null;
            mockSetSubject = null;
            _mapper = null;
            _context = null;
        }

       
    }
}
