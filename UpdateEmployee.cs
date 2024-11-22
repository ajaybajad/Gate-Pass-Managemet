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
    public partial class UpdateEmployee : Form
    {
        DatabaseOperation databaseOperation = new DatabaseOperation();
        string query;
        DataSet ds;
        Boolean employeeAvailable = false;

        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void txtGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                query = "select e.*,a.* from employee as e inner join appUser as a on e.appuser_fk = a.appuser_pk where a.username = '" + username + "'";
                ds = databaseOperation.GetData(query);
                if(ds != null && ds.Tables[0].Rows.Count!=0)
                {
                    employeeAvailable = true;
                    txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtHireDate.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtGender.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtCity.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtState.Text = ds.Tables[0].Rows[0][7].ToString();

                }
                else
                {
                    employeeAvailable = false;
                    MessageBox.Show("Employee not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string contact = txtContact.Text;
                string gender = txtGender.Text;
                string address = txtAddress.Text;
                string city = txtCity.Text;
                string state = txtState.Text;
                string username = txtUsername.Text;

                if (employeeAvailable)
                {
                    if(!string.IsNullOrEmpty(name) &&
                    !string.IsNullOrEmpty(contact) &&
                    !string.IsNullOrEmpty(gender) &&
                    !string.IsNullOrEmpty(address) &&
                    !string.IsNullOrEmpty(city) &&
                    !string.IsNullOrEmpty(state) &&
                    !string.IsNullOrEmpty(username))
                    {
                        Int64 number = Int64.Parse(contact);
                        query = "update e set e.ename='"+name+"',e.contact="+number+",e.gender='"+gender+"',e.eaddress='"+address+"',e.city='"+city+"',e.estate='"+state+"' from employee as e inner join appUser as a on e.appuser_fk = a.appuser_pk where a.username='"+username+"'";
                        databaseOperation.setData(query, "Employyee Updated");
                        ClearAllFields();
                    }
                    else
                    {
                        MessageBox.Show("Fields are Empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Employee not found", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            txtCity.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtGender.SelectedIndex = -1;
            txtName.Clear();
            txtHireDate.ResetText();
            txtState.Clear();
            txtUsername.Clear();
            employeeAvailable = false;

        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.onlyNumber(e);
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {

        }

        private void labeladdemp_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
