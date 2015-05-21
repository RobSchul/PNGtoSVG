
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SVGCreation));
            this.ftbcDialogBox = new System.Windows.Forms.OpenFileDialog();
            this.outDialogBox = new System.Windows.Forms.FolderBrowserDialog();
            this.ftbConvertButton = new DevExpress.XtraEditors.SimpleButton();
            this.ofdButton = new DevExpress.XtraEditors.SimpleButton();
            this.svgConvertB = new DevExpress.XtraEditors.SimpleButton();
            this.sourceFiles = new DevExpress.XtraEditors.ListBoxControl();
            this.ftbEmbedded = new System.Windows.Forms.OpenFileDialog();
            this.outputfilepath = new DevExpress.XtraEditors.TextEdit();
            this.imagePlaced = new DevExpress.XtraEditors.DropDownButton();
            this.overlayImage = new DevExpress.XtraEditors.TextEdit();
            this.removSeleButton = new DevExpress.XtraEditors.SimpleButton();
            this.validation = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sourceFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputfilepath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validation)).BeginInit();
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
            this.ofdButton.Location = new System.Drawing.Point(275, 372);
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
            this.svgConvertB.Location = new System.Drawing.Point(584, 563);
            this.svgConvertB.Name = "svgConvertB";
            this.svgConvertB.Size = new System.Drawing.Size(120, 26);
            this.svgConvertB.TabIndex = 9;
            this.svgConvertB.Text = "Convert to SVG";
            this.svgConvertB.Click += new System.EventHandler(this.svgConvertB_Click);
            // 
            // sourceFiles
            // 
            this.sourceFiles.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceFiles.Appearance.Options.UseFont = true;
            this.sourceFiles.Location = new System.Drawing.Point(445, 112);
            this.sourceFiles.Name = "sourceFiles";
            this.sourceFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.sourceFiles.Size = new System.Drawing.Size(530, 199);
            this.sourceFiles.TabIndex = 2;
            this.sourceFiles.ToolTip = "PNG files that will be converted into SVG files";
            // 
            // ftbEmbedded
            // 
            this.ftbEmbedded.InitialDirectory = "i:\\CommissisionReconciliation\\Review\\";
            this.ftbEmbedded.Multiselect = true;
            this.ftbEmbedded.RestoreDirectory = true;
            this.ftbEmbedded.FileOk += new System.ComponentModel.CancelEventHandler(this.ftbcDialogBox_FileOk);
            // 
            // outputfilepath
            // 
            this.outputfilepath.EditValue = "";
            this.outputfilepath.Location = new System.Drawing.Point(445, 378);
            this.outputfilepath.Name = "outputfilepath";
            this.outputfilepath.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.outputfilepath.Size = new System.Drawing.Size(530, 20);
            this.outputfilepath.TabIndex = 10;
            this.outputfilepath.ToolTip = "Destination of where the converted SVG files will go";
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Cannot be left empty";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            conditionValidationRule1.Value1 = "Please Enter Your Name";
            this.validation.SetValidationRule(this.outputfilepath, conditionValidationRule1);
            // 
            // imagePlaced
            // 
            this.imagePlaced.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imagePlaced.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.SplitButton;
            this.imagePlaced.Location = new System.Drawing.Point(275, 451);
            this.imagePlaced.Name = "imagePlaced";
            this.imagePlaced.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.imagePlaced.Size = new System.Drawing.Size(135, 26);
            this.imagePlaced.TabIndex = 11;
            this.imagePlaced.Text = "Embedded Image";
            this.imagePlaced.Click += new System.EventHandler(this.imagePlaced_Click);
            // 
            // overlayImage
            // 
            this.overlayImage.Location = new System.Drawing.Point(445, 457);
            this.overlayImage.Name = "overlayImage";
            this.overlayImage.Size = new System.Drawing.Size(530, 20);
            this.overlayImage.TabIndex = 12;
            this.overlayImage.ToolTip = "File Path to the file that will be embedded into the SVG";
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Cannot be left empty";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            this.validation.SetValidationRule(this.overlayImage, conditionValidationRule2);
            // 
            // removSeleButton
            // 
            this.removSeleButton.Location = new System.Drawing.Point(981, 163);
            this.removSeleButton.Name = "removSeleButton";
            this.removSeleButton.Size = new System.Drawing.Size(120, 26);
            this.removSeleButton.TabIndex = 13;
            this.removSeleButton.Text = "Remove Selected";
            this.removSeleButton.Click += new System.EventHandler(this.removSeleButton_Click);
            // 
            // validation
            // 
            this.validation.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // SVGCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1320, 729);
            this.Controls.Add(this.removSeleButton);
            this.Controls.Add(this.overlayImage);
            this.Controls.Add(this.imagePlaced);
            this.Controls.Add(this.outputfilepath);
            this.Controls.Add(this.sourceFiles);
            this.Controls.Add(this.svgConvertB);
            this.Controls.Add(this.ofdButton);
            this.Controls.Add(this.ftbConvertButton);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SVGCreation";
            this.Text = "SVGCreation";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sourceFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputfilepath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validation)).EndInit();
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
        private System.Windows.Forms.OpenFileDialog ftbEmbedded;
        private DevExpress.XtraEditors.SimpleButton removSeleButton;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider validation;
        
                    

    
     }
}