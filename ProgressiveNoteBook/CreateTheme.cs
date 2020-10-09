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
    public partial class CreateTheme : Form
    {

        string thisNotebookName;
        public CreateTheme(string notebookName)
        {
            InitializeComponent();
            thisNotebookName = notebookName;
            timer1.Interval = 2000;
            this.Focus();
            this.BringToFront();
        }

        string notebooksPath = Path.Combine(Directory.GetCurrentDirectory(), "Notebooks");
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("A theme can't be unnamed");
            }
            else if (!File.Exists(Path.Combine(notebooksPath, thisNotebookName + "_" + textBox1.Text.Trim() + ".txt")))
            {
                using (StreamWriter streamWriter = new StreamWriter(Path.Combine(notebooksPath, thisNotebookName + "_" + textBox1.Text.Trim() + ".txt")))
                {
                    streamWriter.Write("");
                }


                label2.Visible = true;
                label2.ForeColor = Color.DarkGreen;
                label2.Text = "The theme have aded successful";
                textBox1.Clear();
            }
            else
            {
                label2.Visible = true;
                label2.ForeColor = Color.DarkRed;
                label2.Text = "The theme have alredy exist";
                textBox1.Clear();
            }

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            NotebookTheme notebookTheme = new NotebookTheme(thisNotebookName);

            notebookTheme.Show();

           
            
        }
    }
}
