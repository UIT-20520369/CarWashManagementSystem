using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CarWashManagementSystem.Repositories
{
    public class CustomerRepository
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        public string AddCustomer(string id, string name, string phone, string no, string model,string address,string point)
        {
            if(CheckField(address,phone,name,no,model))
            {
                try
                {
                    cm = new SqlCommand("INSERT INTO tbCustomer(vid,name,phone,carno,carmodel,address,points)VALUES(@vid,@name,@phone,@carno,@carmodel,@address,@points)", dbcon.connect());
                    cm.Parameters.AddWithValue("@vid",id);// to save id number of vehicle type
                    cm.Parameters.AddWithValue("@name", name);
                    cm.Parameters.AddWithValue("@phone", phone);
                    cm.Parameters.AddWithValue("@carno", no);
                    cm.Parameters.AddWithValue("@carmodel", model);
                    cm.Parameters.AddWithValue("@address", address);
                    cm.Parameters.AddWithValue("@points", point);

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
            else
            {
                return "emptyfield";
            }    
        }
        public bool CheckField(string address, string phone, string name, string no, string model)
        {
            if (address == "" || phone == "" || name == "" || no == "" || model == "")
            {
                return false;
            }
            else return true;
        }
    }
}
