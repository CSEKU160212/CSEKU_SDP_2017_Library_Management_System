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

namespace WindowsFormsApplication1
{


    // SQL Connection
    public partial class view_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sumit\Documents\Database.mdf;Integrated Security=True;Connect Timeout=30");

        public view_books()
        {
            InitializeComponent();
        }











        // view_books_Load Event
        private void view_books_Load(object sender, EventArgs e)
        {
            Display_Books();

        }











        // books_name Search (button1) Button Code
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where books_name like ('%"+textBox1.Text+"%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;

                con.Close();
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










        // NOT NEEDED_01
        private void label2_Click(object sender, EventArgs e)
        {

        }














        // books_author_name Search (button2) Button Code
        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where books_author_name like ('%" + textBox2.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                dataGridView1.DataSource = dt;


                con.Close();

                if(i==0)
                {
                    MessageBox.Show("Sorry, No Books Found !!!\nSearch Again.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }










        // NOT NEEDED_02
        private void label3_Click(object sender, EventArgs e)
        {

        }













        // books_publication_name search (button3) Code
        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where books_publication_name like ('%" + textBox3.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                dataGridView1.DataSource = dt;


                con.Close();

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





        















        // dataGridView1_CellClick (Showing books_info) Code
        // View Books Code
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where id="+i+"";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    booksname.Text = dr["books_name"].ToString();
                    authorname.Text = dr["books_author_name"].ToString();
                    publicationname.Text = dr["books_publication_name"].ToString();
                    purchasedate.Text = dr["books_purchase_date"].ToString();
                    booksprice.Text = dr["books_price"].ToString();
                    booksqty.Text = dr["books_quantity"].ToString();
                    box_quantity.Text = dr["available_quantity"].ToString();
                    box_id.Text = dr["book_id"].ToString();
                }


                con.Close();

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }















        // UPDATE (button7_Click) Code
        private void button7_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            
            
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books_info set books_name='"+booksname.Text+"',books_author_name='"+authorname.Text+"',books_publication_name='"+publicationname.Text+"',books_purchase_date='"+purchasedate.Text+"',books_price='"+booksprice.Text+"',books_quantity='"+booksqty.Text+"',available_quantity='"+box_quantity.Text+"', book_id='"+box_id.Text+"' where id="+i+"";
                cmd.ExecuteNonQuery();
                con.Close();
                Display_Books();
                MessageBox.Show("Data Updated Successfully\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





            
        }














        // view_books_Load Event_02
        public void Display_Books()
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






        // NOT NEEDED_03
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // NOT NEEDED_04
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // NOT NEEDED_05
        private void label5_Click(object sender, EventArgs e)
        {

        }

        // NOT NEEDED_06
        private void label9_Click(object sender, EventArgs e)
        {

        }

        // NOT NEEDED_07
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        // NOT NEEDED_08
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
