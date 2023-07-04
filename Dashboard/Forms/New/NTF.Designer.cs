namespace Dashboard.Forms.New
{
    partial class NTF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NTF));
            this.NTF_L_LicensePlate = new System.Windows.Forms.Label();
            this.NTF_TB_LicensePlate = new System.Windows.Forms.TextBox();
            this.NTF_TB_Weight = new System.Windows.Forms.TextBox();
            this.NTF_L_Weight = new System.Windows.Forms.Label();
            this.NTF_L_Authorized = new System.Windows.Forms.Label();
            this.NTF_CheckB_Authorized = new System.Windows.Forms.CheckBox();
            this.NTF_L_Description = new System.Windows.Forms.Label();
            this.NTF_TB_Description = new System.Windows.Forms.TextBox();
            this.NTF_B_UploadImage = new System.Windows.Forms.Button();
            this.NTF_PB_VehiclePhoto = new System.Windows.Forms.PictureBox();
            this.NTF_L_VehiclePhoto = new System.Windows.Forms.Label();
            this.NTF_B_Save = new System.Windows.Forms.Button();
            this.NTF_B_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NTF_PB_VehiclePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // NTF_L_LicensePlate
            // 
            this.NTF_L_LicensePlate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NTF_L_LicensePlate.AutoSize = true;
            this.NTF_L_LicensePlate.Location = new System.Drawing.Point(12, 126);
            this.NTF_L_LicensePlate.Name = "NTF_L_LicensePlate";
            this.NTF_L_LicensePlate.Size = new System.Drawing.Size(96, 17);
            this.NTF_L_LicensePlate.TabIndex = 2;
            this.NTF_L_LicensePlate.Text = "License plate:";
            // 
            // NTF_TB_LicensePlate
            // 
            this.NTF_TB_LicensePlate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NTF_TB_LicensePlate.Location = new System.Drawing.Point(15, 149);
            this.NTF_TB_LicensePlate.Name = "NTF_TB_LicensePlate";
            this.NTF_TB_LicensePlate.Size = new System.Drawing.Size(326, 22);
            this.NTF_TB_LicensePlate.TabIndex = 3;
            // 
            // NTF_TB_Weight
            // 
            this.NTF_TB_Weight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NTF_TB_Weight.Location = new System.Drawing.Point(15, 237);
            this.NTF_TB_Weight.Name = "NTF_TB_Weight";
            this.NTF_TB_Weight.Size = new System.Drawing.Size(326, 22);
            this.NTF_TB_Weight.TabIndex = 5;
            this.NTF_TB_Weight.TextChanged += new System.EventHandler(this.NTF_TB_Weight_TextChanged);
            // 
            // NTF_L_Weight
            // 
            this.NTF_L_Weight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NTF_L_Weight.AutoSize = true;
            this.NTF_L_Weight.Location = new System.Drawing.Point(12, 207);
            this.NTF_L_Weight.Name = "NTF_L_Weight";
            this.NTF_L_Weight.Size = new System.Drawing.Size(85, 17);
            this.NTF_L_Weight.TabIndex = 4;
            this.NTF_L_Weight.Text = "Weight (kg):";
            // 
            // NTF_L_Authorized
            // 
            this.NTF_L_Authorized.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NTF_L_Authorized.AutoSize = true;
            this.NTF_L_Authorized.Location = new System.Drawing.Point(12, 63);
            this.NTF_L_Authorized.Name = "NTF_L_Authorized";
            this.NTF_L_Authorized.Size = new System.Drawing.Size(80, 17);
            this.NTF_L_Authorized.TabIndex = 0;
            this.NTF_L_Authorized.Text = "Authorized:";
            // 
            // NTF_CheckB_Authorized
            // 
            this.NTF_CheckB_Authorized.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NTF_CheckB_Authorized.AutoSize = true;
            this.NTF_CheckB_Authorized.Location = new System.Drawing.Point(98, 64);
            this.NTF_CheckB_Authorized.Name = "NTF_CheckB_Authorized";
            this.NTF_CheckB_Authorized.Size = new System.Drawing.Size(18, 17);
            this.NTF_CheckB_Authorized.TabIndex = 1;
            this.NTF_CheckB_Authorized.UseVisualStyleBackColor = true;
            // 
            // NTF_L_Description
            // 
            this.NTF_L_Description.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NTF_L_Description.AutoSize = true;
            this.NTF_L_Description.Location = new System.Drawing.Point(14, 347);
            this.NTF_L_Description.Name = "NTF_L_Description";
            this.NTF_L_Description.Size = new System.Drawing.Size(83, 17);
            this.NTF_L_Description.TabIndex = 8;
            this.NTF_L_Description.Text = "Description:";
            // 
            // NTF_TB_Description
            // 
            this.NTF_TB_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NTF_TB_Description.Location = new System.Drawing.Point(12, 386);
            this.NTF_TB_Description.Multiline = true;
            this.NTF_TB_Description.Name = "NTF_TB_Description";
            this.NTF_TB_Description.Size = new System.Drawing.Size(652, 197);
            this.NTF_TB_Description.TabIndex = 9;
            // 
            // NTF_B_UploadImage
            // 
            this.NTF_B_UploadImage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NTF_B_UploadImage.Image = ((System.Drawing.Image)(resources.GetObject("NTF_B_UploadImage.Image")));
            this.NTF_B_UploadImage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NTF_B_UploadImage.Location = new System.Drawing.Point(417, 273);
            this.NTF_B_UploadImage.Name = "NTF_B_UploadImage";
            this.NTF_B_UploadImage.Size = new System.Drawing.Size(247, 62);
            this.NTF_B_UploadImage.TabIndex = 7;
            this.NTF_B_UploadImage.Text = "Upload image";
            this.NTF_B_UploadImage.UseVisualStyleBackColor = true;
            this.NTF_B_UploadImage.Click += new System.EventHandler(this.NTF_B_UploadImage_Click);
            // 
            // NTF_PB_VehiclePhoto
            // 
            this.NTF_PB_VehiclePhoto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NTF_PB_VehiclePhoto.BackColor = System.Drawing.SystemColors.ControlDark;
            this.NTF_PB_VehiclePhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NTF_PB_VehiclePhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NTF_PB_VehiclePhoto.Image = ((System.Drawing.Image)(resources.GetObject("NTF_PB_VehiclePhoto.Image")));
            this.NTF_PB_VehiclePhoto.Location = new System.Drawing.Point(417, 63);
            this.NTF_PB_VehiclePhoto.Name = "NTF_PB_VehiclePhoto";
            this.NTF_PB_VehiclePhoto.Size = new System.Drawing.Size(247, 196);
            this.NTF_PB_VehiclePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NTF_PB_VehiclePhoto.TabIndex = 11;
            this.NTF_PB_VehiclePhoto.TabStop = false;
            this.NTF_PB_VehiclePhoto.Click += new System.EventHandler(this.NTF_PB_VehiclePhoto_Click);
            // 
            // NTF_L_VehiclePhoto
            // 
            this.NTF_L_VehiclePhoto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NTF_L_VehiclePhoto.AutoSize = true;
            this.NTF_L_VehiclePhoto.Location = new System.Drawing.Point(414, 33);
            this.NTF_L_VehiclePhoto.Name = "NTF_L_VehiclePhoto";
            this.NTF_L_VehiclePhoto.Size = new System.Drawing.Size(142, 17);
            this.NTF_L_VehiclePhoto.TabIndex = 6;
            this.NTF_L_VehiclePhoto.Text = "Vehicle photography:";
            this.NTF_L_VehiclePhoto.Click += new System.EventHandler(this.NTF_L_VehiclePhoto_Click);
            // 
            // NTF_B_Save
            // 
            this.NTF_B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NTF_B_Save.Location = new System.Drawing.Point(350, 610);
            this.NTF_B_Save.Name = "NTF_B_Save";
            this.NTF_B_Save.Size = new System.Drawing.Size(314, 58);
            this.NTF_B_Save.TabIndex = 11;
            this.NTF_B_Save.Text = "Save";
            this.NTF_B_Save.UseVisualStyleBackColor = true;
            this.NTF_B_Save.Click += new System.EventHandler(this.NTF_B_Save_Click);
            // 
            // NTF_B_Cancel
            // 
            this.NTF_B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NTF_B_Cancel.Location = new System.Drawing.Point(12, 610);
            this.NTF_B_Cancel.Name = "NTF_B_Cancel";
            this.NTF_B_Cancel.Size = new System.Drawing.Size(314, 58);
            this.NTF_B_Cancel.TabIndex = 10;
            this.NTF_B_Cancel.Text = "Cancel";
            this.NTF_B_Cancel.UseVisualStyleBackColor = true;
            this.NTF_B_Cancel.Click += new System.EventHandler(this.NTF_B_Cancel_Click);
            // 
            // NTF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 680);
            this.Controls.Add(this.NTF_B_Cancel);
            this.Controls.Add(this.NTF_B_Save);
            this.Controls.Add(this.NTF_L_VehiclePhoto);
            this.Controls.Add(this.NTF_PB_VehiclePhoto);
            this.Controls.Add(this.NTF_B_UploadImage);
            this.Controls.Add(this.NTF_TB_Description);
            this.Controls.Add(this.NTF_L_Description);
            this.Controls.Add(this.NTF_CheckB_Authorized);
            this.Controls.Add(this.NTF_L_Authorized);
            this.Controls.Add(this.NTF_TB_Weight);
            this.Controls.Add(this.NTF_L_Weight);
            this.Controls.Add(this.NTF_TB_LicensePlate);
            this.Controls.Add(this.NTF_L_LicensePlate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "NTF";
            this.Text = "NTF";
            this.Load += new System.EventHandler(this.NTF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NTF_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.NTF_PB_VehiclePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NTF_L_LicensePlate;
        private System.Windows.Forms.TextBox NTF_TB_LicensePlate;
        private System.Windows.Forms.TextBox NTF_TB_Weight;
        private System.Windows.Forms.Label NTF_L_Weight;
        private System.Windows.Forms.Label NTF_L_Authorized;
        private System.Windows.Forms.CheckBox NTF_CheckB_Authorized;
        private System.Windows.Forms.Label NTF_L_Description;
        private System.Windows.Forms.TextBox NTF_TB_Description;
        private System.Windows.Forms.Button NTF_B_UploadImage;
        private System.Windows.Forms.PictureBox NTF_PB_VehiclePhoto;
        private System.Windows.Forms.Label NTF_L_VehiclePhoto;
        private System.Windows.Forms.Button NTF_B_Save;
        private System.Windows.Forms.Button NTF_B_Cancel;
    }
}