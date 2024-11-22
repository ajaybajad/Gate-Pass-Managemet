using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GatePass
{
    public partial class AddVisitor : Form
    {
        DatabaseOperation databaseOperation = new DatabaseOperation();
        string query;
        DataSet ds;

        public AddVisitor()
        {
            InitializeComponent();
        }

        string visitorId;
        Boolean imageUploaded = false;
        string path;

        private void txtVisitor_TextChanged(object sender, EventArgs e)
        {
            txtVisitor.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (imageUploaded)
            {
                if (MessageBox.Show("Image Will be removed", "warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    PictureBox1.Image.Dispose();
                    PictureBox1.Image = null;
                    System.IO.File.Delete(path);
                    this.Close();

                }
            }
            else
            {
                this.Close();
            }
        }

        private void AddVisitor_Load(object sender, EventArgs e)
        {
            visitorId = Utility.getUniqueId("VID-");
            txtVisitor.Text = visitorId;
            path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)) + "\\Images\\" + visitorId + ".jpg";
                
        }


        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "c:\\";
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
                        PictureBox1.Image.Dispose();
                        PictureBox1.Image = null;
                        System.IO.File.Delete(path);
                        System.IO.File.Copy(open.FileName, path);
                    }
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    PictureBox1.Image = Image.FromFile(path);
                    imageUploaded = true;

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string contact = txtContact.Text;
                string gender = txtGender.Text;
                string address = txtAddress.Text;
                string uniqueId = txtUniqueId.Text;

                if (imageUploaded)
                {
                    if (!string.IsNullOrEmpty(name) &&
                        !string.IsNullOrEmpty(contact) &&
                        !string.IsNullOrEmpty(gender) &&
                        !string.IsNullOrEmpty(address) &&
                        !string.IsNullOrEmpty(uniqueId))
                    
                    {

                        Int64 contactNum = Int64.Parse(contact);
                        query = "insert into visitors (vname,contact,gender,vaddress,uniqueId,visitorId) values ('" + name + "','" + contact + "','" + gender + "','" + address + "','" + uniqueId + "','" + visitorId + "')";
                        databaseOperation.setData(query, "Visitor Added");
                        ClearAllFields();

                    }
                    else
                    {
                        MessageBox.Show("Fill Mandatory Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Picture Not Selected","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception id Add Visitor Save Click" + ex);
                MessageBox.Show("something went wrong :" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.onlyNumber(e);
        }

        private void ClearAllFields()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtGender.SelectedIndex = -1;
            txtUniqueId.Clear();

            imageUploaded = false;
            if(PictureBox1.Image != null)
            {
                PictureBox1.Image.Dispose();
                PictureBox1.Image = null;
            }
            AddVisitor_Load(this, null);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }
    }
}
