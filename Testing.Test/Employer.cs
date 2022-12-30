using CarWashManagementSystem;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Testing.Test
{
    public class Employer
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        public string AddService(string name, string price)
        {
            if (name == "" || price == "")
            {
                return "emptyfield";
            }
            try
            {
                var temp = double.Parse(price);
                if (temp < 0) return "invalidprice";
                else
                {
                    cm = new SqlCommand("INSERT INTO tbService(name,price)VALUES(@name,@price)", dbcon.connect());
                    cm.Parameters.AddWithValue("@name", name);
                    cm.Parameters.AddWithValue("@price", price);

                    dbcon.open();// to open connection
                    cm.ExecuteNonQuery();
                    dbcon.close();// to close connection
                    return "Success";
                }
            }
            catch
            {
                return "exception";
            }
        }
    }
}
