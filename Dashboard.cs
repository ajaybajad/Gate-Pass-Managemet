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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        string role;
        public Dashboard(string role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string backgroundName;
            if ("ADMIN".Equals(role))
            {
                backgroundName = "gatepassbg1";
                labelWelcomeText.Text = "Admin Dasboard";
            }
            else
            {
                employeeToolStripMenuItem.Visible = false;
                backgroundName = "gatepassbg2";
                labelWelcomeText.Text = "Employee Dashboard";
            }
            Image image = Image.FromFile(Utility.getImageStorePath(backgroundName));
            this.BackgroundImage = image;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You Want To Logout", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("You Want To Exit","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms.OfType<AddEmployee>().Count() == 1)
            {
                Application.OpenForms.OfType<AddEmployee>().First().BringToFront();
            }
            else
            {
                AddEmployee addEmployee = new AddEmployee();
                addEmployee.Show();
            }
        }

        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UpdateEmployee>().Count() == 1)
            {
                Application.OpenForms.OfType<UpdateEmployee>().First().BringToFront();
            }
            else
            {
                UpdateEmployee updateEmployee = new UpdateEmployee();
                updateEmployee.Show();
            }
        }

        private void viewAllEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ViewEmployee>().Count() == 1)
            {
                Application.OpenForms.OfType<ViewEmployee>().First().BringToFront();
            }
            else
            {
                ViewEmployee viewEmployee = new ViewEmployee();
                viewEmployee.Show();
            }
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<DeleteEmployee>().Count() == 1)
            {
                Application.OpenForms.OfType<DeleteEmployee>().First().BringToFront();
            }
            else
            {
                DeleteEmployee deleteEmployee = new DeleteEmployee();
                deleteEmployee.Show();
            }
        }

        private void addVisitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AddVisitor>().Count() == 1)
            {
                Application.OpenForms.OfType<AddVisitor>().First().BringToFront();
            }
            else
            {
                AddVisitor addVisitor = new AddVisitor();
                addVisitor.Show();
            }
        }

        private void updateVisitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ViewVisitor>().Count() == 1)
            {
                Application.OpenForms.OfType<ViewVisitor>().First().BringToFront();
            }
            else
            {
                ViewVisitor viewVisitor = new ViewVisitor();
                viewVisitor.Show();
            }
        }

        private void updateVisitorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UpdateVisitor>().Count() == 1)
            {
                Application.OpenForms.OfType<UpdateVisitor>().First().BringToFront();
            }
            else
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                updateVisitor.Show();
            }
        }

        private void generatePassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<GeneratePass>().Count() == 1)
            {
                Application.OpenForms.OfType<GeneratePass>().First().BringToFront();
            }
            else
            {
                GeneratePass generatePass = new GeneratePass();
                generatePass.Show();
            }
        }

        private void validatePassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ValidatePass>().Count() == 1)
            {
                Application.OpenForms.OfType<ValidatePass>().First().BringToFront();
            }
            else
            {
                ValidatePass validatePass = new ValidatePass();
                validatePass.Show();
            }
        }

        private void filterPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FilterPass>().Count() == 1)
            {
                Application.OpenForms.OfType<FilterPass>().First().BringToFront();
            }
            else
            {
                FilterPass filterPass = new FilterPass();
                filterPass.Show();
            }
        }
    }
}
