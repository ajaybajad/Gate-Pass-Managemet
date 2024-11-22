using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatePass
{
    public partial class UpdateVisitor : Form
    {
        DatabaseOperation databaseOperation = new DatabaseOperation();
        String query;
        DataSet ds;

        public UpdateVisitor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Boolean isVisitorFound = false;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string visitorId = txtVisitor.Text;
                query = "select * from visitors where visitorId = '" + visitorId + "'";
                ds = databaseOperation.GetData(query);
                if(ds!=null && ds.Tables[0].Rows.Count != 0)
                {
                    isVisitorFound = true;
                    txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtGender.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtUniqueId.Text = ds.Tables[0].Rows[0][5].ToString();

                    Utility.setImageInPictureBox(PictureBox2, visitorId);

                }
                else
                {
                    isVisitorFound = false;
                    MessageBox.Show("No record found", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClearAllFields()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtGender.SelectedIndex = -1;
            txtUniqueId.Clear();
            isVisitorFound = false;
            if(PictureBox2.Image != null)
            {
                PictureBox2.Image.Dispose();
                PictureBox2.Image = null;
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.onlyNumber(e);
        }

        private void txtVisitor_TextChanged(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            String visitorId = txtVisitor.Text;
            if (isVisitorFound)
            {
                String path = Utility.getImageStorePath(visitorId);
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = "C:\\";
                open.Filter = "(*.jpg;*.jpeg;*.bmp;) | *.jpg; *.jpeg; *.bmp;";
                open.FilterIndex = 1;

                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (open.CheckFileExists)
                    {
                        if (!File.Exists(path))
                        {
                            System.IO.File.Copy(open.FileName, path);
                        }
                        else
                        {
                            PictureBox2.Image.Dispose();
                            PictureBox2.Image = null;
                            System.IO.File.Delete(path);
                            System.IO.File.Copy(open.FileName, path);
                        }
                        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        PictureBox2.Image = Image.FromFile(path);

                    }
                }
            }
            else
            {
                MessageBox.Show("Visitor Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string contact = txtContact.Text;
                string gender = txtGender.Text;
                string address = txtAddress.Text;
                string uniqueId = txtUniqueId.Text;
                String visitorId = txtVisitor.Text;

                if (isVisitorFound)
                {
                    if (!string.IsNullOrEmpty(name) &&
                        !string.IsNullOrEmpty(contact) &&
                        !string.IsNullOrEmpty(gender) &&
                        !string.IsNullOrEmpty(address) &&
                        !string.IsNullOrEmpty(uniqueId) &&
                        !string.IsNullOrEmpty(visitorId))

                    {

                        Int64 contactNum = Int64.Parse(contact);
                        query = "update visitors set vname = '" + name + "',contact = '" + contact + "',gender = '" + gender + "',vaddress = '" + address + "',uniqueId = '" + uniqueId + "' where visitorId = '" + visitorId + "'";
                        databaseOperation.setData(query, "Visitor Updated");
                        ClearAllFields();

                    }
                    else
                    {
                        MessageBox.Show("Fields empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Visitor not Found", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("something went wrong :" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
