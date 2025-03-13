using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Ado.netDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string setstudentid
        {
            set
            {
                textBox4.Text = value;
            }
        }
        SqlConnection cnn = new SqlConnection(@"data source=LAPTOP-4G8BHPK9\SQLEXPRESS;initial catalog=Wipro4;Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();
            int cid = Convert.ToInt32(textBox1.Text);
            string cname = textBox2.Text;
            int duration = Convert.ToInt32(textBox3.Text);
            int studid = Convert.ToInt32(textBox4.Text);
            SqlCommand cmd = new SqlCommand("insertcourse", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@cname", cname);
            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.Parameters.AddWithValue("@sid1", studid);
            int rowsAffcted = cmd.ExecuteNonQuery();
            if (rowsAffcted > 0)
            {
                MessageBox.Show("course added ");
            }
            else
            {
                MessageBox.Show("course not added ");
            }
            cnn.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnn.Open();
            int cid = Convert.ToInt32(textBox1.Text);
            string cname = textBox2.Text;
            int duration = Convert.ToInt32(textBox3.Text);
            int studid = Convert.ToInt32(textBox4.Text);
            SqlCommand cmd = new SqlCommand("updatecourse", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@cname", cname);
            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.Parameters.AddWithValue("@sid1", studid);
            int rowsAffcted = cmd.ExecuteNonQuery();
            if (rowsAffcted > 0)
            {
                MessageBox.Show("course updated ");
            }
            else
            {
                MessageBox.Show("course not updated ");
            }
            cnn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cnn.Open();

            int studid = Convert.ToInt32(textBox4.Text);
            SqlCommand cmd = new SqlCommand("deletecourse", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid1", studid);
            int rowsAffcted = cmd.ExecuteNonQuery();
            if (rowsAffcted > 0)
            {
                MessageBox.Show("course deleted and cascadingly student also got deleted ");
            }
            else
            {
                MessageBox.Show("Nothing has been deleted  ");
            }
            cnn.Close();
        }
    }
}
