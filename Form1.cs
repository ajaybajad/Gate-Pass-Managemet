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
    public partial class Form1 : Form
    {
        DatabaseOperation databaseOperation = new DatabaseOperation();
        String query;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do You Want To Exit", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select * from appUser where username='" +txtUsername.Text+ "' and upass='" +txtPassword.Text+ "' and uenabled=1";
                DataSet ds = databaseOperation.GetData(query);
                if(ds!=null && ds.Tables[0].Rows.Count != 0)
                {
                    string role = ds.Tables[0].Rows[0][3].ToString();
                    Int64 appUserPk = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    Dashboard dashboard = new Dashboard(role);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bad Credencials : " , "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Exception in login_btn Click :" + ex);
                MessageBox.Show("Something Went Wrong : " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2CheckBox1_CheckedChanged_1(object sender, EventArgs e)
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
