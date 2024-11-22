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
    public partial class Pass : Form
    {
        DatabaseOperation databaseOperation = new DatabaseOperation();
        string query;
        DataSet ds;

        public Pass()
        {
            InitializeComponent();
        }

        string path, passId, name, contact, gender, ValidFrom, ValidTo;


        Bitmap bmp;
        private void Print()
        {
            bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp,new Rectangle(0,0,this.Width,this.Height));
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle r = e.PageBounds;
            e.Graphics.DrawImage(bmp, r);
        }

        public Pass(string path, string passId, string name, string contact, string gender, string ValidFrom, String ValidTo, Int64 visitorPk,Int64 days)
        {
            InitializeComponent();
            try
            {
                pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxProfile.Image = Image.FromFile(path);
            }
            catch
            {

            }
            labelPassId.Text = passId;
            labelName.Text = name;
            labelGender.Text = gender;
            labelContact.Text = contact;
            labelValidFrom.Text = ValidFrom;
            labelValidTo.Text = ValidTo;

            SetPassColor(days);
            savePassDetails(passId, ValidFrom, ValidTo, visitorPk);


            this.path = path;
            this.passId = passId;
            this.name = name;
            this.gender = gender;
            this.ValidFrom = ValidFrom;
            this.ValidFrom = ValidTo;

        }


        private void SetPassColor(Int64 days)
        {
            if (days == 0)
            {
                this.BackColor = Color.Gray;
            }
            else if (days <= 6)
            {
                this.BackColor = Color.Yellow;
            }
            else
            {
                this.BackColor = Color.SkyBlue;
            }
        }

        private void savePassDetails(string passId, string ValidFrom, String ValidTo, Int64 visitorPk)
        {
            try
            {
                DateTime validFromDate = DateTime.ParseExact(ValidFrom, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DateTime validToDate = DateTime.ParseExact(ValidTo, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                query = "insert into pass (PassId,validFrom,validTo,visitors_fk) values ('" + passId+ "','" + validFromDate.ToString("yyyy-MM-dd") + "','" + validToDate.ToString("yyyy-MM-dd") + "'," + visitorPk + ")";
                databaseOperation.setData(query, null);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Pass_Load(object sender, EventArgs e)
        {
            Print();
            printPreviewDialog1.ShowDialog();
            this.Close();
        }
    }
}
