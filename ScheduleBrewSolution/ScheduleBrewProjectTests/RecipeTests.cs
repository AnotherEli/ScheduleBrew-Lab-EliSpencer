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
    public class RecipeTests
    {
        List<Recipe> recipes;
        Recipe r;
        ScheduleBrewSolutionContext dbContext;

        [SetUp]
        public void SetUp()
        {
            dbContext = new ScheduleBrewSolutionContext();
        }

        [Test]
        public void GetAllTest()
        {
            recipes = dbContext.Recipe.OrderBy(r => r.Name).ToList();
            Assert.AreEqual(4, recipes.Count);
            Assert.AreEqual("Cascade Orange Pale Ale", recipes[0].Name);
        }

        [Test]
        public void GetByPrimaryKeyTest()
        {
            r = dbContext.Recipe.Find(1);
            Assert.IsNotNull(r);
            Assert.AreEqual("Fuzzy Tales Juicy IPA", r.Name);
            Console.WriteLine(r);
        }

        [Test]
        public void GetUsingWhere()
        {
            // get a list of all of the products that have a unit price of 56.50
            recipes = dbContext.Recipe.Where(p => p.Volume.Equals(37.8541178)).OrderBy(p => p.RecipeId).ToList();
            Assert.AreEqual(3, recipes.Count);
            Assert.AreEqual("Fuzzy Tales Juicy IPA", recipes[0].Name);
        }

    }
}
