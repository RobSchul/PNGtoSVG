    


namespace SVG_Template_Processor
{
    partial class SVGCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.ftbcDialogBox = new System.Windows.Forms.OpenFileDialog();
            this.outDialogBox = new System.Windows.Forms.FolderBrowserDialog();
            this.ftbConvertButton = new DevExpress.XtraEditors.SimpleButton();
            this.ofdButton = new DevExpress.XtraEditors.SimpleButton();
            this.svgConvertB = new DevExpress.XtraEditors.SimpleButton();
            this.sourceFiles = new DevExpress.XtraEditors.ListBoxControl();
            this.outputfilepath = new DevExpress.XtraEditors.TextEdit();
            this.imagePlaced = new DevExpress.XtraEditors.DropDownButton();
            this.overlayImage = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputfilepath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ftbcDialogBox
            // 
            this.ftbcDialogBox.Filter = "Images (*.PNG)|*.PNG|All files (*.*)|*.*";
            this.ftbcDialogBox.InitialDirectory = "i:\\CommissisionReconciliation\\Review\\";
            this.ftbcDialogBox.Multiselect = true;
            this.ftbcDialogBox.RestoreDirectory = true;
            this.ftbcDialogBox.Title = "Please Select PNG File(s) for Conversion";
            this.ftbcDialogBox.FileOk += new System.ComponentModel.CancelEventHandler(this.ftbcDialogBox_FileOk);
            // 
            // ftbConvertButton
            // 
            this.ftbConvertButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ftbConvertButton.Location = new System.Drawing.Point(275, 163);
            this.ftbConvertButton.Name = "ftbConvertButton";
            this.ftbConvertButton.Size = new System.Drawing.Size(120, 26);
            this.ftbConvertButton.TabIndex = 7;
            this.ftbConvertButton.Text = "Files to be Converted";
            this.ftbConvertButton.ToolTip = "Choose which file(s) you would like to be converted to SVG ";
            this.ftbConvertButton.Click += new System.EventHandler(this.ftbConvert_Click);
            // 
            // ofdButton
            // 
            this.ofdButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ofdButton.Location = new System.Drawing.Point(275, 307);
            this.ofdButton.Name = "ofdButton";
            this.ofdButton.Size = new System.Drawing.Size(120, 26);
            this.ofdButton.TabIndex = 8;
            this.ofdButton.Text = "Output File Destination";
            this.ofdButton.ToolTip = "Choose the destination you would like for your converted files to be saved";
            this.ofdButton.Click += new System.EventHandler(this.ofdButton_Click);
            // 
            // svgConvertB
            // 
            this.svgConvertB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.svgConvertB.Location = new System.Drawing.Point(633, 560);
            this.svgConvertB.Name = "svgConvertB";
            this.svgConvertB.Size = new System.Drawing.Size(120, 26);
            this.svgConvertB.TabIndex = 9;
            this.svgConvertB.Text = "Convert to SVG";
            // 
            // sourceFiles
            // 
            this.sourceFiles.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceFiles.Appearance.Options.UseFont = true;
            this.sourceFiles.Location = new System.Drawing.Point(445, 112);
            this.sourceFiles.Name = "sourceFiles";
            this.sourceFiles.Size = new System.Drawing.Size(530, 145);
            this.sourceFiles.TabIndex = 2;
            // 
            // outputfilepath
            // 
            this.outputfilepath.Location = new System.Drawing.Point(445, 313);
            this.outputfilepath.Name = "outputfilepath";
            this.outputfilepath.Size = new System.Drawing.Size(530, 20);
            this.outputfilepath.TabIndex = 10;
            // 
            // imagePlaced
            // 
            this.imagePlaced.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imagePlaced.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.SplitButton;
            this.imagePlaced.Location = new System.Drawing.Point(275, 386);
            this.imagePlaced.Name = "imagePlaced";
            this.imagePlaced.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.imagePlaced.Size = new System.Drawing.Size(135, 26);
            this.imagePlaced.TabIndex = 11;
            this.imagePlaced.Text = "Embedded Image";
            this.imagePlaced.Click += new System.EventHandler(this.imagePlaced_Click);
            // 
            // overlayImage
            // 
            this.overlayImage.Location = new System.Drawing.Point(445, 392);
            this.overlayImage.Name = "overlayImage";
            this.overlayImage.Size = new System.Drawing.Size(530, 20);
            this.overlayImage.TabIndex = 12;
            // 
            // SVGCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1320, 729);
            this.Controls.Add(this.overlayImage);
            this.Controls.Add(this.imagePlaced);
            this.Controls.Add(this.outputfilepath);
            this.Controls.Add(this.sourceFiles);
            this.Controls.Add(this.svgConvertB);
            this.Controls.Add(this.ofdButton);
            this.Controls.Add(this.ftbConvertButton);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Name = "SVGCreation";
            this.Text = "SVGCreation";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sourceFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputfilepath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayImage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

       

        #endregion



        private System.Windows.Forms.OpenFileDialog ftbcDialogBox;
        private System.Windows.Forms.FolderBrowserDialog outDialogBox;
        private DevExpress.XtraEditors.SimpleButton ftbConvertButton;
        private DevExpress.XtraEditors.SimpleButton ofdButton;
        private DevExpress.XtraEditors.SimpleButton svgConvertB;
        private DevExpress.XtraEditors.ListBoxControl sourceFiles;
        private DevExpress.XtraEditors.TextEdit outputfilepath;
        private DevExpress.XtraEditors.DropDownButton imagePlaced;
        private DevExpress.XtraEditors.TextEdit overlayImage;

    
     }
}