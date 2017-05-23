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

namespace KevinMaM17_Lab1_Ex3
{
    public partial class SimpleWord : Form
    {
        public SimpleWord()
        {
            InitializeComponent();

            //populate dropdown list for font sizes
            for (int i = 1; i < 101; i++)
            {
                toolStripComboBoxFontSize.Items.Add(i);
            }

            toolStripComboBoxFont.Text = richTextBox1.Font.Name;
            toolStripComboBoxFontSize.Text = "" + richTextBox1.Font.Size;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog ofd = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            ofd.DefaultExt = "*.rtf";
            ofd.Filter = "RTF Files|*.rtf";

            ofd.ShowDialog();

            //file selected
            if (ofd.FileName.Length > 0)
                richTextBox1.Text = File.ReadAllText(ofd.FileName);

        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void toolStripButtonPaste_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void font_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            richTextBox1.SelectionFont = fd.Font;
            toolStripComboBoxFont.Text = richTextBox1.SelectionFont.Name;
            toolStripComboBoxFontSize.Text = "" + richTextBox1.SelectionFont.Size;
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                toolStripComboBoxFont.Text = richTextBox1.SelectionFont.Name;
                toolStripComboBoxFontSize.Text = "" + richTextBox1.SelectionFont.Size;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void toolStripButtonFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            richTextBox1.SelectionColor = cd.Color;
        }
    }
}
