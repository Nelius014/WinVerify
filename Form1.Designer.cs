namespace WinVerify
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSite = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeNumber = new System.Windows.Forms.TextBox();
            this.lstAddInfo = new System.Windows.Forms.ListBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.radPictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.drpCameras = new System.Windows.Forms.ComboBox();
            this.btnStartCam = new System.Windows.Forms.Button();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblSite = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSite);
            this.groupBox1.Controls.Add(this.lblDevice);
            this.groupBox1.Controls.Add(this.btnSite);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.lblFullName);
            this.groupBox1.Controls.Add(this.lblSuccess);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEmployeeNumber);
            this.groupBox1.Controls.Add(this.lstAddInfo);
            this.groupBox1.Controls.Add(this.btnCheckIn);
            this.groupBox1.Controls.Add(this.radPictureBox1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnCapture);
            this.groupBox1.Controls.Add(this.drpCameras);
            this.groupBox1.Controls.Add(this.btnStartCam);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 537);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSite
            // 
            this.btnSite.Location = new System.Drawing.Point(269, 16);
            this.btnSite.Name = "btnSite";
            this.btnSite.Size = new System.Drawing.Size(467, 33);
            this.btnSite.TabIndex = 12;
            this.btnSite.Text = "Set Site";
            this.btnSite.UseVisualStyleBackColor = true;
            this.btnSite.Click += new System.EventHandler(this.btnSite_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(28, 466);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(208, 34);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "Message :";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(266, 357);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(55, 13);
            this.lblFullName.TabIndex = 10;
            this.lblFullName.Text = "Fullname :";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Location = new System.Drawing.Point(28, 438);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(54, 13);
            this.lblSuccess.TabIndex = 9;
            this.lblSuccess.Text = "Success :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Employee Number : ";
            // 
            // txtEmployeeNumber
            // 
            this.txtEmployeeNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeNumber.Location = new System.Drawing.Point(133, 354);
            this.txtEmployeeNumber.Name = "txtEmployeeNumber";
            this.txtEmployeeNumber.Size = new System.Drawing.Size(100, 20);
            this.txtEmployeeNumber.TabIndex = 7;
            // 
            // lstAddInfo
            // 
            this.lstAddInfo.FormattingEnabled = true;
            this.lstAddInfo.Location = new System.Drawing.Point(269, 389);
            this.lstAddInfo.Name = "lstAddInfo";
            this.lstAddInfo.Size = new System.Drawing.Size(467, 134);
            this.lstAddInfo.TabIndex = 6;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(25, 383);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(208, 48);
            this.btnCheckIn.TabIndex = 5;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // radPictureBox1
            // 
            this.radPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("radPictureBox1.Image")));
            this.radPictureBox1.Location = new System.Drawing.Point(25, 180);
            this.radPictureBox1.Name = "radPictureBox1";
            this.radPictureBox1.Size = new System.Drawing.Size(208, 160);
            this.radPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.radPictureBox1.TabIndex = 4;
            this.radPictureBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(269, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(467, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(25, 109);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(208, 52);
            this.btnCapture.TabIndex = 2;
            this.btnCapture.Text = "Capture Image";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // drpCameras
            // 
            this.drpCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpCameras.FormattingEnabled = true;
            this.drpCameras.Location = new System.Drawing.Point(25, 19);
            this.drpCameras.Name = "drpCameras";
            this.drpCameras.Size = new System.Drawing.Size(208, 21);
            this.drpCameras.TabIndex = 1;
            // 
            // btnStartCam
            // 
            this.btnStartCam.Location = new System.Drawing.Point(25, 55);
            this.btnStartCam.Name = "btnStartCam";
            this.btnStartCam.Size = new System.Drawing.Size(208, 48);
            this.btnStartCam.TabIndex = 0;
            this.btnStartCam.Text = "Start Camera";
            this.btnStartCam.UseVisualStyleBackColor = true;
            this.btnStartCam.Click += new System.EventHandler(this.btnStartCam_Click);
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(28, 510);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(61, 13);
            this.lblDevice.TabIndex = 13;
            this.lblDevice.Text = "Device ID :";
            this.lblDevice.Visible = false;
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(266, 55);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(68, 13);
            this.lblSite.TabIndex = 14;
            this.lblSite.Text = "Current Site :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Win Verify";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStartCam;
        private System.Windows.Forms.PictureBox radPictureBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.ComboBox drpCameras;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmployeeNumber;
        private System.Windows.Forms.ListBox lstAddInfo;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Button btnSite;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblSite;
    }
}

