using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressiveNoteBook
{
    public partial class ExistNotebook : Form
    {


        string notebooksPath = Path.Combine(Directory.GetCurrentDirectory(), "Notebooks");


        public ExistNotebook()
        {
            
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        private void NewNotebook_Load(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            try
            {
                RefreshNotebooksList();
            }
            catch (DirectoryNotFoundException)
            {
                var folderBrowserDialog = new FolderBrowserDialog();
                switch (folderBrowserDialog.ShowDialog())
                {
                    case DialogResult.OK:

                        notebooksPath = folderBrowserDialog.SelectedPath;
                        RefreshNotebooksList();
                        break;
                    case DialogResult.Cancel:
                        label2.Visible = true;
                        label2.ForeColor = Color.DarkRed;
                        label2.Text = "Haven't chose the path";
                        break;
                    default:
                        break;
                }



            }
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var subSelectedItem = listBox1.SelectedItem.ToString().Substring(1, listBox1.SelectedItem.ToString().Length - 1);

            NotebookTheme notebookTheme = new NotebookTheme(subSelectedItem);

            notebookTheme.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult isDelete = MessageBox.Show("Do you really want to delete this notebook ?","InfoWindow",MessageBoxButtons.YesNo);

            switch (isDelete)
            {
                case DialogResult.None:
                    //Nothing to do
                    break;
                case DialogResult.Ignore:
                    //Nothing to do
                    break;
                case DialogResult.Yes:
                    DeleteNotebook();
                    break;
                case DialogResult.No:
                    // Nothing to do
                    break;
                default:
                    //Nothing to do
                    break;
            }

            
            
           

            
            
        }

        void DeleteNotebook()
        {
            File.Delete(Path.Combine(notebooksPath, listBox1.SelectedItem.ToString() + ".txt"));

            RefreshNotebooksList();

        }
        void RefreshNotebooksList()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(notebooksPath);

            var g = directoryInfo.GetFiles();

            listBox1.Items.Clear();

            var notebooksList = directoryInfo.GetFiles("^*");

            for (int i = 0; i < notebooksList.Length; i++)
            {
                listBox1.Items.Add(notebooksList[i].ToString().Remove(notebooksList[i].ToString().Length - 4,4));
            }
        }

        
    }
}
