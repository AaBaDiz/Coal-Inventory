namespace Dashboard
{
    partial class MMF
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
            this.MMF_MS_Navbar = new System.Windows.Forms.MenuStrip();
            this.MMF_TSMI_New = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_NewDriver = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_NewEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_NewTruck = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_EditEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_EditTruck = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_View = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_ViewEntries = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_ViewEntriesAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_ViewEntriesTruck = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_ViewCoal = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_ViewAuthorized = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_ViewAuthorizedAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_TSMI_ViewAuthorizeTruck = new System.Windows.Forms.ToolStripMenuItem();
            this.MMF_CB_Language = new System.Windows.Forms.ComboBox();
            this.MMF_DGV_Table = new System.Windows.Forms.DataGridView();
            this.MMF_MS_Navbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MMF_DGV_Table)).BeginInit();
            this.SuspendLayout();
            // 
            // MMF_MS_Navbar
            // 
            this.MMF_MS_Navbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MMF_MS_Navbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMF_TSMI_New,
            this.MMF_TSMI_Edit,
            this.MMF_TSMI_View});
            this.MMF_MS_Navbar.Location = new System.Drawing.Point(0, 0);
            this.MMF_MS_Navbar.MinimumSize = new System.Drawing.Size(0, 45);
            this.MMF_MS_Navbar.Name = "MMF_MS_Navbar";
            this.MMF_MS_Navbar.Size = new System.Drawing.Size(800, 45);
            this.MMF_MS_Navbar.TabIndex = 1;
            this.MMF_MS_Navbar.Text = "menuStrip1";
            this.MMF_MS_Navbar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MMF_MS_Navbar_ItemClicked);
            // 
            // MMF_TSMI_New
            // 
            this.MMF_TSMI_New.BackColor = System.Drawing.SystemColors.Control;
            this.MMF_TSMI_New.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMF_TSMI_NewDriver,
            this.MMF_TSMI_NewEntry,
            this.MMF_TSMI_NewTruck});
            this.MMF_TSMI_New.Name = "MMF_TSMI_New";
            this.MMF_TSMI_New.Size = new System.Drawing.Size(60, 41);
            this.MMF_TSMI_New.Text = "&New...";
            // 
            // MMF_TSMI_NewDriver
            // 
            this.MMF_TSMI_NewDriver.Name = "MMF_TSMI_NewDriver";
            this.MMF_TSMI_NewDriver.Size = new System.Drawing.Size(133, 26);
            this.MMF_TSMI_NewDriver.Text = "Driver...";
            this.MMF_TSMI_NewDriver.Click += new System.EventHandler(this.MMF_TSMI_NewDriver_Click);
            // 
            // MMF_TSMI_NewEntry
            // 
            this.MMF_TSMI_NewEntry.Name = "MMF_TSMI_NewEntry";
            this.MMF_TSMI_NewEntry.Size = new System.Drawing.Size(133, 26);
            this.MMF_TSMI_NewEntry.Text = "Entry...";
            this.MMF_TSMI_NewEntry.Click += new System.EventHandler(this.MMF_TSMI_NewEntry_Click);
            // 
            // MMF_TSMI_NewTruck
            // 
            this.MMF_TSMI_NewTruck.Name = "MMF_TSMI_NewTruck";
            this.MMF_TSMI_NewTruck.Size = new System.Drawing.Size(133, 26);
            this.MMF_TSMI_NewTruck.Text = "Truck...";
            this.MMF_TSMI_NewTruck.Click += new System.EventHandler(this.MMF_TSMI_NewTruck_Click);
            // 
            // MMF_TSMI_Edit
            // 
            this.MMF_TSMI_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMF_TSMI_EditEntry,
            this.MMF_TSMI_EditTruck});
            this.MMF_TSMI_Edit.Name = "MMF_TSMI_Edit";
            this.MMF_TSMI_Edit.Size = new System.Drawing.Size(47, 41);
            this.MMF_TSMI_Edit.Text = "&Edit";
            // 
            // MMF_TSMI_EditEntry
            // 
            this.MMF_TSMI_EditEntry.Name = "MMF_TSMI_EditEntry";
            this.MMF_TSMI_EditEntry.Size = new System.Drawing.Size(127, 26);
            this.MMF_TSMI_EditEntry.Text = "&Entry...";
            this.MMF_TSMI_EditEntry.Click += new System.EventHandler(this.MMF_TSMI_EditEntry_Click);
            // 
            // MMF_TSMI_EditTruck
            // 
            this.MMF_TSMI_EditTruck.Name = "MMF_TSMI_EditTruck";
            this.MMF_TSMI_EditTruck.Size = new System.Drawing.Size(127, 26);
            this.MMF_TSMI_EditTruck.Text = "&Truck...";
            this.MMF_TSMI_EditTruck.Click += new System.EventHandler(this.MMF_TSMI_EditTruck_Click);
            // 
            // MMF_TSMI_View
            // 
            this.MMF_TSMI_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMF_TSMI_ViewEntries,
            this.MMF_TSMI_ViewCoal,
            this.MMF_TSMI_ViewAuthorized});
            this.MMF_TSMI_View.Name = "MMF_TSMI_View";
            this.MMF_TSMI_View.Size = new System.Drawing.Size(53, 41);
            this.MMF_TSMI_View.Text = "&View";
            // 
            // MMF_TSMI_ViewEntries
            // 
            this.MMF_TSMI_ViewEntries.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMF_TSMI_ViewEntriesAll,
            this.MMF_TSMI_ViewEntriesTruck});
            this.MMF_TSMI_ViewEntries.Name = "MMF_TSMI_ViewEntries";
            this.MMF_TSMI_ViewEntries.Size = new System.Drawing.Size(214, 26);
            this.MMF_TSMI_ViewEntries.Text = "Entries";
            // 
            // MMF_TSMI_ViewEntriesAll
            // 
            this.MMF_TSMI_ViewEntriesAll.Name = "MMF_TSMI_ViewEntriesAll";
            this.MMF_TSMI_ViewEntriesAll.Size = new System.Drawing.Size(173, 26);
            this.MMF_TSMI_ViewEntriesAll.Text = "All";
            this.MMF_TSMI_ViewEntriesAll.Click += new System.EventHandler(this.MMF_TSMI_ViewEntriesAll_Click);
            // 
            // MMF_TSMI_ViewEntriesTruck
            // 
            this.MMF_TSMI_ViewEntriesTruck.Name = "MMF_TSMI_ViewEntriesTruck";
            this.MMF_TSMI_ViewEntriesTruck.Size = new System.Drawing.Size(173, 26);
            this.MMF_TSMI_ViewEntriesTruck.Text = "Search truck...";
            this.MMF_TSMI_ViewEntriesTruck.Click += new System.EventHandler(this.MMF_TSMI_ViewEntriesTruck_Click);
            // 
            // MMF_TSMI_ViewCoal
            // 
            this.MMF_TSMI_ViewCoal.Name = "MMF_TSMI_ViewCoal";
            this.MMF_TSMI_ViewCoal.Size = new System.Drawing.Size(214, 26);
            this.MMF_TSMI_ViewCoal.Text = "&Coal shipments";
            this.MMF_TSMI_ViewCoal.Click += new System.EventHandler(this.MMF_TSMI_ViewCoal_Click);
            // 
            // MMF_TSMI_ViewAuthorized
            // 
            this.MMF_TSMI_ViewAuthorized.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMF_TSMI_ViewAuthorizedAll,
            this.MMF_TSMI_ViewAuthorizeTruck});
            this.MMF_TSMI_ViewAuthorized.Name = "MMF_TSMI_ViewAuthorized";
            this.MMF_TSMI_ViewAuthorized.Size = new System.Drawing.Size(214, 26);
            this.MMF_TSMI_ViewAuthorized.Text = "Authorized entries...";
            // 
            // MMF_TSMI_ViewAuthorizedAll
            // 
            this.MMF_TSMI_ViewAuthorizedAll.Name = "MMF_TSMI_ViewAuthorizedAll";
            this.MMF_TSMI_ViewAuthorizedAll.Size = new System.Drawing.Size(173, 26);
            this.MMF_TSMI_ViewAuthorizedAll.Text = "All";
            this.MMF_TSMI_ViewAuthorizedAll.Click += new System.EventHandler(this.MMF_TSMI_ViewAuthorizedAll_Click);
            // 
            // MMF_TSMI_ViewAuthorizeTruck
            // 
            this.MMF_TSMI_ViewAuthorizeTruck.Name = "MMF_TSMI_ViewAuthorizeTruck";
            this.MMF_TSMI_ViewAuthorizeTruck.Size = new System.Drawing.Size(173, 26);
            this.MMF_TSMI_ViewAuthorizeTruck.Text = "Search truck...";
            this.MMF_TSMI_ViewAuthorizeTruck.Click += new System.EventHandler(this.MMF_TSMI_ViewAuthorizeTruck_Click);
            // 
            // MMF_CB_Language
            // 
            this.MMF_CB_Language.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MMF_CB_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MMF_CB_Language.FormattingEnabled = true;
            this.MMF_CB_Language.Location = new System.Drawing.Point(668, 12);
            this.MMF_CB_Language.Name = "MMF_CB_Language";
            this.MMF_CB_Language.Size = new System.Drawing.Size(120, 24);
            this.MMF_CB_Language.TabIndex = 2;
            this.MMF_CB_Language.SelectedIndexChanged += new System.EventHandler(this.MMF_CB_Language_SelectedIndexChanged);
            // 
            // MMF_DGV_Table
            // 
            this.MMF_DGV_Table.AllowUserToAddRows = false;
            this.MMF_DGV_Table.AllowUserToDeleteRows = false;
            this.MMF_DGV_Table.AllowUserToOrderColumns = true;
            this.MMF_DGV_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MMF_DGV_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MMF_DGV_Table.Location = new System.Drawing.Point(0, 45);
            this.MMF_DGV_Table.Name = "MMF_DGV_Table";
            this.MMF_DGV_Table.ReadOnly = true;
            this.MMF_DGV_Table.RowTemplate.Height = 24;
            this.MMF_DGV_Table.Size = new System.Drawing.Size(800, 405);
            this.MMF_DGV_Table.TabIndex = 3;
            // 
            // MMF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MMF_DGV_Table);
            this.Controls.Add(this.MMF_CB_Language);
            this.Controls.Add(this.MMF_MS_Navbar);
            this.KeyPreview = true;
            this.Name = "MMF";
            this.Text = "Main menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MMF_Activated);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Shown += new System.EventHandler(this.MMF_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MMF_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MMF_KeyPress);
            this.MMF_MS_Navbar.ResumeLayout(false);
            this.MMF_MS_Navbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MMF_DGV_Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MMF_MS_Navbar;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_New;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_Edit;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_EditEntry;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_EditTruck;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_View;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_ViewEntries;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_ViewCoal;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_NewDriver;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_NewEntry;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_NewTruck;
        private System.Windows.Forms.ComboBox MMF_CB_Language;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_ViewEntriesAll;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_ViewEntriesTruck;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_ViewAuthorized;
        private System.Windows.Forms.DataGridView MMF_DGV_Table;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_ViewAuthorizedAll;
        private System.Windows.Forms.ToolStripMenuItem MMF_TSMI_ViewAuthorizeTruck;
    }
}

