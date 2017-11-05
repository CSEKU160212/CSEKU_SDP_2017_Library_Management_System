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
    public partial class issue_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sumit\Documents\Database.mdf;Integrated Security=True;Connect Timeout=30");

        public issue_books()
        {
            InitializeComponent();
        }













        // Search button(button2) code, it works for both viewing students' info & issued books
        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where student_id like ('%" + txt_roll.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                con.Close();
                if (i == 0)
                {
                    MessageBox.Show("No Student Found Regarding This ID");
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txt_name.Text = dr["student_name"].ToString();
                        txt_id.Text = dr["student_id"].ToString();
                        txt_department.Text = dr["student_department"].ToString();
                        txt_semester.Text = dr["student_semester"].ToString();
                        txt_contact.Text = dr["student_contact"].ToString();
                        txt_email.Text = dr["student_email"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            // For viewing issued books
            int j = 0;
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from issue_books where student_id like ('%" + txt_roll.Text + "%') and books_return_date=''";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                j = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;

                con.Close();
                if (j == 0)
                {
                    MessageBox.Show("Sorry, No books Found issued by this student !!!\nSearch Again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }









        // issue_books_Load Event
        private void issue_books_Load(object sender, EventArgs e)
        {

            Display_Books_After_Return();


            /* If we write the above method here then it will show all the books issued by all the students, but since we "only" want to see the books issued by the student
            regarding the roll given by us, we are not writing the above method here */





            /*
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from issue_books";
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
            */
        }












        // KeyUp Event
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;
            try
            {

                
                con.Open();
                if (e.KeyCode != Keys.Enter)
                {
                    listBox1.Items.Clear();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from books_info where books_name like ('%" + textBox2.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    count = Convert.ToInt32(dt.Rows.Count.ToString());
                    con.Close();
                    if (count > 0)
                    {
                        listBox1.Visible = true;
                        foreach (DataRow dr in dt.Rows)
                        {
                            listBox1.Items.Add(dr["books_name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }











        // KeyDown Event
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;


            }
        }









        // KeyDown with Enter
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;


                int i = 0;
                try
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from books_info where books_name like ('%" + textBox2.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());
                    con.Close();
                    if (i == 0)
                    {
                        MessageBox.Show("No Book Found Regarding This Name.");
                    }
                    else
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            book_name.Text = dr["books_name"].ToString();
                            author_name.Text = dr["books_author_name"].ToString();
                            publication_name.Text = dr["books_publication_name"].ToString();
                            books_purchase_date.Text = dr["books_purchase_date"].ToString();
                            book_price.Text = dr["books_price"].ToString();
                            book_quantity.Text = dr["books_quantity"].ToString();
                            available_qty.Text = dr["available_quantity"].ToString();
                            books_id.Text = dr["book_id"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }












        // MouseClick Event
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

             textBox2.Text = listBox1.SelectedItem.ToString();
             listBox1.Visible = false;


            int i = 0;
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where books_name like ('%" + textBox2.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                con.Close();
                if (i == 0)
                {
                    MessageBox.Show("No Book Found Regarding This Name.");
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        book_name.Text = dr["books_name"].ToString();
                        author_name.Text = dr["books_author_name"].ToString();
                        publication_name.Text = dr["books_publication_name"].ToString();
                        books_purchase_date.Text = dr["books_purchase_date"].ToString();
                        book_price.Text = dr["books_price"].ToString();
                        book_quantity.Text = dr["books_quantity"].ToString();
                        available_qty.Text = dr["available_quantity"].ToString();
                        books_id.Text = dr["book_id"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }













        // issue_books TABLE DATA INSERTION CODE
        // ISSUE BOOKS button(button1) Code
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int books_qty=0;
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from books_info where books_name like ('%" + book_name.Text + "%')";
                cmd2.ExecuteNonQuery();
                con.Close();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    books_qty = Convert.ToInt32(dr2["available_quantity"].ToString());
                }

                if (books_qty>0)
                {

                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into issue_books values('" + txt_roll.Text + "','" + book_name.Text + "','" + author_name.Text + "','" + publication_name.Text + "', '" + books_id.Text + "','" + textBox7.Text + "','','"+txt_email.Text+"')";
                        cmd.ExecuteNonQuery();

                        con.Close();
                        Display_Books_After_Return();

                        MessageBox.Show("Book/Books Issued Successfully\n");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }




                    //Update Portion
                    try
                    {
                        con.Open();
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "update books_info set available_quantity=available_quantity-1 where books_name='" + book_name.Text + "'";
                        cmd1.ExecuteNonQuery();

                        con.Close();
                        //Display_Books();

                        //MessageBox.Show("Book/Books Issued Successfully\n");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                else
                {
                    MessageBox.Show("Books Not Available.\nSorry.");
                }
                
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }













        // An extra method to show the issued books by any student right on the spot.
        public void Display_Books()
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from issue_books where student_id like ('%" + txt_roll.Text + "%')";
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


        //Only those books are displayed that are not returned
        public void Display_Books_After_Return()
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from issue_books where student_id like ('%" + txt_roll.Text + "%') and books_return_date=''";
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












        // NOT NEEDED_01
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        // NOT NEEDED_02
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        // NOT NEEDED_03
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {



                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from issue_books where id=" + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    return_id.Text = dr["student_id"].ToString();
                    return_book_name.Text = dr["books_name"].ToString();
                    return_book_id.Text = dr["book_id"].ToString();
                    return_issue_date.Text = dr["books_issue_date"].ToString();

                }


                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                con.Open();            
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update issue_books set books_return_date='" + return_return_date.Text + "' where ID=" + i + "";
                cmd.ExecuteNonQuery();
                con.Close();


                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update books_info set available_quantity=available_quantity+1 where books_name='" + return_book_name.Text + "'";
                cmd1.ExecuteNonQuery();
                con.Close();
                

                Display_Books_After_Return();

                MessageBox.Show("Books Returned Successfully\nThanku.");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
