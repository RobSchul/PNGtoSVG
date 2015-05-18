using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace SVG_Template_Processor
{
    public partial class SVGCreation : Form
    {

        public SVGCreation()
        {
            InitializeComponent();
        }

        private void outputDest_Click(object sender, EventArgs e)
        {

            if (outDialogBox.ShowDialog() == DialogResult.OK)
            {
                try
                {   
                    string tempFolder = System.IO.Path.GetFullPath(outDialogBox.SelectedPath);
                    outputDestinationBox.Text = tempFolder;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void Form2_Load(object sender)
        {

        }

        private void ftbConvert_Click(object sender, EventArgs e)
        {
            if (ftbcDialogBox.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string tempFolder = System.IO.Path.GetTempPath();
                    foreach (string FileName in this.ftbcDialogBox.FileNames)
                    {
                        listBoxSourceFiles.Items.Add(System.IO.Path.GetFileName(FileName));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }


        private void ftbcDialogBox_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void opdDialogBox_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}

