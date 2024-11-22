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
   
    public partial class DeleteEmployee : Form
    {
        DatabaseOperation databaseOperation = new DatabaseOperation();
        string query;
        DataSet ds;
        Boolean employeeAvailable = false;

        public DeleteEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                query = "select e.*,a.* from employee as e inner join appUser as a on e.appuser_fk=a.appuser_pk where a.username='"+username+"'";
                ds = databaseOperation.GetData(query);
                if(ds!=null && ds.Tables[0].Rows.Count != 0)
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
                    MessageBox.Show("Employee not found", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private void btndelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (employeeAvailable)
                {
                    query = "delete from employee from appUser where appuser_fk=appuser_pk and username='"+txtUsername.Text+"'";
                    databaseOperation.setData(query, "Employee Deleted");
                    query = "delete from appUser where username='"+txtUsername.Text+"'";
                    databaseOperation.setData(query, null);
                    ClearAllFields();
                }
                else
                {
                    employeeAvailable = false;
                    MessageBox.Show("Employee not found", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex)
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
            employeeAvailable = false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.ReadOnly = true;
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            txtContact.ReadOnly = true;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            txtAddress.ReadOnly = true;
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            txtCity.ReadOnly = true;
        }

        private void txtState_TextChanged(object sender, EventArgs e)
        {
            txtState.ReadOnly = true;
        }
    }
}
