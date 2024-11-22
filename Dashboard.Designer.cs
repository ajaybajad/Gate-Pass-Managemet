namespace GatePass
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVisitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateVisitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateVisitorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validatePassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.labelWelcomeText = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeToolStripMenuItem,
            this.visitorToolStripMenuItem,
            this.generatePassToolStripMenuItem,
            this.validatePassToolStripMenuItem,
            this.btnLogout,
            this.btnExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1351, 68);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEmployeeToolStripMenuItem,
            this.updateEmployeeToolStripMenuItem,
            this.viewAllEmployeeToolStripMenuItem,
            this.deleteEmployeeToolStripMenuItem});
            this.employeeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("employeeToolStripMenuItem.Image")));
            this.employeeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(187, 64);
            this.employeeToolStripMenuItem.Text = "Employee";
            // 
            // addEmployeeToolStripMenuItem
            // 
            this.addEmployeeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addEmployeeToolStripMenuItem.Image")));
            this.addEmployeeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addEmployeeToolStripMenuItem.Name = "addEmployeeToolStripMenuItem";
            this.addEmployeeToolStripMenuItem.Size = new System.Drawing.Size(335, 70);
            this.addEmployeeToolStripMenuItem.Text = "Add Employee";
            this.addEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addEmployeeToolStripMenuItem_Click);
            // 
            // updateEmployeeToolStripMenuItem
            // 
            this.updateEmployeeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateEmployeeToolStripMenuItem.Image")));
            this.updateEmployeeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateEmployeeToolStripMenuItem.Name = "updateEmployeeToolStripMenuItem";
            this.updateEmployeeToolStripMenuItem.Size = new System.Drawing.Size(335, 70);
            this.updateEmployeeToolStripMenuItem.Text = "Update Employee";
            this.updateEmployeeToolStripMenuItem.Click += new System.EventHandler(this.updateEmployeeToolStripMenuItem_Click);
            // 
            // viewAllEmployeeToolStripMenuItem
            // 
            this.viewAllEmployeeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewAllEmployeeToolStripMenuItem.Image")));
            this.viewAllEmployeeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewAllEmployeeToolStripMenuItem.Name = "viewAllEmployeeToolStripMenuItem";
            this.viewAllEmployeeToolStripMenuItem.Size = new System.Drawing.Size(335, 70);
            this.viewAllEmployeeToolStripMenuItem.Text = "View All Employee";
            this.viewAllEmployeeToolStripMenuItem.Click += new System.EventHandler(this.viewAllEmployeeToolStripMenuItem_Click);
            // 
            // deleteEmployeeToolStripMenuItem
            // 
            this.deleteEmployeeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteEmployeeToolStripMenuItem.Image")));
            this.deleteEmployeeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteEmployeeToolStripMenuItem.Name = "deleteEmployeeToolStripMenuItem";
            this.deleteEmployeeToolStripMenuItem.Size = new System.Drawing.Size(335, 70);
            this.deleteEmployeeToolStripMenuItem.Text = "Delete Employee";
            this.deleteEmployeeToolStripMenuItem.Click += new System.EventHandler(this.deleteEmployeeToolStripMenuItem_Click);
            // 
            // visitorToolStripMenuItem
            // 
            this.visitorToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.visitorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVisitorToolStripMenuItem,
            this.updateVisitorToolStripMenuItem,
            this.updateVisitorToolStripMenuItem1});
            this.visitorToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.visitorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visitorToolStripMenuItem.Image")));
            this.visitorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.visitorToolStripMenuItem.Name = "visitorToolStripMenuItem";
            this.visitorToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.visitorToolStripMenuItem.Size = new System.Drawing.Size(153, 64);
            this.visitorToolStripMenuItem.Text = "Visitor";
            // 
            // addVisitorToolStripMenuItem
            // 
            this.addVisitorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addVisitorToolStripMenuItem.Image")));
            this.addVisitorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addVisitorToolStripMenuItem.Name = "addVisitorToolStripMenuItem";
            this.addVisitorToolStripMenuItem.Size = new System.Drawing.Size(294, 70);
            this.addVisitorToolStripMenuItem.Text = "Add Visitor";
            this.addVisitorToolStripMenuItem.Click += new System.EventHandler(this.addVisitorToolStripMenuItem_Click);
            // 
            // updateVisitorToolStripMenuItem
            // 
            this.updateVisitorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateVisitorToolStripMenuItem.Image")));
            this.updateVisitorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateVisitorToolStripMenuItem.Name = "updateVisitorToolStripMenuItem";
            this.updateVisitorToolStripMenuItem.Size = new System.Drawing.Size(294, 70);
            this.updateVisitorToolStripMenuItem.Text = "View Visitor";
            this.updateVisitorToolStripMenuItem.Click += new System.EventHandler(this.updateVisitorToolStripMenuItem_Click);
            // 
            // updateVisitorToolStripMenuItem1
            // 
            this.updateVisitorToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("updateVisitorToolStripMenuItem1.Image")));
            this.updateVisitorToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateVisitorToolStripMenuItem1.Name = "updateVisitorToolStripMenuItem1";
            this.updateVisitorToolStripMenuItem1.Size = new System.Drawing.Size(294, 70);
            this.updateVisitorToolStripMenuItem1.Text = "Update Visitor";
            this.updateVisitorToolStripMenuItem1.Click += new System.EventHandler(this.updateVisitorToolStripMenuItem1_Click);
            // 
            // generatePassToolStripMenuItem
            // 
            this.generatePassToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("generatePassToolStripMenuItem.Image")));
            this.generatePassToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.generatePassToolStripMenuItem.Name = "generatePassToolStripMenuItem";
            this.generatePassToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.generatePassToolStripMenuItem.Size = new System.Drawing.Size(227, 64);
            this.generatePassToolStripMenuItem.Text = "Generate Pass";
            this.generatePassToolStripMenuItem.Click += new System.EventHandler(this.generatePassToolStripMenuItem_Click);
            // 
            // validatePassToolStripMenuItem
            // 
            this.validatePassToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.validatePassToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.validatePassToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("validatePassToolStripMenuItem.Image")));
            this.validatePassToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.validatePassToolStripMenuItem.Name = "validatePassToolStripMenuItem";
            this.validatePassToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.validatePassToolStripMenuItem.Size = new System.Drawing.Size(217, 64);
            this.validatePassToolStripMenuItem.Text = "Validate Pass";
            this.validatePassToolStripMenuItem.Click += new System.EventHandler(this.validatePassToolStripMenuItem_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Silver;
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLogout.Size = new System.Drawing.Size(160, 64);
            this.btnLogout.Text = "LogOut";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExit.Size = new System.Drawing.Size(125, 64);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelWelcomeText
            // 
            this.labelWelcomeText.AutoSize = true;
            this.labelWelcomeText.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcomeText.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcomeText.ForeColor = System.Drawing.Color.Black;
            this.labelWelcomeText.Location = new System.Drawing.Point(836, 104);
            this.labelWelcomeText.Name = "labelWelcomeText";
            this.labelWelcomeText.Size = new System.Drawing.Size(235, 39);
            this.labelWelcomeText.TabIndex = 1;
            this.labelWelcomeText.Text = "Welcome Admin";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 709);
            this.Controls.Add(this.labelWelcomeText);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVisitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateVisitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateVisitorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem generatePassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validatePassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnLogout;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.Label labelWelcomeText;
    }
}