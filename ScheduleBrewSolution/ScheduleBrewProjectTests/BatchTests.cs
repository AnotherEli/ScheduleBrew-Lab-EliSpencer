using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


using NUnit.Framework;
using ScheduleBrewEFClasses.Models;
using Microsoft.EntityFrameworkCore;

namespace ScheduleBrewProjectTests
{
    [TestFixture]
    class BatchTests
    {
        List<Batch> batches;
        Batch b;
        ScheduleBrewSolutionContext dbContext;
        
        [SetUp]
        public void SetUp()
        {
            dbContext = new ScheduleBrewSolutionContext();
        }
        [Test]
        public void CreateTest()
        {
            b = new Batch();
            b.RecipeId = 1;
            b.EquipmentId = 1;
            dbContext.Batch.Add(b);
            dbContext.SaveChanges();
            Assert.IsNotNull(dbContext.Batch.Find(5));
        }
        [Test]
        public void DeleteTest()
        {
            b = dbContext.Batch.Find(5);
            dbContext.Batch.Remove(b);
            dbContext.SaveChanges();
            Assert.IsNull(dbContext.Batch.Find(5));
        }
    }
}
