using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatePass
{
    public partial class ValidatePass : Form
    {
        DatabaseOperation databaseOperation = new DatabaseOperation();
        string query;
        DataSet ds;
        public ValidatePass()
        {
            InitializeComponent();
        }

        private void ValidatePass_Load(object sender, EventArgs e)
        {
            query = "select v.*,p.passId,p.validFrom,p.validTo from visitors as v inner join pass as p on v.visitors_pk=p.visitors_fk";
            ds = databaseOperation.GetData(query);
            dataGridViewVisitors.DataSource = ds.Tables[0];

            pictureBox2.BackColor = Color.LightGreen;
            pictureBox4.BackColor = Color.IndianRed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool IsDateAfterTodayOrToday(string input)
        {
            DateTime pDate;
            if (!DateTime.TryParseExact(input, "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out pDate))
            {
                return false;
            }
            return DateTime.Today <= pDate;
        }

        string path;
        Int64 visitorPk;

        private void dataGridViewVisitors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                path = Utility.getImageStorePath(dataGridViewVisitors.Rows[e.RowIndex].Cells[6].Value.ToString());
                visitorPk = Int64.Parse(dataGridViewVisitors.Rows[e.RowIndex].Cells[0].Value.ToString());
                labelPassId.Text = dataGridViewVisitors.Rows[e.RowIndex].Cells[7].Value.ToString();
                labelName.Text = dataGridViewVisitors.Rows[e.RowIndex].Cells[1].Value.ToString();
                labelContact.Text = dataGridViewVisitors.Rows[e.RowIndex].Cells[2].Value.ToString();
                labelGender.Text = dataGridViewVisitors.Rows[e.RowIndex].Cells[3].Value.ToString();

                labelValidFrom.Text = dataGridViewVisitors.Rows[e.RowIndex].Cells[8].Value.ToString();
                labelValidTo.Text = dataGridViewVisitors.Rows[e.RowIndex].Cells[9].Value.ToString();

                if (IsDateAfterTodayOrToday(dataGridViewVisitors.Rows[e.RowIndex].Cells[9].Value.ToString()))
                {
                    panel1.BackColor = Color.LightGreen;
                }
                else
                {
                    panel1.BackColor = Color.IndianRed;
                }

                if(pictureBoxProfile.Image != null)
                {
                    pictureBoxProfile.Image.Dispose();
                    pictureBoxProfile.Image = null;
                }
                pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxProfile.Image = Image.FromFile(path);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                query = "select * from visitors where vname like '" + txtSearch.Text + "%' or visitorId like '" + txtSearch.Text + "%' ";
                ds = databaseOperation.GetData(query);
                dataGridViewVisitors.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
