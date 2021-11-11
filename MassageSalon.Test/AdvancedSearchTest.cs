using MassageSalon.BLL.Extensions;
using MassageSalon.BLL.Interfaces;
using MassageSalon.BLL.Services;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using MassageSalon.DAL.EF.Contexts;
using MassageSalon.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MassageSalon.Test
{
    public class AdvancedSearchTest
    {
        public DbContextOptions<MassageSalonContext> OptionDb;

        [SetUp]
        public void Setup()
        {
            OptionDb = new DbContextOptionsBuilder<MassageSalonContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;
            using var context = new MassageSalonContext(OptionDb);

            context.RemoveRange(context.Records);
            context.RemoveRange(context.Masseurs);
            context.SaveChanges();

            context.Records.AddRange(GetRecords());
            context.Masseurs.AddRange(GetMasseurs());
            context.SaveChanges();
        }

        [TestCase("Egor", "1/1/0001 00:00:00 AM", "1/1/0001 00:00:00 AM", ExpectedResult = 2)]
        [TestCase("Alex", "1/1/0001 00:00:00 AM", "1/1/0001 00:00:00 AM", ExpectedResult = 3)]
        [TestCase("Andre", "1/1/0001 00:00:00 AM", "1/1/0001 00:00:00 AM", ExpectedResult = 1)]
        [TestCase("Anton", "1/1/0001 00:00:00 AM", "1/1/0001 00:00:00 AM", ExpectedResult = 6)]
        public int TestMasseurName(string masseurName, DateTime minDate, DateTime maxDate)
        {
            using var context = new MassageSalonContext(OptionDb);
            var repository = new GenericRepository<Record>(context);
            var masseurRepository = new GenericRepository<Masseur>(context);

            RecordService service = new RecordService(repository, masseurRepository);
            var actual = service.AdvancedSearch(masseurName, minDate, maxDate);
            return actual.Count();

        }

        [TestCase(null, "1/1/0001 00:00:00 AM", "11/11/2021 00:00:00 AM", ExpectedResult = 1)]
        [TestCase(null, "11/15/2021 00:00:00 AM", "11/17/2021 00:00:00 AM", ExpectedResult = 2)]
        [TestCase("Alex", "11/16/2021 05:00:00 AM", "11/26/2021 00:00:00 AM", ExpectedResult = 2)]
        [TestCase(null, "1/1/0001 00:00:00 AM", "1/1/0001 00:00:00 AM", ExpectedResult = 6)]
        public int TestTimeRecord(string masseurName, DateTime minDate, DateTime maxDate)
        {
            using var context = new MassageSalonContext(OptionDb);
            var repository = new GenericRepository<Record>(context);
            var masseurRepository = new GenericRepository<Masseur>(context);

            RecordService service = new RecordService(repository, masseurRepository);
            var actual = service.AdvancedSearch(masseurName, minDate, maxDate);
            return actual.Count();

        }
        private IEnumerable<Record> GetRecords()
        {
            var records = new List<Record>
            {
                new Record{Id = 1, MasseurId = 1, TimeRecord = new  DateTime(2021,11,10,2,30,0) },
                new Record{Id = 2, MasseurId = 2, TimeRecord = new  DateTime(2021,11,11,2,30,0) },
                new Record{Id = 3, MasseurId = 1, TimeRecord = new  DateTime(2021,11,11,3,30,0) },
                new Record{Id = 4, MasseurId = 3, TimeRecord = new  DateTime(2021,11,25,2,30,0) },
                new Record{Id = 5, MasseurId = 3, TimeRecord = new  DateTime(2021,11,16,2,30,0) },
                new Record{Id = 6, MasseurId = 3, TimeRecord = new  DateTime(2021,11,16,5,30,0) }
            };

            return records;
        }
        private IEnumerable<Masseur> GetMasseurs()
        {
            var masseurs = new List<Masseur>
            {
                new Masseur{Id =1, Name = "Egor", Surname = "Karas" },
                new Masseur{Id =2, Name = "Andrey", Surname = "Galin" },
                new Masseur{Id =3, Name = "Alex", Surname = "Karabut" }
            };

            return masseurs;
        }
    }
}