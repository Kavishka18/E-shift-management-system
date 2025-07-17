namespace e_Shift_Management_Sytem.Customer
{
    partial class userDashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userDashboard));
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.Logout = new System.Windows.Forms.PictureBox();
            this.cusDetailsManagement = new System.Windows.Forms.PictureBox();
            this.CusTransportOperationManagement = new System.Windows.Forms.PictureBox();
            this.circularProgressBar = new CircularProgressBar.CircularProgressBar();
            this.lblTotalJobs = new System.Windows.Forms.Label();
            this.lblInProgressJobs = new System.Windows.Forms.Label();
            this.labelCustomerCount = new System.Windows.Forms.Label();
            this.circularProgressBarApproved = new CircularProgressBar.CircularProgressBar();
            this.labelApprovedCount = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusDetailsManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusTransportOperationManagement)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox6.Location = new System.Drawing.Point(-6, -4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(921, 50);
            this.pictureBox6.TabIndex = 12;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox8.Location = new System.Drawing.Point(-6, 470);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(884, 50);
            this.pictureBox8.TabIndex = 11;
            this.pictureBox8.TabStop = false;
            // 
            // Logout
            // 
            this.Logout.Image = ((System.Drawing.Image)(resources.GetObject("Logout.Image")));
            this.Logout.Location = new System.Drawing.Point(36, 322);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(106, 79);
            this.Logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Logout.TabIndex = 10;
            this.Logout.TabStop = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // cusDetailsManagement
            // 
            this.cusDetailsManagement.Image = ((System.Drawing.Image)(resources.GetObject("cusDetailsManagement.Image")));
            this.cusDetailsManagement.Location = new System.Drawing.Point(40, 84);
            this.cusDetailsManagement.Name = "cusDetailsManagement";
            this.cusDetailsManagement.Size = new System.Drawing.Size(106, 79);
            this.cusDetailsManagement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.cusDetailsManagement.TabIndex = 9;
            this.cusDetailsManagement.TabStop = false;
            this.cusDetailsManagement.Click += new System.EventHandler(this.cusDetailsManagement_Click);
            // 
            // CusTransportOperationManagement
            // 
            this.CusTransportOperationManagement.Image = ((System.Drawing.Image)(resources.GetObject("CusTransportOperationManagement.Image")));
            this.CusTransportOperationManagement.Location = new System.Drawing.Point(63, 221);
            this.CusTransportOperationManagement.Name = "CusTransportOperationManagement";
            this.CusTransportOperationManagement.Size = new System.Drawing.Size(58, 54);
            this.CusTransportOperationManagement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CusTransportOperationManagement.TabIndex = 13;
            this.CusTransportOperationManagement.TabStop = false;
            this.CusTransportOperationManagement.Click += new System.EventHandler(this.CusTransportOperationManagement_Click);
            // 
            // circularProgressBar
            // 
            this.circularProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar.AnimationSpeed = 500;
            this.circularProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.circularProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar.ForeColor = System.Drawing.Color.White;
            this.circularProgressBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circularProgressBar.InnerMargin = 2;
            this.circularProgressBar.InnerWidth = -1;
            this.circularProgressBar.Location = new System.Drawing.Point(305, 237);
            this.circularProgressBar.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar.Name = "circularProgressBar";
            this.circularProgressBar.OuterColor = System.Drawing.Color.WhiteSmoke;
            this.circularProgressBar.OuterMargin = -25;
            this.circularProgressBar.OuterWidth = 26;
            this.circularProgressBar.ProgressColor = System.Drawing.Color.Yellow;
            this.circularProgressBar.ProgressWidth = 25;
            this.circularProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar.Size = new System.Drawing.Size(197, 187);
            this.circularProgressBar.StartAngle = 270;
            this.circularProgressBar.SubscriptColor = System.Drawing.Color.White;
            this.circularProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar.SubscriptText = ".23";
            this.circularProgressBar.SuperscriptColor = System.Drawing.Color.White;
            this.circularProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar.SuperscriptText = "°C";
            this.circularProgressBar.TabIndex = 14;
            this.circularProgressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar.Value = 68;
            // 
            // lblTotalJobs
            // 
            this.lblTotalJobs.AutoSize = true;
            this.lblTotalJobs.Location = new System.Drawing.Point(636, 262);
            this.lblTotalJobs.Name = "lblTotalJobs";
            this.lblTotalJobs.Size = new System.Drawing.Size(0, 13);
            this.lblTotalJobs.TabIndex = 15;
            // 
            // lblInProgressJobs
            // 
            this.lblInProgressJobs.AutoSize = true;
            this.lblInProgressJobs.Location = new System.Drawing.Point(636, 322);
            this.lblInProgressJobs.Name = "lblInProgressJobs";
            this.lblInProgressJobs.Size = new System.Drawing.Size(0, 13);
            this.lblInProgressJobs.TabIndex = 16;
            // 
            // labelCustomerCount
            // 
            this.labelCustomerCount.AutoSize = true;
            this.labelCustomerCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelCustomerCount.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerCount.Location = new System.Drawing.Point(370, 322);
            this.labelCustomerCount.Name = "labelCustomerCount";
            this.labelCustomerCount.Size = new System.Drawing.Size(75, 16);
            this.labelCustomerCount.TabIndex = 17;
            this.labelCustomerCount.Text = "Customers";
            // 
            // circularProgressBarApproved
            // 
            this.circularProgressBarApproved.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBarApproved.AnimationSpeed = 500;
            this.circularProgressBarApproved.BackColor = System.Drawing.SystemColors.Control;
            this.circularProgressBarApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.circularProgressBarApproved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBarApproved.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circularProgressBarApproved.InnerMargin = 2;
            this.circularProgressBarApproved.InnerWidth = -1;
            this.circularProgressBarApproved.Location = new System.Drawing.Point(574, 237);
            this.circularProgressBarApproved.MarqueeAnimationSpeed = 2000;
            this.circularProgressBarApproved.Name = "circularProgressBarApproved";
            this.circularProgressBarApproved.OuterColor = System.Drawing.Color.WhiteSmoke;
            this.circularProgressBarApproved.OuterMargin = -25;
            this.circularProgressBarApproved.OuterWidth = 26;
            this.circularProgressBarApproved.ProgressColor = System.Drawing.Color.GreenYellow;
            this.circularProgressBarApproved.ProgressWidth = 25;
            this.circularProgressBarApproved.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBarApproved.Size = new System.Drawing.Size(197, 187);
            this.circularProgressBarApproved.StartAngle = 270;
            this.circularProgressBarApproved.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBarApproved.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBarApproved.SubscriptText = ".23";
            this.circularProgressBarApproved.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBarApproved.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBarApproved.SuperscriptText = "°C";
            this.circularProgressBarApproved.TabIndex = 18;
            this.circularProgressBarApproved.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBarApproved.Value = 68;
            // 
            // labelApprovedCount
            // 
            this.labelApprovedCount.AutoSize = true;
            this.labelApprovedCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelApprovedCount.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApprovedCount.Location = new System.Drawing.Point(642, 322);
            this.labelApprovedCount.Name = "labelApprovedCount";
            this.labelApprovedCount.Size = new System.Drawing.Size(72, 16);
            this.labelApprovedCount.TabIndex = 19;
            this.labelApprovedCount.Text = "Approved";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelTime.Location = new System.Drawing.Point(667, 62);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(76, 33);
            this.labelTime.TabIndex = 20;
            this.labelTime.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label1.Location = new System.Drawing.Point(260, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 44);
            this.label1.TabIndex = 21;
            this.label1.Text = "Warmly Welcome \r\n                      Our Customers";
            // 
            // userDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelApprovedCount);
            this.Controls.Add(this.circularProgressBarApproved);
            this.Controls.Add(this.labelCustomerCount);
            this.Controls.Add(this.lblInProgressJobs);
            this.Controls.Add(this.lblTotalJobs);
            this.Controls.Add(this.circularProgressBar);
            this.Controls.Add(this.CusTransportOperationManagement);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.cusDetailsManagement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "userDashboard";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusDetailsManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CusTransportOperationManagement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox Logout;
        private System.Windows.Forms.PictureBox cusDetailsManagement;
        private System.Windows.Forms.PictureBox CusTransportOperationManagement;
        private CircularProgressBar.CircularProgressBar circularProgressBar;
        private System.Windows.Forms.Label lblTotalJobs;
        private System.Windows.Forms.Label lblInProgressJobs;
        private System.Windows.Forms.Label labelCustomerCount;
        private CircularProgressBar.CircularProgressBar circularProgressBarApproved;
        private System.Windows.Forms.Label labelApprovedCount;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label1;
    }
}