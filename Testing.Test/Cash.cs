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
    public class Cash
    {
        EmployerRepository repository = new EmployerRepository(); 

        [Test]
        public void AddSuccess()
        {
            var res = repository.AddEmployer("An", "0797043481", "âsas", new DateTime(2002,10,20), "male", "dev", "7800000", "anbuibz54");
            Assert.AreEqual(res, "Success");
        }
        [Test]
        public void AddFailByEmptyField()
        {
            var res = repository.AddEmployer("", "", "", new DateTime(2002,10,20), "", "", "", "");
            Assert.AreEqual(res, "emptyfield");
        }
        [Test]
        public void AddFailByNotEnoughAge()
        {
            var res = repository.AddEmployer("An", "0797043481", "âsas", new DateTime(2022, 10, 20), "male", "dev", "7800000", "anbuibz54");
            Assert.AreEqual(res, "notenoughage");
        }
    }
}
