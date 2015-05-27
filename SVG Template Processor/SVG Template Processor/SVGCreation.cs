using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;





namespace SVG_Template_Processor
{ 
    public partial class SVGCreation : System.Windows.Forms.Form
    {
        
        private System.Collections.Generic.List<string> pngFilePaths = new System.Collections.Generic.List<string>();
        private System.Collections.Generic.List<string> pngFileNames = new System.Collections.Generic.List<string>();
    
        //initalize 
        public SVGCreation()
        {
            InitializeComponent();
            
        }

         private void ofdButton_Click(object sender, EventArgs e)
                {

                    if (outDialogBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {   
                            string tempFolder = System.IO.Path.GetFullPath(outDialogBox.SelectedPath);
                            outputfilepath.Text = System.IO.Path.GetFullPath(outDialogBox.SelectedPath);
                    
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        //automated
        private void Form2_Load(object sender, EventArgs e)
        {

        }

       
        private void ftbConvert_Click(object sender, EventArgs e)
        {
            if (ftbcDialogBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string tempFolder = System.IO.Path.GetTempPath();
                    
                    foreach (string FileName in this.ftbcDialogBox.FileNames)
                    {
                        sourceFiles.Items.Add(System.IO.Path.GetFileName(FileName));
                        pngFilePaths.Add(System.IO.Path.GetFullPath(FileName));
                        pngFileNames.Add(System.IO.Path.GetFileName(FileName));
                        

                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        //automated
        private void ftbcDialogBox_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        //automated
        private void opdDialogBox_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        //automated
        private void ftbEmbedded_FileOk(object sender, System.ComponentModel.CancelEventArgs e) { }



        private void removSeleButton_Click(object sender, EventArgs e)
        {   //remove files which the user wishes to unselect... will delete the files from the queue to be converted to SVG
            for (int i = sourceFiles.SelectedIndices.Count - 1; i >= 0; i--)
            {
                pngFilePaths.RemoveAt(sourceFiles.SelectedIndices[i]);
                pngFileNames.RemoveAt(sourceFiles.SelectedIndices[i]);
                sourceFiles.Items.RemoveAt(sourceFiles.SelectedIndices[i]);

            }

        }

        private void svgConvertB_Click(object sender, EventArgs e)
        {

            bW.DoWork += new DoWorkEventHandler(bW_DoWork);
            bW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bW_RunWorkerCompleted);

            if(bW.IsBusy != true)
            {
                bW.RunWorkerAsync();
            }
            /*
             * validation.Validate();
             if (validation.GetInvalidControls().Count != 0)
                 return;
             this.DialogResult = System.Windows.Forms.DialogResult.OK;
             if (pngFileNames.Count > 0)
             {   SVGCreationLibrary create = new SVGCreationLibrary(pngFilePaths.ToArray(), outputfilepath.Text, pngFileNames.ToArray(), "embed");
                 create.buildSVG();
             }
             * */
        }

        private void urlButton_Click(object sender, EventArgs e)
        {
            validation.Validate();
            if (validation.GetInvalidControls().Count != 0)
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (pngFileNames.Count > 0)
            {
                SVGCreationLibrary create = new SVGCreationLibrary(pngFilePaths.ToArray(), outputfilepath.Text, pngFileNames.ToArray(), "linked");
                create.buildSVG();
            }
        }

        private void bW_DoWork(object sender, DoWorkEventArgs e)
        {
            validation.Validate();
            if (validation.GetInvalidControls().Count != 0)
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (pngFileNames.Count > 0)
            {
                SVGCreationLibrary create = new SVGCreationLibrary(pngFilePaths.ToArray(), outputfilepath.Text, pngFileNames.ToArray(), "embed");
                create.buildSVG();
            }
        }

        private void bW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.labelControl.Text = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                this.labelControl.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.labelControl.Text = "Done!";
            }
            bW.Dispose();
            
        }
       
       
        
        

        
    }
}

