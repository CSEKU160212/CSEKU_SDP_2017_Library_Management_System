using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class mdi_user : Form
    {
        private int childFormNumber = 0;

        public mdi_user()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void mdi_user_Load(object sender, EventArgs e)
        {

        }

        private void showSearchBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_books ab = new add_books();
            ab.Show();

        }

        private void viewBooksToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            view_books vb = new view_books();
            vb.Show();

        }

        private void addInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_student_info asb = new add_student_info();
            asb.Show();
        }

        private void viewInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_students_info vsb = new view_students_info();
            vsb.Show();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issue_books ib = new issue_books();
            ib.Show();
        }

        private void viewStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BOOKS_STOCK bs = new BOOKS_STOCK();
            bs.Show();
        }

        private void crystalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Generator rg = new Report_Generator();
            rg.Show();
        }
    }
}
