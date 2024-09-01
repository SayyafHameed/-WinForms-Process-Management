using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FormsCodeAll
{
    public partial class FormProcess : Form
    {

        [DllImport("user32")]
        public static extern void LockWorkStation();
        public FormProcess()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r /t 0");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("winword");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("excel");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("notepad");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName(comboBox1.Text))
            {
                process.Kill();
            }
        }

        private void FormProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            
        }

        private void FormProcess_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
