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
    public partial class view_students_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sumit\Documents\Database.mdf;Integrated Security=True;Connect Timeout=30");

        public view_students_info()
        {
            InitializeComponent();
        }

        private void view_students_info_Load(object sender, EventArgs e)
        {
            Display_Info();
        }




        //Search Button Code
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where student_name like ('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;

                con.Close();
                if (i == 0)
                {
                    MessageBox.Show("Sorry, No Student Found Regarding This Name !!!\nSearch Again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //DataGridView Code
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where id=" + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    studentsname.Text = dr["student_name"].ToString();
                    studentid.Text = dr["student_id"].ToString();
                    department.Text = dr["student_department"].ToString();
                    semester.Text = dr["student_semester"].ToString();
                    contact.Text = dr["student_contact"].ToString();
                    email.Text = dr["student_email"].ToString();
                }


                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        






        





        //Update Button Code
        private void button7_Click(object sender, EventArgs e)
        {

            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update student_info set student_name='" + studentsname.Text + "', student_id='" + studentid.Text + "',student_department='" + department.Text + "',student_semester='" + semester.Text + "',student_contact='" + contact.Text + "',student_email='" + email.Text + "' where id=" + i + "";
                cmd.ExecuteNonQuery();

                con.Close();
                Display_Info();
                MessageBox.Show("Data Updated Successfully\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        //Upload Event
        public void Display_Info()
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info";
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



        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where student_id like ('%" + textBox2.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;

                con.Close();
                if (i == 0)
                {
                    MessageBox.Show("Sorry, No Student Found Regarding This ID !!!\nSearch Again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
