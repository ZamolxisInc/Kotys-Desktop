namespace Kotys
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.activeToggle = new MetroFramework.Controls.MetroToggle();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.deviceIDLabel = new MetroFramework.Controls.MetroLabel();
            this.timerLastSeen = new System.Windows.Forms.Timer(this.components);
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerKeylogger = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(194, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // activeToggle
            // 
            this.activeToggle.AutoSize = true;
            this.activeToggle.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.activeToggle.FontWeight = MetroFramework.MetroLinkWeight.Light;
            this.activeToggle.Location = new System.Drawing.Point(194, 56);
            this.activeToggle.MinimumSize = new System.Drawing.Size(100, 40);
            this.activeToggle.Name = "activeToggle";
            this.activeToggle.Size = new System.Drawing.Size(100, 40);
            this.activeToggle.Style = MetroFramework.MetroColorStyle.Blue;
            this.activeToggle.TabIndex = 2;
            this.activeToggle.Tag = "";
            this.activeToggle.Text = "Off";
            this.activeToggle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.activeToggle.UseSelectable = true;
            this.activeToggle.CheckedChanged += new System.EventHandler(this.activeToggle_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Kotys";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogIn.Font = new System.Drawing.Font("Orator Std", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogIn.ForeColor = System.Drawing.Color.White;
            this.buttonLogIn.Location = new System.Drawing.Point(44, 89);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(95, 79);
            this.buttonLogIn.TabIndex = 3;
            this.buttonLogIn.Text = "LogIn";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // deviceIDLabel
            // 
            this.deviceIDLabel.AutoSize = true;
            this.deviceIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.deviceIDLabel.ForeColor = System.Drawing.Color.Black;
            this.deviceIDLabel.Location = new System.Drawing.Point(63, 188);
            this.deviceIDLabel.Name = "deviceIDLabel";
            this.deviceIDLabel.Size = new System.Drawing.Size(51, 19);
            this.deviceIDLabel.TabIndex = 4;
            this.deviceIDLabel.Text = "000000";
            this.deviceIDLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // timerLastSeen
            // 
            this.timerLastSeen.Tick += new System.EventHandler(this.timerLastSeen_Tick);
            // 
            // buttonSettings
            // 
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Orator Std", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSettings.Location = new System.Drawing.Point(44, 89);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(94, 79);
            this.buttonSettings.TabIndex = 6;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Visible = false;
            this.buttonSettings.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOut.Font = new System.Drawing.Font("Orator Std", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogOut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLogOut.Location = new System.Drawing.Point(44, 60);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(94, 23);
            this.buttonLogOut.TabIndex = 7;
            this.buttonLogOut.Text = "LogOut";
            this.buttonLogOut.UseVisualStyleBackColor = false;
            this.buttonLogOut.Visible = false;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerKeylogger
            // 
            this.timerKeylogger.Tick += new System.EventHandler(this.timerKeylogger_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 216);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.deviceIDLabel);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.activeToggle);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Tag = "";
            this.Text = "Kotys - Client";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroToggle activeToggle;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button buttonLogIn;
        private MetroFramework.Controls.MetroLabel deviceIDLabel;
        private System.Windows.Forms.Timer timerLastSeen;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerKeylogger;

    }
}

