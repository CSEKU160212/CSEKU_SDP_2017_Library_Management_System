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
using System.Net.Mail;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class BOOKS_STOCK : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sumit\Documents\Database.mdf;Integrated Security=True;Connect Timeout=30");
        public BOOKS_STOCK()
        {
            InitializeComponent();
        }


        //NOT NEEDED
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BOOKS_STOCK_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            fill_books_info();
        }


        public void fill_books_info()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select books_name,books_author_name,books_publication_name,books_purchase_date,books_price, books_quantity,available_quantity from books_info where books_quantity!=available_quantity";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string i;
            i = dataGridView1.SelectedCells[0].Value.ToString();
            //MessageBox.Show(i.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books where books_name='"+ i.ToString() +"' and books_return_date='' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            try
            {

                //con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where books_name like ('%" + textBox1.Text + "%') and books_quantity!=available_quantity";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;

                //con.Close();
                if (i == 0)
                {
                    MessageBox.Show("Sorry, No Books Found !!!\nSearch Again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string i;
                i = dataGridView2.SelectedCells[8].Value.ToString(); //ID IS NOT REGARDED AS AN INDEX
                textBox2.Text = i.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            //Username & Password
            smtp.Credentials = new NetworkCredential("skdam57@gmail.com", "01766786091");
            MailMessage mail = new MailMessage("skdam57@gmail.com", textBox2.Text, "Notice For Returning The Book", textBox3.Text);
            mail.Priority = MailPriority.High;
            smtp.Send(mail);
            MessageBox.Show("Mail Sent.\n");
        }
    }
}
