using System;
using System.Collections.Generic;
using System.Linq;




namespace SVG_Template_Processor
{
    public partial class SVGCreation : System.Windows.Forms.Form
    {
        private List<string> pngFiles = new List<string>();
    
        //iitalize 
        public SVGCreation()
        {
            InitializeComponent();
            CreateDropDownControl();
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
        private void Form2_Load(object sender)
        {

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
                        pngFiles.Add(ftbcDialogBox.FileName);
                        

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

        private void imagePlaced_Click(object sender, System.EventArgs e)
            {   //if the text says embedded image open file dialog for the user to select the image that will be inserted into the templete
                if(imagePlaced.Text.Equals("Embedded Image"))
                {
                    if (ftbEmbedded.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            try
                            {   //change the text in the text box to the file path of the file to be embedded
                                overlayImage.Text = System.IO.Path.GetFullPath(ftbEmbedded.FileName);
                                overlayImage.ToolTip = "File Path to the file that will be embedded into the SVG"; // change the tool tip if it has been changed so user knows whats going on

                        
                            }
                            catch (Exception ex)
                            {
                                System.Windows.Forms.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message); // error message
                            }
                        }
                }
                else
                {
                    overlayImage.ToolTip = "URL based link that will be embedded into the SVG"; // change the tool top if it has been changed so the user knows whats going on
                }
            }
        //create the dropdown box for embedded image/ linked url
        private void CreateDropDownControl()
        {
         
        imagePlaced.DropDownControl = CreateDXPopupMenu();
        
        }
        private DevExpress.Utils.Menu.DXPopupMenu CreateDXPopupMenu()
        {  //creation of the drop down menu for drop down box
            DevExpress.Utils.Menu.DXPopupMenu menu = new DevExpress.Utils.Menu.DXPopupMenu();
                menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Embedded Image", OnItemClick));
                menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Linked Image", OnItemClick));
            
            return menu;
        }
        private void OnItemClick(object sender, EventArgs e)
        {   //finding out what was selected on the action event of clicking something in the drop down menu
            DevExpress.Utils.Menu.DXMenuItem item = sender as DevExpress.Utils.Menu.DXMenuItem;
            imagePlaced.Text = item.Caption; // change the text of the button for the user
            if(!item.Equals("Embedded Image"))
            {   //if it is linked image change the tool tip for the user
                overlayImage.ToolTip = "URL based link that will be embedded into the SVG";
            }
        }

        private void removSeleButton_Click(object sender, EventArgs e)
        {   //remove files which the user wishes to unselect... will delete the files from the queue to be converted to SVG
            for (int i = sourceFiles.SelectedIndices.Count-1; i >= 0; i--)
            {
                 pngFiles.RemoveAt(sourceFiles.SelectedIndices[i]);
                 sourceFiles.Items.RemoveAt(sourceFiles.SelectedIndices[i]);
                 
                }
        }

        private void svgConvertB_Click(object sender, EventArgs e)
        {
            SVGCreationLibrary create = new SVGCreationLibrary(pngFiles.ToArray());
            create.buildSVG();
         
        }

    }
}

