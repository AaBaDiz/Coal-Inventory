namespace Dashboard.Forms.New
{
    partial class NEF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NEF));
            this.NEF_L_EntryPhoto = new System.Windows.Forms.Label();
            this.NEF_PB_EntryPhoto = new System.Windows.Forms.PictureBox();
            this.NEF_B_UploadImage = new System.Windows.Forms.Button();
            this.NTF_B_Cancel = new System.Windows.Forms.Button();
            this.NEF_B_Save = new System.Windows.Forms.Button();
            this.NEF_TB_Weight = new System.Windows.Forms.TextBox();
            this.NEF_ComboB_TruckPlate = new System.Windows.Forms.ComboBox();
            this.NEF_ComboB_DriverDNI = new System.Windows.Forms.ComboBox();
            this.NEF_L_Weight = new System.Windows.Forms.Label();
            this.NEF_L_Truck = new System.Windows.Forms.Label();
            this.NEF_L_Driver = new System.Windows.Forms.Label();
            this.NEF_DTP_Date = new System.Windows.Forms.DateTimePicker();
            this.NEF_L_Date = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NEF_PB_EntryPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // NEF_L_EntryPhoto
            // 
            this.NEF_L_EntryPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.NEF_L_EntryPhoto.AutoSize = true;
            this.NEF_L_EntryPhoto.Location = new System.Drawing.Point(12, 9);
            this.NEF_L_EntryPhoto.Name = "NEF_L_EntryPhoto";
            this.NEF_L_EntryPhoto.Size = new System.Drawing.Size(129, 17);
            this.NEF_L_EntryPhoto.TabIndex = 0;
            this.NEF_L_EntryPhoto.Text = "Entry photography:";
            // 
            // NEF_PB_EntryPhoto
            // 
            this.NEF_PB_EntryPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.NEF_PB_EntryPhoto.BackColor = System.Drawing.SystemColors.ControlDark;
            this.NEF_PB_EntryPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NEF_PB_EntryPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NEF_PB_EntryPhoto.Image = ((System.Drawing.Image)(resources.GetObject("NEF_PB_EntryPhoto.Image")));
            this.NEF_PB_EntryPhoto.Location = new System.Drawing.Point(91, 39);
            this.NEF_PB_EntryPhoto.Name = "NEF_PB_EntryPhoto";
            this.NEF_PB_EntryPhoto.Size = new System.Drawing.Size(568, 312);
            this.NEF_PB_EntryPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NEF_PB_EntryPhoto.TabIndex = 54;
            this.NEF_PB_EntryPhoto.TabStop = false;
            // 
            // NEF_B_UploadImage
            // 
            this.NEF_B_UploadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.NEF_B_UploadImage.Image = ((System.Drawing.Image)(resources.GetObject("NEF_B_UploadImage.Image")));
            this.NEF_B_UploadImage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NEF_B_UploadImage.Location = new System.Drawing.Point(91, 357);
            this.NEF_B_UploadImage.Name = "NEF_B_UploadImage";
            this.NEF_B_UploadImage.Size = new System.Drawing.Size(568, 58);
            this.NEF_B_UploadImage.TabIndex = 1;
            this.NEF_B_UploadImage.Text = "Upload image";
            this.NEF_B_UploadImage.UseVisualStyleBackColor = true;
            this.NEF_B_UploadImage.Click += new System.EventHandler(this.NEF_B_UploadImage_Click);
            // 
            // NTF_B_Cancel
            // 
            this.NTF_B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NTF_B_Cancel.Location = new System.Drawing.Point(12, 643);
            this.NTF_B_Cancel.Name = "NTF_B_Cancel";
            this.NTF_B_Cancel.Size = new System.Drawing.Size(336, 46);
            this.NTF_B_Cancel.TabIndex = 10;
            this.NTF_B_Cancel.Text = "Cancel";
            this.NTF_B_Cancel.UseVisualStyleBackColor = true;
            this.NTF_B_Cancel.Click += new System.EventHandler(this.NTF_B_Cancel_Click);
            // 
            // NEF_B_Save
            // 
            this.NEF_B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NEF_B_Save.Location = new System.Drawing.Point(354, 643);
            this.NEF_B_Save.Name = "NEF_B_Save";
            this.NEF_B_Save.Size = new System.Drawing.Size(359, 46);
            this.NEF_B_Save.TabIndex = 11;
            this.NEF_B_Save.Text = "Save";
            this.NEF_B_Save.UseVisualStyleBackColor = true;
            this.NEF_B_Save.Click += new System.EventHandler(this.NEF_B_Save_Click);
            // 
            // NEF_TB_Weight
            // 
            this.NEF_TB_Weight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NEF_TB_Weight.Location = new System.Drawing.Point(313, 531);
            this.NEF_TB_Weight.Name = "NEF_TB_Weight";
            this.NEF_TB_Weight.Size = new System.Drawing.Size(397, 22);
            this.NEF_TB_Weight.TabIndex = 7;
            // 
            // NEF_ComboB_TruckPlate
            // 
            this.NEF_ComboB_TruckPlate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NEF_ComboB_TruckPlate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NEF_ComboB_TruckPlate.FormattingEnabled = true;
            this.NEF_ComboB_TruckPlate.Location = new System.Drawing.Point(313, 487);
            this.NEF_ComboB_TruckPlate.MaxDropDownItems = 100;
            this.NEF_ComboB_TruckPlate.Name = "NEF_ComboB_TruckPlate";
            this.NEF_ComboB_TruckPlate.Size = new System.Drawing.Size(397, 24);
            this.NEF_ComboB_TruckPlate.TabIndex = 5;
            // 
            // NEF_ComboB_DriverDNI
            // 
            this.NEF_ComboB_DriverDNI.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NEF_ComboB_DriverDNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NEF_ComboB_DriverDNI.FormattingEnabled = true;
            this.NEF_ComboB_DriverDNI.Location = new System.Drawing.Point(313, 445);
            this.NEF_ComboB_DriverDNI.MaxDropDownItems = 100;
            this.NEF_ComboB_DriverDNI.Name = "NEF_ComboB_DriverDNI";
            this.NEF_ComboB_DriverDNI.Size = new System.Drawing.Size(397, 24);
            this.NEF_ComboB_DriverDNI.TabIndex = 3;
            // 
            // NEF_L_Weight
            // 
            this.NEF_L_Weight.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.NEF_L_Weight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NEF_L_Weight.AutoSize = true;
            this.NEF_L_Weight.Location = new System.Drawing.Point(9, 534);
            this.NEF_L_Weight.Name = "NEF_L_Weight";
            this.NEF_L_Weight.Size = new System.Drawing.Size(85, 17);
            this.NEF_L_Weight.TabIndex = 6;
            this.NEF_L_Weight.Text = "Weight (kg):";
            // 
            // NEF_L_Truck
            // 
            this.NEF_L_Truck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NEF_L_Truck.AutoSize = true;
            this.NEF_L_Truck.Location = new System.Drawing.Point(9, 490);
            this.NEF_L_Truck.Name = "NEF_L_Truck";
            this.NEF_L_Truck.Size = new System.Drawing.Size(83, 17);
            this.NEF_L_Truck.TabIndex = 4;
            this.NEF_L_Truck.Text = "Truck plate:";
            this.NEF_L_Truck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NEF_L_Driver
            // 
            this.NEF_L_Driver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NEF_L_Driver.AutoSize = true;
            this.NEF_L_Driver.Location = new System.Drawing.Point(9, 448);
            this.NEF_L_Driver.Name = "NEF_L_Driver";
            this.NEF_L_Driver.Size = new System.Drawing.Size(77, 17);
            this.NEF_L_Driver.TabIndex = 2;
            this.NEF_L_Driver.Text = "Driver DNI:";
            // 
            // NEF_DTP_Date
            // 
            this.NEF_DTP_Date.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NEF_DTP_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.NEF_DTP_Date.Location = new System.Drawing.Point(313, 571);
            this.NEF_DTP_Date.Name = "NEF_DTP_Date";
            this.NEF_DTP_Date.Size = new System.Drawing.Size(397, 22);
            this.NEF_DTP_Date.TabIndex = 9;
            // 
            // NEF_L_Date
            // 
            this.NEF_L_Date.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.NEF_L_Date.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NEF_L_Date.AutoSize = true;
            this.NEF_L_Date.Location = new System.Drawing.Point(9, 576);
            this.NEF_L_Date.Name = "NEF_L_Date";
            this.NEF_L_Date.Size = new System.Drawing.Size(42, 17);
            this.NEF_L_Date.TabIndex = 8;
            this.NEF_L_Date.Text = "Date:";
            // 
            // NEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 702);
            this.Controls.Add(this.NEF_L_Date);
            this.Controls.Add(this.NEF_DTP_Date);
            this.Controls.Add(this.NEF_L_EntryPhoto);
            this.Controls.Add(this.NEF_PB_EntryPhoto);
            this.Controls.Add(this.NEF_B_UploadImage);
            this.Controls.Add(this.NTF_B_Cancel);
            this.Controls.Add(this.NEF_B_Save);
            this.Controls.Add(this.NEF_TB_Weight);
            this.Controls.Add(this.NEF_ComboB_TruckPlate);
            this.Controls.Add(this.NEF_ComboB_DriverDNI);
            this.Controls.Add(this.NEF_L_Weight);
            this.Controls.Add(this.NEF_L_Truck);
            this.Controls.Add(this.NEF_L_Driver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "NEF";
            this.Text = "New entry";
            this.Load += new System.EventHandler(this.NEF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NEF_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.NEF_PB_EntryPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NEF_L_EntryPhoto;
        private System.Windows.Forms.PictureBox NEF_PB_EntryPhoto;
        private System.Windows.Forms.Button NEF_B_UploadImage;
        private System.Windows.Forms.Button NTF_B_Cancel;
        private System.Windows.Forms.Button NEF_B_Save;
        private System.Windows.Forms.TextBox NEF_TB_Weight;
        private System.Windows.Forms.ComboBox NEF_ComboB_TruckPlate;
        private System.Windows.Forms.ComboBox NEF_ComboB_DriverDNI;
        private System.Windows.Forms.Label NEF_L_Weight;
        private System.Windows.Forms.Label NEF_L_Truck;
        private System.Windows.Forms.Label NEF_L_Driver;
        private System.Windows.Forms.DateTimePicker NEF_DTP_Date;
        private System.Windows.Forms.Label NEF_L_Date;
    }
}