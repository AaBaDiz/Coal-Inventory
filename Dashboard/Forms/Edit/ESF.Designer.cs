namespace Dashboard.Forms.Edit
{
    partial class ESF
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
            this.ESF_TB_Search = new System.Windows.Forms.TextBox();
            this.ESF_B_Search = new System.Windows.Forms.Button();
            this.ESF_ComboB_Options = new System.Windows.Forms.ComboBox();
            this.ESF_DGV_Table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ESF_DGV_Table)).BeginInit();
            this.SuspendLayout();
            // 
            // ESF_TB_Search
            // 
            this.ESF_TB_Search.Location = new System.Drawing.Point(14, 12);
            this.ESF_TB_Search.Name = "ESF_TB_Search";
            this.ESF_TB_Search.Size = new System.Drawing.Size(358, 22);
            this.ESF_TB_Search.TabIndex = 0;
            // 
            // ESF_B_Search
            // 
            this.ESF_B_Search.Location = new System.Drawing.Point(13, 267);
            this.ESF_B_Search.Name = "ESF_B_Search";
            this.ESF_B_Search.Size = new System.Drawing.Size(496, 38);
            this.ESF_B_Search.TabIndex = 3;
            this.ESF_B_Search.Text = "Search";
            this.ESF_B_Search.UseVisualStyleBackColor = true;
            this.ESF_B_Search.Click += new System.EventHandler(this.ESF_B_Search_Click);
            // 
            // ESF_ComboB_Options
            // 
            this.ESF_ComboB_Options.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ESF_ComboB_Options.FormattingEnabled = true;
            this.ESF_ComboB_Options.Location = new System.Drawing.Point(378, 12);
            this.ESF_ComboB_Options.Name = "ESF_ComboB_Options";
            this.ESF_ComboB_Options.Size = new System.Drawing.Size(131, 24);
            this.ESF_ComboB_Options.TabIndex = 1;
            this.ESF_ComboB_Options.SelectedIndexChanged += new System.EventHandler(this.ESF_ComboB_Options_SelectedIndexChanged);
            // 
            // ESF_DGV_Table
            // 
            this.ESF_DGV_Table.AllowUserToAddRows = false;
            this.ESF_DGV_Table.AllowUserToDeleteRows = false;
            this.ESF_DGV_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ESF_DGV_Table.Location = new System.Drawing.Point(14, 40);
            this.ESF_DGV_Table.Name = "ESF_DGV_Table";
            this.ESF_DGV_Table.ReadOnly = true;
            this.ESF_DGV_Table.RowTemplate.Height = 24;
            this.ESF_DGV_Table.Size = new System.Drawing.Size(495, 221);
            this.ESF_DGV_Table.TabIndex = 2;
            this.ESF_DGV_Table.Visible = false;
            this.ESF_DGV_Table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ESF_DGV_Table_CellClick);
            this.ESF_DGV_Table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ESF_DGV_Table_CellContentClick);
            // 
            // ESF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 317);
            this.Controls.Add(this.ESF_DGV_Table);
            this.Controls.Add(this.ESF_ComboB_Options);
            this.Controls.Add(this.ESF_B_Search);
            this.Controls.Add(this.ESF_TB_Search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ESF";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.ESF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESF_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ESF_DGV_Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ESF_TB_Search;
        private System.Windows.Forms.Button ESF_B_Search;
        private System.Windows.Forms.ComboBox ESF_ComboB_Options;
        private System.Windows.Forms.DataGridView ESF_DGV_Table;
    }
}