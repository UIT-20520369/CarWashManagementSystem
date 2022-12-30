using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarWashManagementSystem.Repositories
{
    public class EmployerRepository
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        public string AddEmployer( string name, string phone,  string address,DateTime age,string gender,string role, string salary, string pass)
        {
            if (CheckField(address, phone, name, address, age))
            {
                try
                {
                    cm = new SqlCommand("INSERT INTO tbEmployer(name,phone,address,dob,gender,role,salary,password)VALUES(@name,@phone,@address,@dob,@gender,@role,@salary,@password)", dbcon.connect());
                    cm.Parameters.AddWithValue("@name", name);
                    cm.Parameters.AddWithValue("@phone", phone);
                    cm.Parameters.AddWithValue("@address", address);
                    cm.Parameters.AddWithValue("@dob", age);
                    cm.Parameters.AddWithValue("@gender", gender);//like if condition     
                    cm.Parameters.AddWithValue("@role", role);
                    cm.Parameters.AddWithValue("@salary", salary);
                    cm.Parameters.AddWithValue("@password", pass);

                    dbcon.open();// to open connection
                    cm.ExecuteNonQuery();
                    dbcon.close();// to close connection
                    return "Success";
                }
                catch
                {
                    return "Exception";
                }
            }
            else if (2022 - age.Year < 18) return "notenoughage";
            else
            {
                return "emptyfield";
            }
        }
        public bool CheckField(string address, string phone, string name, string salary, DateTime age)
        {
            if (address == "" || phone == "" || name == "" || salary == "" )
            {
                return false;
            }
            else if(2022 -age.Year<18) return false;
            else return true;
        }
    }
}
