using MetroFramework.Forms;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kotys
{
    public partial class LogInForm : MetroForm
    {
        public Form1 RefToForm1 { get; set; }
        DBConnect dbConnect = new DBConnect();

        public LogInForm()
        {
            InitializeComponent();
        }

        private void LogInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefToForm1.Show();
        }

        private void metroTextButton1_Click(object sender, EventArgs e)
        {
            bool hasBeenLogged = dbConnect.LogIn(textUser.Text, textParola.Text);
            if(hasBeenLogged)
            {
                MetroMessageBox.Show(Owner, "You have been logged in with succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefToForm1.logat = true;
                sendUserData();
                RefToForm1.initialise();
                //log to db reports
                DateTime dateTime = DateTime.UtcNow.Date;
                string data = dateTime.ToString("dd/MM/yyyy");
                string time = DateTime.Now.ToString("h:mm:ss");
                dbConnect.InsertReport(RefToForm1.deviceID, "Logged in as: "+ textUser.Text +"", data, time);
                RefToForm1.writeLog(RefToForm1.deviceID, "Logged in as: " + textUser.Text + "", data, time);
                this.Close();
            }
            else
            {
                MetroMessageBox.Show(Owner, "Wrong user or passoword!", "Error");
                DateTime dateTime = DateTime.UtcNow.Date;
                string data = dateTime.ToString("dd/MM/yyyy");
                string time = DateTime.Now.ToString("h:mm:ss");
                dbConnect.InsertReport(RefToForm1.deviceID, "Failed to log in as: " + textUser.Text + "", data, time);
                RefToForm1.writeLog(RefToForm1.deviceID, "Failed to log in as: " + textUser.Text + "", data, time);
            }
        }

        void sendUserData()
        {

           RefToForm1.Guser = textUser.Text;
           RefToForm1.GNume = dbConnect.GetUserName(textUser.Text);
           
        }
    }
}
