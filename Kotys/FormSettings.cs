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
using System.IO;

namespace Kotys
{
    public partial class FormSettings : MetroForm
    {
        public Form1 RefToForm1;
        public string Sinterval;
        public string sDevId;
        public FormSettings()
        {
            InitializeComponent();
        }

        public bool FileDeviceExists()
        {
            if (File.Exists("device.dat"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool FileIntervalExists()
        {
            if (File.Exists("timer.dat"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            if (FileIntervalExists())
            {
                using (StreamReader sr = new StreamReader("timer.dat"))
                {
                    string s2 = sr.ReadLine();
                    Sinterval =s2;
                }
            }

            if (FileDeviceExists())
            {
                using (StreamReader sr = new StreamReader("device.dat"))
                {
                    string s2 = sr.ReadLine();
                    sDevId = s2;
                }
            }
            textDevID.Text = sDevId;
            textInterval.Text = Sinterval;
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
             if(FileDeviceExists())
            {
                try
                {
                    File.Delete("device.dat");
                    using (StreamWriter w = File.AppendText("device.dat"))
                    {
                        w.WriteLine(textDevID.Text);
                    }
                }
                 catch(Exception s)
                {
                    MessageBox.Show(s.ToString());
                }
               
            }else
            {
                
                using (StreamWriter w = File.AppendText("device.dat"))
                {
                    w.WriteLine(textDevID.Text);
                }
               
            }

             if (FileIntervalExists())
             {
                 try
                 {
                     File.Delete("timer.dat");
                     using (StreamWriter w = File.AppendText("timer.dat"))
                     {
                         w.WriteLine(textInterval.Text);
                     }
                 }
                 catch (Exception d)
                 {
                     MessageBox.Show(d.ToString());
                 }

             }
             else
             {

                 using (StreamWriter w = File.AppendText("timer.dat"))
                 {
                     w.WriteLine(textInterval.Text);
                 }

             }
             DBConnect dbConnect = new DBConnect();
             DateTime dateTime = DateTime.UtcNow.Date;
             string data = dateTime.ToString("dd/MM/yyyy");
             string time = DateTime.Now.ToString("h:mm:ss");
             dbConnect.InsertReport(RefToForm1.deviceID, "Settings applied(interval:" +textInterval.Text+ ";devID:" + textDevID.Text + ")", data, time);
             RefToForm1.writeLog(RefToForm1.deviceID, "Settings applied(interval:" + textInterval.Text + ";devID:" + textDevID.Text + ")", data, time);
             this.Close();
        
        }

            
           
        }
    }

