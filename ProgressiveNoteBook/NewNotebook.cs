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
    public partial class NewNotebook : Form
    {


        string notebooksPath = Path.Combine(Directory.GetCurrentDirectory(), "Notebooks");


        

        public NewNotebook()
        {
            InitializeComponent();   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            try
            {
                CreateNewNotebook();
            }
            catch (DirectoryNotFoundException)
            {
                var folderBrowserDialog = new FolderBrowserDialog();
                switch (folderBrowserDialog.ShowDialog())
                {
                    case DialogResult.OK:

                        notebooksPath = folderBrowserDialog.SelectedPath;
                        CreateNewNotebook();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1.Focus();

                button1_Click(sender, e);
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void CreateNewNotebook()
        { 

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("A notebook can't be unnamed");
            }
            else if (!File.Exists(Path.Combine(notebooksPath,"^" + textBox1.Text.Trim() + ".txt")))
            {
                using (StreamWriter streamWriter = new StreamWriter(Path.Combine(notebooksPath,"^" + textBox1.Text.Trim() + ".txt")))
                {
                    streamWriter.Write("");
                }

                
                label2.Visible = true;
                label2.ForeColor = Color.DarkGreen;
                label2.Text = "The notebook have aded successful";
                textBox1.Clear();
            }
            else
            {
                label2.Visible = true;
                label2.ForeColor = Color.DarkRed;
                label2.Text = "The notebook have alredy exist";
                textBox1.Clear();
            }

            timer1.Start();
        }

        private void NewNotebook_Load(object sender, EventArgs e)
        {

        }
    }
}
