namespace Dashboard.Forms.New
{
    partial class NDF
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
            this.NDF_B_Cancel = new System.Windows.Forms.Button();
            this.NDF_B_Save = new System.Windows.Forms.Button();
            this.NDF_TB_DriverTlf = new System.Windows.Forms.TextBox();
            this.NDF_TB_DriverEmail = new System.Windows.Forms.TextBox();
            this.NDF_TB_DriverDNI = new System.Windows.Forms.TextBox();
            this.NDF_L_DriverEmail = new System.Windows.Forms.Label();
            this.NDF_L_DriverTlf = new System.Windows.Forms.Label();
            this.NDF_L_DriverDNI = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NDF_B_Cancel
            // 
            this.NDF_B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NDF_B_Cancel.Location = new System.Drawing.Point(21, 218);
            this.NDF_B_Cancel.Name = "NDF_B_Cancel";
            this.NDF_B_Cancel.Size = new System.Drawing.Size(96, 46);
            this.NDF_B_Cancel.TabIndex = 6;
            this.NDF_B_Cancel.Text = "Cancel";
            this.NDF_B_Cancel.UseVisualStyleBackColor = true;
            this.NDF_B_Cancel.Click += new System.EventHandler(this.NDF_B_Cancel_Click);
            // 
            // NDF_B_Save
            // 
            this.NDF_B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NDF_B_Save.Location = new System.Drawing.Point(148, 218);
            this.NDF_B_Save.Name = "NDF_B_Save";
            this.NDF_B_Save.Size = new System.Drawing.Size(106, 46);
            this.NDF_B_Save.TabIndex = 7;
            this.NDF_B_Save.Text = "Save";
            this.NDF_B_Save.UseVisualStyleBackColor = true;
            this.NDF_B_Save.Click += new System.EventHandler(this.NDF_B_Save_Click);
            // 
            // NDF_TB_DriverTlf
            // 
            this.NDF_TB_DriverTlf.Location = new System.Drawing.Point(21, 99);
            this.NDF_TB_DriverTlf.Name = "NDF_TB_DriverTlf";
            this.NDF_TB_DriverTlf.Size = new System.Drawing.Size(233, 22);
            this.NDF_TB_DriverTlf.TabIndex = 3;
            // 
            // NDF_TB_DriverEmail
            // 
            this.NDF_TB_DriverEmail.Location = new System.Drawing.Point(21, 159);
            this.NDF_TB_DriverEmail.Name = "NDF_TB_DriverEmail";
            this.NDF_TB_DriverEmail.Size = new System.Drawing.Size(233, 22);
            this.NDF_TB_DriverEmail.TabIndex = 5;
            // 
            // NDF_TB_DriverDNI
            // 
            this.NDF_TB_DriverDNI.Location = new System.Drawing.Point(21, 43);
            this.NDF_TB_DriverDNI.Name = "NDF_TB_DriverDNI";
            this.NDF_TB_DriverDNI.Size = new System.Drawing.Size(233, 22);
            this.NDF_TB_DriverDNI.TabIndex = 1;
            this.NDF_TB_DriverDNI.TextChanged += new System.EventHandler(this.NDF_TB_DriverDNI_TextChanged);
            // 
            // NDF_L_DriverEmail
            // 
            this.NDF_L_DriverEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NDF_L_DriverEmail.AutoSize = true;
            this.NDF_L_DriverEmail.Location = new System.Drawing.Point(18, 139);
            this.NDF_L_DriverEmail.Name = "NDF_L_DriverEmail";
            this.NDF_L_DriverEmail.Size = new System.Drawing.Size(46, 17);
            this.NDF_L_DriverEmail.TabIndex = 4;
            this.NDF_L_DriverEmail.Text = "Email:";
            // 
            // NDF_L_DriverTlf
            // 
            this.NDF_L_DriverTlf.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NDF_L_DriverTlf.AutoSize = true;
            this.NDF_L_DriverTlf.Location = new System.Drawing.Point(18, 79);
            this.NDF_L_DriverTlf.Name = "NDF_L_DriverTlf";
            this.NDF_L_DriverTlf.Size = new System.Drawing.Size(80, 17);
            this.NDF_L_DriverTlf.TabIndex = 2;
            this.NDF_L_DriverTlf.Text = "Telephone:";
            this.NDF_L_DriverTlf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NDF_L_DriverDNI
            // 
            this.NDF_L_DriverDNI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NDF_L_DriverDNI.AutoSize = true;
            this.NDF_L_DriverDNI.Location = new System.Drawing.Point(18, 20);
            this.NDF_L_DriverDNI.Name = "NDF_L_DriverDNI";
            this.NDF_L_DriverDNI.Size = new System.Drawing.Size(35, 17);
            this.NDF_L_DriverDNI.TabIndex = 0;
            this.NDF_L_DriverDNI.Text = "DNI:";
            // 
            // NDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 285);
            this.Controls.Add(this.NDF_B_Cancel);
            this.Controls.Add(this.NDF_B_Save);
            this.Controls.Add(this.NDF_TB_DriverTlf);
            this.Controls.Add(this.NDF_TB_DriverEmail);
            this.Controls.Add(this.NDF_TB_DriverDNI);
            this.Controls.Add(this.NDF_L_DriverEmail);
            this.Controls.Add(this.NDF_L_DriverTlf);
            this.Controls.Add(this.NDF_L_DriverDNI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "NDF";
            this.Text = "New driver";
            this.Load += new System.EventHandler(this.NDF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NDF_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NDF_B_Cancel;
        private System.Windows.Forms.Button NDF_B_Save;
        private System.Windows.Forms.TextBox NDF_TB_DriverTlf;
        private System.Windows.Forms.TextBox NDF_TB_DriverEmail;
        private System.Windows.Forms.TextBox NDF_TB_DriverDNI;
        private System.Windows.Forms.Label NDF_L_DriverEmail;
        private System.Windows.Forms.Label NDF_L_DriverTlf;
        private System.Windows.Forms.Label NDF_L_DriverDNI;
    }
}