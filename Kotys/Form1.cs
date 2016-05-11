using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace Kotys
{
    public partial class Form1 : MetroForm
    {
        public bool logat { get; set; }

        public string Guser { get; set; }
        public string GNume { get; set; }
        public string GPrenume { get; set; }
        public string GRank { get; set; }

        public int timerInterval = 50000;

        public bool isActive;

        DBConnect dbConnect = new DBConnect();

        public string deviceID;

        public Form1()
        {
            
            InitializeComponent();
            deviceIDLabel.Text = deviceID;
            DateTime dateTime = DateTime.UtcNow.Date;
            string data = dateTime.ToString("dd/MM/yyyy");
            string time = DateTime.Now.ToString("h:mm:ss");
            writeLog(deviceID, "Device started", data, time);
            if (isActive)
            {
                if (dbConnect.InsertReport(deviceID, "Device started", data, time) == true)
                {
                    
                }
                else
                {
                    writeReport(deviceID, "Device started", data, time);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initialise();
            readDataFile();
            WriteData();
            LastSeen();
            getDevIDData();
            takeSS();
        }

    
        public void initialise()
        {
            if(logat)
            {
                buttonLogIn.Visible = false;
                buttonLogOut.Visible = true;
                activeToggle.Enabled = true;
                deviceIDLabel.Text = deviceID + " ~ " + Guser;
                buttonSettings.Visible = true;
                WriteData();

            }else
            {
                buttonLogIn.Visible = true;
                buttonLogOut.Visible = false;
                activeToggle.Enabled = false;
                buttonSettings.Visible = false;
            }
            LastSeen();
            getTimerIntervalData();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            new CancelEventArgs().Cancel = true;
            this.Hide();
            ShowInTaskbar = true;
        }

         private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

         private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
         {
             this.Show();
            
         }

         private void buttonLogIn_Click(object sender, EventArgs e)
         {
             LogInForm lf = new LogInForm();
             lf.RefToForm1 = this;
             lf.Show();
             this.Hide();
         }
       
        public bool FileDataExists()
         {
             if (File.Exists("data.dat"))
             {
                 return true;
             }else
             {
                 return false;
             }
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

        public void WriteData()
        {
            if(FileDataExists())
            {
                try
                {
                    File.Delete("data.dat");
                    using (StreamWriter w = File.AppendText("data.dat"))
                    {
                        w.WriteLine(isActive.ToString());
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }else
            {
                newDevice();
                using (StreamWriter w = File.AppendText("data.dat"))
                {
                    w.WriteLine(isActive.ToString());
                }
               
            }
        }

        private void activeToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (activeToggle.Checked == true)
            {
                isActive = true;
                dbConnect.UpdateActive(deviceID, true);

                 DateTime dateTime = DateTime.UtcNow.Date;
                  string data = dateTime.ToString("dd/MM/yyyy");
                  string time = DateTime.Now.ToString("h:mm:ss");
                  dbConnect.InsertReport(deviceID, "Device is now active", data, time);
                  writeLog(deviceID, "Device is now active", data, time);

            }
            else
            {
                isActive = false;
                dbConnect.UpdateActive(deviceID, false);
                DateTime dateTime = DateTime.UtcNow.Date;
                string data = dateTime.ToString("dd/MM/yyyy");
                string time = DateTime.Now.ToString("h:mm:ss");
                dbConnect.InsertReport(deviceID, "Device is not active anymore", data, time);
                writeLog(deviceID, "Device is not active anymore", data, time);
            }
            WriteData();
            LastSeen();
        }

        public void readDataFile()
        {
            if (FileDataExists())
            {
                using (StreamReader sr = new StreamReader("data.dat"))
                {
                    string s2 = sr.ReadLine();

                    if (s2 == "True")
                    {
                        isActive = true;
                        activeToggle.Checked = true;
                    }
                    else
                    {
                        isActive = false;
                        activeToggle.Checked = false;
                    }
                }
            }
        }

        public void newDevice()
        {

        }

        public void LastSeen()
        {
            dbConnect.UpdateLastSeen(deviceID);

             DateTime dateTime = DateTime.UtcNow.Date;
             string data = dateTime.ToString("dd/MM/yyyy");
             string time = DateTime.Now.ToString("h:mm:ss");
            writeLog(deviceID, "Is still online",data,time);
           
        }

        private void timerLastSeen_Tick(object sender, EventArgs e)
        {
            LastSeen();
        }
       
        public void getTimerIntervalData()
        {
            if (FileIntervalExists())
            {
                using (StreamReader sr = new StreamReader("timer.dat"))
                {
                    string s2 = sr.ReadLine();
                    int interval = int.Parse(s2);
                    timerInterval = interval;
                    timerLastSeen.Interval = interval;
                    timerLastSeen.Start();
                }
            }
        }

        public void getDevIDData()
        {
            if (FileDeviceExists())
            {
                using (StreamReader sr = new StreamReader("device.dat"))
                {
                    string s2 = sr.ReadLine();
                    deviceID = s2;
                }
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
//worng one
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSettings fs = new FormSettings();
            fs.RefToForm1 = this;
            fs.Show();
            //la final call these and close form2 
            /* getdevidata
             * gettimerintervaldata
             * */
        }

        private void sendReport()
        {

        }

        private void writeReport(string devID, string info, string data, string time)
        {
            try
            {
                
                using (StreamWriter w = File.AppendText("querycmds.dat"))
                {
                    w.WriteLine(devID + "~" + info + "~" + data + "~" + time +";");
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.ToString());
            }
        }

        public void writeLog(string devID, string info, string data, string time)
        {
            try
            {

                using (StreamWriter w = File.AppendText("logcmds.dat"))
                {
                    w.WriteLine(devID + "~" + info + "~" + data + "~" + time + ";");
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.ToString());
            }
        }

        public void takeSS()
        {
            System.IO.FileInfo file = new System.IO.FileInfo(string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                      @"\Kotys\"));
            file.Directory.Create();
            Bitmap memoryImage = new Bitmap(1900, 1600);
            Size s = new Size(memoryImage.Width, memoryImage.Height);

          
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

           
            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);
            DateTime dateTime = DateTime.UtcNow.Date;
            string data = dateTime.ToString("dd/MM/yyyy");
            string time = DateTime.Now.ToString("h/mm/ss");
            //That's it! Save the image in the directory and this will work like charm. 
            string str = "";
            string FlName = "";
            try
            {
                FlName = "Screenshot-" + deviceID + "-" + data + "-" + time + ".png";
                str = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                      @"\Kotys\" + FlName);
            }
            catch (Exception er)
            {
               
            }

            // Save it! 
            
            memoryImage.Save(str);

            // Write the message, 
           
            // Pause the program to show the message. 
            writeLog(deviceID, "A screenshot has been taken. Name:" + FlName, data, time);
            uploadSS(str, FlName);
        }

        public void uploadSS(string dir, string name)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string data = dateTime.ToString("dd/MM/yyyy");
            string time = DateTime.Now.ToString("h/mm/ss");
            System.Net.WebClient Client = new System.Net.WebClient ();
            Client.Headers.Add("Content-Type","binary/octet-stream");
            byte[] result = Client.UploadFile ("http://127.0.0.1/machines/uploadss.php","POST",dir);
            String s = System.Text.Encoding .UTF8 .GetString (result,0,result.Length );
           
            dbConnect.InsertReport(deviceID, "Screenshot taken", data, time);
            int lastId = dbConnect.getLastReportRepID(deviceID);
            dbConnect.InsertReportInfo(lastId.ToString(), "Screenshot take", "http://127.0.0.1/machines/ss/"+name, "");
            
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string data = dateTime.ToString("dd/MM/yyyy");
            string time = DateTime.Now.ToString("h:mm:ss");
            logat = false;
            initialise();
            dbConnect.InsertReport(deviceID, "Logged Out", data, time);
            writeLog(deviceID, "Logged Out", data, time);
        }
    }
}
