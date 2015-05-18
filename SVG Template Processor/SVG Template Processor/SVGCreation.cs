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
    public partial class SVGCreation : Form
    {

        public SVGCreation()
        {
            InitializeComponent();
        }
        /* private void button1_Click(object sender, EventArgs e)
         {
             int size = -1;
             DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
             if (result == DialogResult.OK) // Test result.
             {
                 string file = openFileDialog1.FileName;
                 try
                 {
                     string text = File.ReadAllText(file);
                     size = text.Length;
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                 }
             }
             Console.WriteLine(size); // <-- Shows file size in debugging mode.
             Console.WriteLine(result); // <-- For debugging use.
         }*/


       
    }
}

