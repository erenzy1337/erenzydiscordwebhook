using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erenzy_Discord_Webhook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void sendWebHook(string URL, string msg, string username, string avatar)
        {
            Http.Post(URL, new NameValueCollection()
            {
                { "username", username },
                { "content", msg },
                {"avatar_url", avatar }
            });
        }

        public static void sendWebHook1(string URL, string msg, string username)
        {
            Http.Post(URL, new NameValueCollection()
            {
                { "username", username },
                { "content", msg }
            });
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a webhook url!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a webhook name!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox3.Enabled == true && textBox3.Text == "")
            {
                MessageBox.Show("Please enter a avatar url!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (richTextBox1.Text == "")
            {
                MessageBox.Show("Please enter a message!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (checkBox2.Checked == true || textBox3.Text != "")
                {
                    sendWebHook(textBox1.Text, string.Concat(new string[] { richTextBox1.Text, }), textBox2.Text, textBox3.Text);
                }
                else
                {
                    sendWebHook1(textBox1.Text, string.Concat(new string[] { richTextBox1.Text, }), textBox2.Text);
                }

                if (checkBox1.Checked == false)
                {
                    MessageBox.Show("Message successfully sent!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var request = WebRequest.Create(textBox3.Text);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(stream);
            }
            textBox3.Enabled = false;
            button2.Visible = false;
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
        }
    }
}
