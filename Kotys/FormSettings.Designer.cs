namespace Kotys
{
    partial class FormSettings
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
            this.textDevID = new MetroFramework.Controls.MetroTextBox();
            this.textInterval = new MetroFramework.Controls.MetroTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // textDevID
            // 
            // 
            // 
            // 
            this.textDevID.CustomButton.Image = null;
            this.textDevID.CustomButton.Location = new System.Drawing.Point(124, 1);
            this.textDevID.CustomButton.Name = "";
            this.textDevID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textDevID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textDevID.CustomButton.TabIndex = 1;
            this.textDevID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textDevID.CustomButton.UseSelectable = true;
            this.textDevID.CustomButton.Visible = false;
            this.textDevID.Lines = new string[] {
        "devid"};
            this.textDevID.Location = new System.Drawing.Point(64, 115);
            this.textDevID.MaxLength = 32767;
            this.textDevID.Name = "textDevID";
            this.textDevID.PasswordChar = '\0';
            this.textDevID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textDevID.SelectedText = "";
            this.textDevID.SelectionLength = 0;
            this.textDevID.SelectionStart = 0;
            this.textDevID.ShortcutsEnabled = true;
            this.textDevID.Size = new System.Drawing.Size(146, 23);
            this.textDevID.TabIndex = 0;
            this.textDevID.Text = "devid";
            this.textDevID.UseSelectable = true;
            this.textDevID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textDevID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textInterval
            // 
            // 
            // 
            // 
            this.textInterval.CustomButton.Image = null;
            this.textInterval.CustomButton.Location = new System.Drawing.Point(124, 1);
            this.textInterval.CustomButton.Name = "";
            this.textInterval.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textInterval.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textInterval.CustomButton.TabIndex = 1;
            this.textInterval.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textInterval.CustomButton.UseSelectable = true;
            this.textInterval.CustomButton.Visible = false;
            this.textInterval.Lines = new string[] {
        "Interval"};
            this.textInterval.Location = new System.Drawing.Point(64, 181);
            this.textInterval.MaxLength = 32767;
            this.textInterval.Name = "textInterval";
            this.textInterval.PasswordChar = '\0';
            this.textInterval.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textInterval.SelectedText = "";
            this.textInterval.SelectionLength = 0;
            this.textInterval.SelectionStart = 0;
            this.textInterval.ShortcutsEnabled = true;
            this.textInterval.Size = new System.Drawing.Size(146, 23);
            this.textInterval.TabIndex = 1;
            this.textInterval.Text = "Interval";
            this.textInterval.UseSelectable = true;
            this.textInterval.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textInterval.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Orator Std", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(328, 230);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(105, 46);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save settings";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(11, 93);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(59, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "DeviceID";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(9, 159);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(77, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Interval(ms)";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 279);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textInterval);
            this.Controls.Add(this.textDevID);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox textDevID;
        private MetroFramework.Controls.MetroTextBox textInterval;
        private System.Windows.Forms.Button buttonSave;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}