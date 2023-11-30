using System;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                float money = float.Parse(textBox1.Text);
                float percentage = float.Parse(textBox2.Text);
                int years = int.Parse(textBox3.Text);

                for (int i = 0; i < years; i++)
                {
                    money += money * (percentage / 100);
                }

                textBox4.Text = money.ToString();
                textBox5.Text = "Operation successful";
            }
            catch (Exception ex)
            {
                textBox5.Text = ex.Message;
                textBox4.Text = "";
            }
        }
    }
}
