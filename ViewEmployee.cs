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
    public partial class ViewEmployee : Form
    {
        DatabaseOperation databaseOperation = new DatabaseOperation();
        string query;
        DataSet ds;

        public ViewEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                query = "select * from employee";
                ds = databaseOperation.GetData(query);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                query = "select * from employee where ename like '" + txtSearch.Text + "%'";
                ds = databaseOperation.GetData(query);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
