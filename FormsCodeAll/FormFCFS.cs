using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace FormsCodeAll
{
    public partial class FormFCFS : Form
    {
        ArrayList array = new ArrayList();
        public FormFCFS()
        {
            InitializeComponent();
        }

        private void FormFCFS_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            array.Add(Convert.ToInt32(textBox1.Text));
            array.Add(Convert.ToInt32(textBox2.Text));
            array.Add(Convert.ToInt32(textBox3.Text));
            array.Add(Convert.ToInt32(textBox4.Text));
            foreach(var itme in array)
            {
                checkedListBox1.Items.Add(itme);
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(checkedListBox1.Items[0] + "000");
            if (checkedListBox1.Items[0].ToString() == textBox1.Text)
            {
                textBox5.Text = label3.Text;
            }
            else if (checkedListBox1.Items[0].ToString() == textBox2.Text)
            {
                timer1.Interval = Convert.ToInt32(textBox2.Text + "000");
                textBox5.Text = label4.Text;
            }
            else if (checkedListBox1.Items[0].ToString() == textBox3.Text)
            {
                timer1.Interval = Convert.ToInt32(textBox3.Text + "000");
                textBox5.Text = label5.Text;
            }
            else if (checkedListBox1.Items[0].ToString() == textBox4.Text)
            {
                timer1.Interval = Convert.ToInt32(textBox4.Text + "000");
                textBox5.Text = label6.Text;
            }
            checkedListBox1.Items.RemoveAt(0);
            if (checkedListBox1.Items.Count <= 0)
            {
                MessageBox.Show("Process is idel and wait the process");
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            array.Add(Convert.ToInt32(textBox1.Text));
            array.Add(Convert.ToInt32(textBox2.Text));
            array.Add(Convert.ToInt32(textBox3.Text));
            array.Add(Convert.ToInt32(textBox4.Text));
            array.Sort();
            foreach (var itme in array)
            {
                checkedListBox1.Items.Add(itme);
            }
            timer1.Start();
        }

        private void FormFCFS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
        }
    }
}
