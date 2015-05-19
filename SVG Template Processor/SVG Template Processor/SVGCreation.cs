using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;
using System.Drawing;


namespace SVG_Template_Processor
{
    public partial class SVGCreation : Form
    {

        public SVGCreation()
        {
            InitializeComponent();
            CreateDropDownControl();
        }

        private void ofdButton_Click(object sender, EventArgs e)
        {

            if (outDialogBox.ShowDialog() == DialogResult.OK)
            {
                try
                {   
                    string tempFolder = System.IO.Path.GetFullPath(outDialogBox.SelectedPath);
                    outputfilepath.Text = System.IO.Path.GetFullPath(outDialogBox.SelectedPath);
                    
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
        private void Form2_Load(object sender, EventArgs e)
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
                        sourceFiles.Items.Add(System.IO.Path.GetFileName(FileName));
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

        
        private void opdDialogBox_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ftbEmbedded_FileOk(object sender, CancelEventArgs e) { }

        private void imagePlaced_Click(object sender, System.EventArgs e)
            {
                if(imagePlaced.Text.Equals("Embedded Image"))
                {  System.Windows.Forms.OpenFileDialog ftbEmbedded = new System.Windows.Forms.OpenFileDialog();
                    ftbcDialogBox.Filter = "Images (*.PNG)|*.PNG|All files (*.*)|*.*";
                    ftbEmbedded.InitialDirectory = "i:\\CommissisionReconciliation\\Review\\";
                    ftbEmbedded.Multiselect = true;
                    ftbEmbedded.RestoreDirectory = true;
                    ftbEmbedded.Title = "Please Select PNG File(s) for Conversion";
                    ftbEmbedded.FileOk += new System.ComponentModel.CancelEventHandler(this.ftbcDialogBox_FileOk);
                if (ftbEmbedded.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        overlayImage.Text = System.IO.Path.GetFullPath(ftbEmbedded.FileName);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
                }
                else
                {

                }
            }
    
        private void CreateDropDownControl()
        {
         
        imagePlaced.DropDownControl = CreateDXPopupMenu();
        }
        private DXPopupMenu CreateDXPopupMenu()
        {
            DXPopupMenu menu = new DXPopupMenu();
            menu.Items.Add(new DXMenuItem("Embedded Image", OnItemClick));
            menu.Items.Add(new DXMenuItem("Linked Image", OnItemClick));
            return menu;
        }

        private void OnItemClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            imagePlaced.Text = item.Caption;
        }

    }
}

