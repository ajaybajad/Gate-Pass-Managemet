using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatePass
{
    public partial class AddEmployee : Form
    {
        DatabaseOperation databaseOperation = new DatabaseOperation();
        string query;
        DataSet ds;

        public AddEmployee()
        {
            InitializeComponent();
        }

        private void gunaLineTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string hireDate = txtHireDate.Text;
                string contact = txtContact.Text;
                string gender = txtGender.Text;
                string address = txtAddress.Text;
                string city = txtCity.Text;
                string state = txtState.Text;
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if(!string.IsNullOrEmpty(name) &&
                    !string.IsNullOrEmpty(hireDate) &&
                    !string.IsNullOrEmpty(contact) &&
                    !string.IsNullOrEmpty(gender) &&
                    !string.IsNullOrEmpty(address) &&
                    !string.IsNullOrEmpty(city) &&
                    !string.IsNullOrEmpty(state) &&
                    !string.IsNullOrEmpty(username) &&
                    !string.IsNullOrEmpty(password))
                {
                    Int64 contactInt = Int64.Parse(contact);
                    query = "select * from appUser where username='" + username + "' and uenabled=1 ";
                    ds = databaseOperation.GetData(query);
                    if(ds!= null && ds.Tables[0].Rows.Count == 0)
                    {
                        query = "insert into appUser(username,upass,urole) values ('"+username+"','"+password+"','EMPLOYEE')";
                        databaseOperation.setData(query, null);

                        query = "select * from appUser where username='" + username + "' and upass = '"+ password +"'  and uenabled=1 ";
                        ds = databaseOperation.GetData(query);

                        query = "insert into employee(ename,hiredate,contact,gender,eaddress,city,estate,appuser_fk) values ('" + name + "','" + hireDate + "',"+contactInt+ ",'" + gender + "','" + address + "','" + city + "','" + state + "'," + ds.Tables[0].Rows[0][0] +")";
                        databaseOperation.setData(query, "Employee Added Successfully!!");
                        ClearAllFields();
                        
                    }
                    else
                    {
                        MessageBox.Show("Username Already Exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Fields Empty. Fill & Try Again" , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in Add Employee btnSave Click : " + ex);
                MessageBox.Show("Something went wrong :" + ex, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void ClearAllFields()
        {
            
            txtAddress.Clear();
            txtContact.Clear();
            txtGender.SelectedIndex = -1;
            txtName.Clear();
            txtHireDate.ResetText();
            txtState.Clear();
            txtCity.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.onlyNumber(e);
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }
    }
}
