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
namespace FormsCodeAll
{
    public partial class FormService : Form
    {
        public FormService()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = false;
            GetwindowService();
        }

        private void GetwindowService()
        {
            //throw new NotImplementedException();
            ServiceController[] services;
            services = ServiceController.GetServices();
            comboBox1.Items.Clear();
            for (int i = 0; i < services.Length; i++)
            {
                comboBox1.Items.Add(services[i].ServiceName);
            }

        }

        private void FormService_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var singlepro = new ServiceController((string)e.Argument);
            if ((singlepro.Status.Equals(ServiceControllerStatus.Stopped))||
                (singlepro.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                singlepro.Start();
            }
            else
            {
                singlepro.Stop();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.start.Enabled = false;
            this.progressBar1.Visible = false;
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "Could not service");
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.start.Enabled = false;
            this.stop.Enabled = true;
            this.progressBar1.Visible = true;
            this.backgroundWorker1.RunWorkerAsync(comboBox1.Text);
        }

        private void stop_Click(object sender, EventArgs e)
        {
            this.start.Enabled = false;
            this.stop.Enabled = true;
            this.progressBar1.Visible = true;
            this.backgroundWorker1.RunWorkerAsync(comboBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var singlepro = new ServiceController(comboBox1.Text);
            if ((singlepro.Status.Equals(ServiceControllerStatus.Stopped)) ||
                (singlepro.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                this.start.Enabled = true;
                this.stop.Enabled = false;
            }
            else
            {
                this.start.Enabled = false;
                this.stop.Enabled = true;
            }
        }

        private void FormService_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
 
        }
    }
}
