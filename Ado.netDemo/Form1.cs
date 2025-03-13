
using System.Data.SqlClient;
namespace Ado.netDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"data source=LAPTOP-4G8BHPK9\SQLEXPRESS;initial catalog=Wipro4;Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("insert into student values(@studid1,@studname1)", cnn);
            cmd.Parameters.AddWithValue("@studid1", Convert.ToInt16(textBox1.Text));
            cmd.Parameters.AddWithValue("@studname1", textBox2.Text);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("studnent inserted ");
            }
            else
            {
                MessageBox.Show("studnet not inserted");
            }
            cnn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("update student set studentname=@studentname1 where studentid=@studentid1", cnn);
            cmd.Parameters.AddWithValue("@studentname1", textBox2.Text);
            cmd.Parameters.AddWithValue("@studentid1", Convert.ToInt16(textBox1.Text));
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("student updated ");

            }
            else
            {
                MessageBox.Show("student not updated");
            }
            cnn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("delete from student where studentid=@studentid1", cnn);
            cmd.Parameters.AddWithValue("@studentid1", Convert.ToInt32(textBox1.Text));
            int rowsAffeceted = cmd.ExecuteNonQuery();
            if (rowsAffeceted > 0)
            {
                MessageBox.Show("student deleted  ");

            }
            else
            {
                MessageBox.Show("student not deleted");
            }
            cnn.Close();
        }
        SqlDataReader dr;
        private void button4_Click(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from student", cnn);
            dr = cmd.ExecuteReader();//now this reader is pointing to table so first row u want to read 
            dr.Read();// cursor will now point to first row 
            textBox1.Text = dr[0].ToString();
            textBox2.Text = dr[1].ToString();
            //note here dont close the connection because in next button next row i will read 
            // u can see first row only 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dr.Read();
            textBox1.Text = dr[0].ToString();
            textBox2.Text = dr[1].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from student", cnn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MessageBox.Show("Studentid:" + dr[0].ToString() + "\n studentname:" + dr[1].ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select studentid from student", cnn);
            dr = cmd.ExecuteReader();
            comboBox1.Refresh();
            while (dr.Read())
            {
                this.comboBox1.Items.Add(dr[0].ToString());
            }
            cnn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from student where studentid="
                + Convert.ToInt16(comboBox1.Text), cnn);
            dr = cmd.ExecuteReader();
            dr.Read();
            textBox1.Text = dr[0].ToString();
            textBox2.Text = dr[1].ToString();
            cnn.Close();
        }
        public string getstudentid
        {
            get
            {
                return textBox1.Text;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f2=new Form2();
            f2.setstudentid = getstudentid;
            f2.Show();
        }
    }
}
