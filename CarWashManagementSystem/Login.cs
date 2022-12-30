using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWashManagementSystem
{
    public partial class Login : Form
    {
        public SqlCommand cm = new SqlCommand();
        public dbConnect dbcon = new dbConnect();
        public SqlDataReader dr;
        string title = "Car Wash Management System";
        public Login()
        {
            InitializeComponent();
            loadCompany();
        }


        public void loadCompany()
        {
            cm = new SqlCommand("SELECT * FROM tbCompany", dbcon.connect());
            dbcon.open();
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblCompany.Text = dr["name"].ToString();
                lblAddress.Text = dr["address"].ToString();
            }
            dr.Close();
            dbcon.close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPassword.Clear();
            txtName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT name FROM tbEmployer WHERE name ='" + txtName.Text + "' AND password ='" + txtPassword.Text + "'", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                    MessageBox.Show("WELCOME " + dr[0].ToString() + " | ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MainForm main = new MainForm();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                dbcon.close();
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, title);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }
        public int checkLogin(string name,string password)
        {
            try
            {
                cm = new SqlCommand("SELECT name FROM tbEmployer WHERE name ='" + name + "' AND password ='" + password + "'", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                dbcon.close();
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, title);
                return-1;
            }
        }    
    }
}
