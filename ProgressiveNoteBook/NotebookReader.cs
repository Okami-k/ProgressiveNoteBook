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
    public partial class NotebookReader : Form
    {
        private string pathCon = "";
        public NotebookReader(string path)
        {
            InitializeComponent();
            using (StreamReader streamReader = new StreamReader(path))
            {
                textBox1.Text = "ffewf";
                
            }

            button1.Focus();
            pathCon = path;
        }
        public NotebookReader()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter(pathCon))
            {
                streamWriter.WriteLine(textBox1.Text);
            }
        }

    }
}
