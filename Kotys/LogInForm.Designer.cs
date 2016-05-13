namespace Kotys
{
    partial class LogInForm
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
            this.textParola = new MetroFramework.Controls.MetroTextBox();
            this.metroTextButton1 = new MetroFramework.Controls.MetroTextBox.MetroTextButton();
            this.textUser = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // textParola
            // 
            // 
            // 
            // 
            this.textParola.CustomButton.Image = null;
            this.textParola.CustomButton.Location = new System.Drawing.Point(163, 1);
            this.textParola.CustomButton.Name = "";
            this.textParola.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.textParola.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textParola.CustomButton.TabIndex = 1;
            this.textParola.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textParola.CustomButton.UseSelectable = true;
            this.textParola.CustomButton.Visible = false;
            this.textParola.Lines = new string[] {
        "Password"};
            this.textParola.Location = new System.Drawing.Point(23, 148);
            this.textParola.MaxLength = 32767;
            this.textParola.Name = "textParola";
            this.textParola.PasswordChar = 'Z';
            this.textParola.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textParola.SelectedText = "";
            this.textParola.SelectionLength = 0;
            this.textParola.SelectionStart = 0;
            this.textParola.ShortcutsEnabled = true;
            this.textParola.Size = new System.Drawing.Size(189, 27);
            this.textParola.TabIndex = 1;
            this.textParola.Text = "Password";
            this.textParola.UseSelectable = true;
            this.textParola.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textParola.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextButton1
            // 
            this.metroTextButton1.Image = null;
            this.metroTextButton1.Location = new System.Drawing.Point(234, 102);
            this.metroTextButton1.Name = "metroTextButton1";
            this.metroTextButton1.Size = new System.Drawing.Size(82, 61);
            this.metroTextButton1.TabIndex = 2;
            this.metroTextButton1.Text = "LogIn";
            this.metroTextButton1.UseSelectable = true;
            this.metroTextButton1.UseVisualStyleBackColor = true;
            this.metroTextButton1.Click += new System.EventHandler(this.metroTextButton1_Click);
            // 
            // textUser
            // 
            // 
            // 
            // 
            this.textUser.CustomButton.Image = null;
            this.textUser.CustomButton.Location = new System.Drawing.Point(163, 1);
            this.textUser.CustomButton.Name = "";
            this.textUser.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.textUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textUser.CustomButton.TabIndex = 1;
            this.textUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textUser.CustomButton.UseSelectable = true;
            this.textUser.CustomButton.Visible = false;
            this.textUser.Lines = new string[] {
        "Username"};
            this.textUser.Location = new System.Drawing.Point(23, 102);
            this.textUser.MaxLength = 32767;
            this.textUser.Name = "textUser";
            this.textUser.PasswordChar = '\0';
            this.textUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textUser.SelectedText = "";
            this.textUser.SelectionLength = 0;
            this.textUser.SelectionStart = 0;
            this.textUser.ShortcutsEnabled = true;
            this.textUser.Size = new System.Drawing.Size(189, 27);
            this.textUser.TabIndex = 3;
            this.textUser.Text = "Username";
            this.textUser.UseSelectable = true;
            this.textUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 217);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.metroTextButton1);
            this.Controls.Add(this.textParola);
            this.Name = "LogInForm";
            this.Text = "Log In - Kotys Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogInForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox textParola;
        private MetroFramework.Controls.MetroTextBox.MetroTextButton metroTextButton1;
        private MetroFramework.Controls.MetroTextBox textUser;
    }
}