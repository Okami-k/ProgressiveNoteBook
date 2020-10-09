using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressiveNoteBook
{
    public partial class NotebookTheme : Form
    {

        string thisSelectedNotebook;

        string notebooksPath = Path.Combine(Directory.GetCurrentDirectory(), "Notebooks");

        public NotebookTheme(string selectedNotebook)
        {
            InitializeComponent();
            thisSelectedNotebook = selectedNotebook;
            refreshThemeList();

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            CreateTheme createTheme = new CreateTheme(thisSelectedNotebook);
            createTheme.Show();
            createTheme.Focus();

        }
        
        

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult isDelete = MessageBox.Show("Do you really want to delete this theme ?", "InfoWindow", MessageBoxButtons.YesNo);

            switch (isDelete)
            {
                case DialogResult.None:
                    //Nothing to do
                    break;
                case DialogResult.Ignore:
                    //Nothing to do
                    break;
                case DialogResult.Yes:
                    DeleteTheme();
                    break;
                case DialogResult.No:
                    // Nothing to do
                    break;
                default:
                    //Nothing to do
                    break;
            }
        }

        void DeleteTheme()
        {
            File.Delete(Path.Combine(notebooksPath,listBox1.SelectedItem.ToString()));

            refreshThemeList();
        }

        private void refreshThemeList()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(notebooksPath);



            var fileThemeList = directoryInfo.GetFiles(thisSelectedNotebook + "_" + "*");

            listBox1.Items.Clear();

            for (int i = 0; i < fileThemeList.Length; i++)
            {
                listBox1.Items.Add(fileThemeList[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var notebookReader = new NotebookReader(Path.Combine(notebooksPath,listBox1.SelectedItem.ToString()));

            notebookReader.ShowDialog();
        }
    }
}
