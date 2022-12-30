using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CarWashManagementSystem;
using System.Data.SqlClient;
using CarWashManagementSystem.Repositories;
namespace Testing.Test
{
    [TestFixture]
    public class Customer
    {
        SqlCommand cm = new SqlCommand();
        CustomerRepository repository = new CustomerRepository();
        private SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Downloads\CarWashManagementSystem\CarWashManagementSystem\CarWashManagementSystem\DBCarWash.mdf;Integrated Security=True; Connect Timeout=30");
        public SqlDataReader dr;
        public SqlConnection connect()
        {
            return cn;
        }
        public void open()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();
        }

        public void close()
        {
            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public int Query(string sql)
        {
            try
            {
                open();
                cm = new SqlCommand(sql, connect());
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    close();
                    return 1;

                }
                else
                {
                    close();
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void AddSuccess()
        {
            var result = repository.AddCustomer("2", "An", "0797043481", "88", "hihi", "adefsdfs", "10");
            Assert.AreEqual(result, "Success");
        }
        [Test]
        public void AddFail()
        {
            var result = repository.AddCustomer("", "", "", "", "", "", "");
            Assert.AreEqual(result, "emptyfield");
        }

    }
}
