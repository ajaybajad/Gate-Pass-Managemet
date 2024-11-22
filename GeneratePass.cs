using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace GatePass
{
    public partial class GeneratePass : Form
    {
        DatabaseOperation databaseOperation = new DatabaseOperation();
        string query;
        DataSet ds;
        public GeneratePass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GeneratePass_Load(object sender, EventArgs e)
        {
            query = "select * from visitors";
            ds = databaseOperation.GetData(query);
            dataGridViewVisitors.DataSource = ds.Tables[0];

            pictureBox2.BackColor = Color.Gray;
            pictureBox3.BackColor = Color.Yellow;
            pictureBox4.BackColor = Color.SkyBlue;
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

        string passId;
        string path;
        Int64 visitorPk;
        private void dataGridViewVisitors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)) + "\\Images\\" + dataGridViewVisitors.Rows[e.RowIndex].Cells[6].Value.ToString() + ".jpg";
                passId = Utility.getUniqueId("PID-");
                visitorPk = Int64.Parse(dataGridViewVisitors.Rows[e.RowIndex].Cells[0].Value.ToString());
                labelPassId.Text = passId;
                labelName.Text = dataGridViewVisitors.Rows[e.RowIndex].Cells[1].Value.ToString();
                labelContact.Text = dataGridViewVisitors.Rows[e.RowIndex].Cells[2].Value.ToString();
                labelGender.Text = dataGridViewVisitors.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (pictureBoxProfile.Image != null)
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

        private void SetPassColor(Int64 days)
        {
            if (days == 0)
            {
                panel1.BackColor = Color.Gray;
            }
            else if (days <= 6)
            {
                panel1.BackColor = Color.Yellow;
            }
            else
            {
                panel1.BackColor = Color.SkyBlue;
            }
        }

        private void CompareDate(string input)
        {
            DateTime dTCurrent = DateTime.Now;
            DateTime inputDate = DateTime.ParseExact(input, "dd.MM.yyy", CultureInfo.InvariantCulture);

            int result = DateTime.Compare(dTCurrent, inputDate);
            Console.WriteLine(result);
        }

        public static bool IsDateBeforeOrToday(string input)
        {
            DateTime pDate;
            if (!DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out pDate))
            {
                return false;
            }
            return DateTime.Today <= pDate;
        }

        public static bool IsDateAfterValidFrom(string date, string dateFrom)
        {
            DateTime validTo, validFrom;
            if (!DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validTo))
            {
                return false;
            }
            if (!DateTime.TryParseExact(dateFrom, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validFrom))
            {
                return false;
            }
            return validFrom <= validTo;
        }

        private void dateTimePickerValidFrom_ValueChanged(object sender, EventArgs e)
        {
            if (IsDateBeforeOrToday(dateTimePickerValidFrom.Text))
            {
                labelValidFrom.Text = dateTimePickerValidFrom.Text;

            }
            else
            {
                MessageBox.Show("Select Today Date Or date after today", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        Int64 days;
        private void dateTimePickerValidTo_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(labelValidFrom.Text))
            {
                if (IsDateAfterValidFrom(dateTimePickerValidTo.Text, labelValidFrom.Text))
                {
                    labelValidTo.Text = dateTimePickerValidTo.Text;
                    DateTime StartDate = DateTime.ParseExact(labelValidFrom.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    DateTime EndDate = DateTime.ParseExact(labelValidTo.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    days = (EndDate.Date - StartDate.Date).Days;
                    SetPassColor(days);
                }
                else
                {
                    MessageBox.Show("Select date after valid from date first", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Select Valid from date first", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Reset()
        {
            labelPassId.ResetText();
            labelName.ResetText();
            labelGender.ResetText();
            labelContact.ResetText();
            labelValidFrom.ResetText();
            labelValidTo.ResetText();
            if(pictureBoxProfile.Image!= null)
            {
                pictureBoxProfile.Image.Dispose();
                pictureBoxProfile.Image = null;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            

            string passId = labelPassId.Text;
            string name = labelName.Text;
            string contact = labelContact.Text;
            string gender = labelGender.Text;
            string validFrom = labelValidFrom.Text;
            string validTo = labelValidTo.Text;

            if (!string.IsNullOrEmpty(passId) &&
                        !string.IsNullOrEmpty(contact) &&
                        !string.IsNullOrEmpty(gender) &&
                        !string.IsNullOrEmpty(name) &&
                        !string.IsNullOrEmpty(validFrom) &&
                        !string.IsNullOrEmpty(validTo))
            {
                Pass p = new Pass(path, passId, name, contact, gender, validFrom, validTo, visitorPk, days);
                p.Show();
                Reset();
            }
            else
            {
                MessageBox.Show("Invalid Pass Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
