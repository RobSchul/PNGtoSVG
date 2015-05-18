using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Windows;
using System.IO.Log;
using Microsoft.VisualBasic.Logging;

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
            this.ftbConvert.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ftbConvert.Location = new System.Drawing.Point(38, 30);
            this.ftbConvert.Name = "ftbConvert";
            this.ftbConvert.Size = new System.Drawing.Size(175, 42);
            this.ftbConvert.TabIndex = 0;
            this.ftbConvert.Text = "Files to be converted";
            this.ftbConvert.UseVisualStyleBackColor = false;
            this.ftbConvert.Click += new System.EventHandler(this.ftbConvert_Click);
            // 
            // ftbcDialogBox
            // 
            this.ftbcDialogBox.Filter = "Images (*.PNG)|*.PNG|All files (*.*)|*.*";
            this.ftbcDialogBox.Multiselect = true;
            this.ftbcDialogBox.Title = "My Image Browser";
            this.ftbcDialogBox.FileOk += new System.ComponentModel.CancelEventHandler(this.ftbcDialogBox_FileOk);
            this.ftbcDialogBox.InitialDirectory = "i:\\CommissisionReconciliation\\Review\\"; this.ftbcDialogBox.FilterIndex = 1;
            this.ftbcDialogBox.RestoreDirectory = true;
            this.ftbcDialogBox.Multiselect = true;
            this.ftbcDialogBox.Title = "Please Select PNG File(s) for Conversion";
            // 
            // listBoxSourceFiles
            // 
            this.listBoxSourceFiles.AllowDrop = true;
            this.listBoxSourceFiles.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSourceFiles.FormattingEnabled = true;
            this.listBoxSourceFiles.ItemHeight = 19;
            this.listBoxSourceFiles.Location = new System.Drawing.Point(261, 30);
            this.listBoxSourceFiles.MaximumSize = new System.Drawing.Size(530, 600);
            this.listBoxSourceFiles.MinimumSize = new System.Drawing.Size(530, 100);
            this.listBoxSourceFiles.Name = "listBoxSourceFiles";
            this.listBoxSourceFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxSourceFiles.Size = new System.Drawing.Size(530, 99);
            this.listBoxSourceFiles.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(854, 480);
            this.Controls.Add(this.listBoxSourceFiles);
            this.Controls.Add(this.ftbConvert);
            this.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Name = "Form2";
            this.Text = "SVGCreation";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion
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

        private System.Windows.Forms.Button ftbConvert;
        private System.Windows.Forms.OpenFileDialog ftbcDialogBox;
        private ListBox listBoxSourceFiles;
     }
}