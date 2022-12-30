using NUnit.Framework;
using CarWashManagementSystem;
using System.Data.SqlClient;
namespace Testing.Test
{
    [TestFixture]
    public class Login
    {

        SqlCommand cm = new SqlCommand();
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
                    return 0; }
                
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
        public void Fail()
        {

            
            // var actual = Dbcontext.GetActual("SELECT name FROM tbEmployer WHERE name ='hahaha' AND password ='hihihi'");
            Assert.Less(Query("SELECT name FROM tbEmployer WHERE name ='hahaha' AND password ='hihihi'"),1);
        }
        [Test]
        public void ManagerSucess()
        {
            Assert.Greater(Query("SELECT name FROM tbEmployer WHERE name ='mdemy' AND password ='mdemy' AND role = 'Manager'"), 0);
        }
        [Test]
        public void CashierSuccess()
        {
            Assert.Greater(Query("SELECT name FROM tbEmployer WHERE name ='nayoo' AND password ='nayoo' AND role ='Cashier' "), 0);
        }
    }
}