


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
            this.ftbConvert = new System.Windows.Forms.Button();
            this.ftbcDialogBox = new System.Windows.Forms.OpenFileDialog();
            this.listBoxSourceFiles = new System.Windows.Forms.ListBox();
            this.outputDest = new System.Windows.Forms.Button();
            this.outputDestinationBox = new System.Windows.Forms.TextBox();
            this.outDialogBox = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // ftbConvert
            // 
            this.ftbConvert.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ftbConvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ftbConvert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ftbConvert.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ftbConvert.FlatAppearance.BorderSize = 10;
            this.ftbConvert.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ftbConvert.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ftbConvert.Location = new System.Drawing.Point(78, 53);
            this.ftbConvert.Name = "ftbConvert";
            this.ftbConvert.Size = new System.Drawing.Size(135, 45);
            this.ftbConvert.TabIndex = 0;
            this.ftbConvert.Text = "Files to be converted";
            this.ftbConvert.UseVisualStyleBackColor = false;
            this.ftbConvert.Click += new System.EventHandler(this.ftbConvert_Click);
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
            // listBoxSourceFiles
            // 
            this.listBoxSourceFiles.AllowDrop = true;
            this.listBoxSourceFiles.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSourceFiles.FormattingEnabled = true;
            this.listBoxSourceFiles.ItemHeight = 15;
            this.listBoxSourceFiles.Location = new System.Drawing.Point(261, 30);
            this.listBoxSourceFiles.MaximumSize = new System.Drawing.Size(530, 600);
            this.listBoxSourceFiles.MinimumSize = new System.Drawing.Size(530, 100);
            this.listBoxSourceFiles.Name = "listBoxSourceFiles";
            this.listBoxSourceFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxSourceFiles.Size = new System.Drawing.Size(530, 94);
            this.listBoxSourceFiles.TabIndex = 2;
            // 
            // outputDest
            // 
            this.outputDest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outputDest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.outputDest.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputDest.Location = new System.Drawing.Point(78, 196);
            this.outputDest.Name = "outputDest";
            this.outputDest.Size = new System.Drawing.Size(135, 41);
            this.outputDest.TabIndex = 3;
            this.outputDest.Text = "Output Destination";
            this.outputDest.UseVisualStyleBackColor = true;
            this.outputDest.Click += new System.EventHandler(this.outputDest_Click);
            // 
            // outputDestinationBox
            // 
            this.outputDestinationBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.outputDestinationBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputDestinationBox.Location = new System.Drawing.Point(261, 207);
            this.outputDestinationBox.MaximumSize = new System.Drawing.Size(530, 25);
            this.outputDestinationBox.MinimumSize = new System.Drawing.Size(530, 25);
            this.outputDestinationBox.Name = "outputDestinationBox";
            this.outputDestinationBox.Size = new System.Drawing.Size(530, 22);
            this.outputDestinationBox.TabIndex = 4;
            this.outputDestinationBox.TabStop = false;
            // 
            // SVGCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(854, 480);
            this.Controls.Add(this.outputDestinationBox);
            this.Controls.Add(this.outputDest);
            this.Controls.Add(this.listBoxSourceFiles);
            this.Controls.Add(this.ftbConvert);
            this.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Name = "SVGCreation";
            this.Text = "SVGCreation";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        

        private System.Windows.Forms.Button ftbConvert;
        private System.Windows.Forms.OpenFileDialog ftbcDialogBox;
        private System.Windows.Forms.ListBox listBoxSourceFiles;
        private System.Windows.Forms.Button outputDest;
         private System.Windows.Forms.TextBox outputDestinationBox;
        private System.Windows.Forms.FolderBrowserDialog outDialogBox;
     }
}