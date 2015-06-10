
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SVGCreation));
            this.ftbcDialogBox = new System.Windows.Forms.OpenFileDialog();
            this.outDialogBox = new System.Windows.Forms.FolderBrowserDialog();
            this.ftbConvertButton = new DevExpress.XtraEditors.SimpleButton();
            this.ofdButton = new DevExpress.XtraEditors.SimpleButton();
            this.svgConvertB = new DevExpress.XtraEditors.SimpleButton();
            this.sourceFiles = new DevExpress.XtraEditors.ListBoxControl();
            this.ftbEmbedded = new System.Windows.Forms.OpenFileDialog();
            this.outputfilepath = new DevExpress.XtraEditors.TextEdit();
            this.removSeleButton = new DevExpress.XtraEditors.SimpleButton();
            this.validation = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.bW = new System.ComponentModel.BackgroundWorker();
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.removeAll = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputfilepath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
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
            this.ofdButton.Location = new System.Drawing.Point(275, 407);
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
            this.svgConvertB.Location = new System.Drawing.Point(584, 487);
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
            this.outputfilepath.Location = new System.Drawing.Point(445, 413);
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
            // removSeleButton
            // 
            this.removSeleButton.Location = new System.Drawing.Point(1008, 185);
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
            // bW
            // 
            this.bW.WorkerReportsProgress = true;
            this.bW.WorkerSupportsCancellation = true;
            this.bW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bW_DoWork);
            // 
            // labelControl
            // 
            this.labelControl.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl.ImeMode = System.Windows.Forms.ImeMode.On;
            this.labelControl.Location = new System.Drawing.Point(88, 64);
            this.labelControl.Name = "labelControl";
            this.labelControl.Size = new System.Drawing.Size(0, 18);
            this.labelControl.TabIndex = 15;
            // 
            // removeAll
            // 
            this.removeAll.Location = new System.Drawing.Point(1009, 232);
            this.removeAll.Name = "removeAll";
            this.removeAll.Size = new System.Drawing.Size(119, 25);
            this.removeAll.TabIndex = 16;
            this.removeAll.Text = "Remove All";
            this.removeAll.Click += new System.EventHandler(this.removeAll_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(273, 213);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "Linked image";
            this.checkEdit1.Size = new System.Drawing.Size(96, 19);
            this.checkEdit1.TabIndex = 17;
            this.checkEdit1.ToolTip = "Check this if it is going to be a linked image and not a png file";
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // SVGCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1320, 729);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.removeAll);
            this.Controls.Add(this.labelControl);
            this.Controls.Add(this.removSeleButton);
            this.Controls.Add(this.outputfilepath);
            this.Controls.Add(this.sourceFiles);
            this.Controls.Add(this.svgConvertB);
            this.Controls.Add(this.ofdButton);
            this.Controls.Add(this.ftbConvertButton);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SVGCreation";
            this.Text = "SVG Conversion";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sourceFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputfilepath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion


        
        private System.Windows.Forms.OpenFileDialog ftbcDialogBox;
        private System.Windows.Forms.FolderBrowserDialog outDialogBox;
        private DevExpress.XtraEditors.SimpleButton ftbConvertButton;
        private DevExpress.XtraEditors.SimpleButton ofdButton;
        private DevExpress.XtraEditors.SimpleButton svgConvertB;
        private DevExpress.XtraEditors.ListBoxControl sourceFiles;
        private DevExpress.XtraEditors.TextEdit outputfilepath;
        private System.Windows.Forms.OpenFileDialog ftbEmbedded;
        private DevExpress.XtraEditors.SimpleButton removSeleButton;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider validation;
        private System.ComponentModel.BackgroundWorker bW;
        private DevExpress.XtraEditors.LabelControl labelControl;
        private DevExpress.XtraEditors.SimpleButton removeAll;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;


        
        
                    

    
     }
}