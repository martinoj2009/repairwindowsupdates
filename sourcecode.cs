using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;

namespace Repair_Windows_Updates
{
    public partial class Form1 : Form
    {
        //This is a boolean that is checked for silent run
        bool silent = false;
        bool clean = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_load(object sender, EventArgs e)
        {
            string[] passArgs = Environment.GetCommandLineArgs();
            if (passArgs.Length > 1)
            {
                this.Hide();
                if(passArgs[1].ToString() == "/q")
                {
                    if(passArgs.Length > 2 && passArgs[2].ToString() == "/clean")
                    {
                        clean = true;
                    }
                    silent = true;
                    startFixing();
                    this.Close();
                }
            }
               
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startFixing();
        }

        //This does majority of the work!
        private void startFixing()
        {
            //clear all previous items
            completedList.Items.Clear();

            //Stop the Windows Update Service
            statusText.Text = "Stopping Windows Update Service";
            StopService("wuauserv");

            //Stop the BITS service
            statusUpdate("Stopping the Background Intelligent Transfer Service");
            StopService("bits");

            //Rename the Software Distribution Folder     
            //test if directory exists
            if (!System.IO.Directory.Exists("C:\\Windows\\SoftwareDistribution.old"))
            {
                statusUpdate("C:\\Windows\\SoftwareDistribution already exists!");
                try
                {
                    System.IO.Directory.Move("C:\\Windows\\SoftwareDistribution", "C:\\Windows\\SoftwareDistribution.old");
                }
                catch (Exception ex)
                {
                    if (silent == false)
                    {
                        MessageBox.Show(ex.ToString(), ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        statusUpdate(ex.Message.ToString());
                    }
                }
            }
            else
            {
                statusUpdate("SoftwareDistribution.old already exists!");
                statusUpdate("Deleting other SoftwareDistribution.old");
                try
                {
                    System.IO.Directory.Delete("C:\\Windows\\SoftwareDistribution.old", true);
                }
                catch (Exception ex)
                {
                    if (silent == false)
                    {
                        MessageBox.Show(ex.ToString(), ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        statusUpdate(ex.Message.ToString());
                    }
                }


            }

            //reregister DLL's
            statusUpdate("Registering wuapi.dll");
            string toRegister = "/s wuapi.dll";
            System.Diagnostics.Process.Start("regsvr32", toRegister);

            statusUpdate("Registering wuaueng.dll");
            toRegister = "/s wuaueng.dll ";
            System.Diagnostics.Process.Start("regsvr32", toRegister);

            statusUpdate("Registering wuaueng1.dll");
            toRegister = "/s wuaueng1.dll";
            System.Diagnostics.Process.Start("regsvr32", toRegister);

            statusUpdate("Registering atl.dll");
            toRegister = "/s atl.dll";
            System.Diagnostics.Process.Start("regsvr32", toRegister);

            statusUpdate("Registering wucltui.dll");
            toRegister = "/s wucltui.dll";
            System.Diagnostics.Process.Start("regsvr32", toRegister);

            statusUpdate("Registering wups.dll");
            toRegister = "/s wups.dll";
            System.Diagnostics.Process.Start("regsvr32", toRegister);

            statusUpdate("Registering wups2.dll");
            toRegister = "/s wups2.dll";
            System.Diagnostics.Process.Start("regsvr32", toRegister);

            statusUpdate("Registering wuweb.dll");
            toRegister = "/s wuweb.dll";
            System.Diagnostics.Process.Start("regsvr32", toRegister);

            //Start Windows Update Service
            statusUpdate("Starting Windows Update Service");
            startService("wuauserv");

            //Start BITS service
            statusUpdate("Starting the Background Intelligent Transfer Service");
            startService("bits");

            //Ask to delete old Software Distribution Folder
            if (System.IO.Directory.Exists("C:\\Windows\\SoftwareDistribution.old"))
            {
                if (silent == false)
                {
                    switch (MessageBox.Show("Would you like to delete the old Software Distribution Folder?", "Delete Software Distribution Folder?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            try
                            {
                                System.IO.Directory.Delete("C:\\Windows\\SoftwareDistribution.old", true);
                                statusUpdate("Deleting the old Software Distribution Folder");
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                statusUpdate(ex.Message.ToString());
                            }
                            break;

                        case DialogResult.No:
                            //No pressed
                            break;
                    }
                }
                else
                {
                    if (clean == true)
                    {
                        try
                        {
                            System.IO.Directory.Delete("C:\\Windows\\SoftwareDistribution.old", true);
                        }
                        catch
                        {
                            //Exception error
                        }
                    }
                }
            }

            //All Done!
            statusUpdate("All Done!");
        }

        //This will stop a service name passed to it
        public static void StopService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            if (service.Status == ServiceControllerStatus.Running)
            {
                try
                { 
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                catch
                { MessageBox.Show("There was an error stopping the service: " + serviceName); }
            }
            else
            {
                MessageBox.Show("The service: " + serviceName + " is already stopped!");
            }
        }

        //This will start a service name passed to it
        public static void startService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            if (service.Status == ServiceControllerStatus.Stopped)
            {
                try
                { 
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
 
                }
                catch
                { MessageBox.Show("There was an error starting service: " + serviceName); }
            }
            else
            {
                MessageBox.Show("The service: " + serviceName + " is already running!");
            }
        }

        //This will move the status to the listbox and add the new status
        private void statusUpdate(string updateMessage)
        {
            this.Invoke((MethodInvoker)delegate
            {
                completedList.Items.Add(statusText.Text);
                statusText.Text = updateMessage;
            });
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

    }
}
