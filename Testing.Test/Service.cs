using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashManagementSystem.Repositories;
using NUnit.Framework;

namespace Testing.Test
{
    [TestFixture]
    public class Service
    {
        public ServiceRepository repository { get; set; }
        [SetUp]
        public void SetUp()
        {
            repository = new ServiceRepository();
        }
        [Test]
        public void AddSuccess() {
            var res = repository.AddService("Ăn uống", "100000");
            Assert.AreEqual(res, "Success");
        }
        [Test]
        public void AddFailureByInvalidInput()
        {
            var res = repository.AddService("Ăn uống", "-220000");
            Assert.AreEqual(res, "invalidprice");
        }
        [Test]
        public void AddFailureByEmptyName()
        {
            var res = repository.AddService("", "");
            Assert.AreEqual(res, "emptyfield");
        }
        [Test]
        public void AddFailureByEmptyPrice()
        {
            var res = repository.AddService("An", "");
            Assert.AreEqual(res, "emptyfield");
        }
        [Test]
        public void AddException()
        {
            var res = repository.AddService("Ăn uống", "anvisekd");
            Assert.AreEqual(res, "exception");
        }
    }
}
