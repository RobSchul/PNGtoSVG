using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVG_Template_Processor
{   
    class SVGCreationLibrary
    {   private string[] pngFiles;
    private string[] a;  
        public SVGCreationLibrary(string[] pngFileLocations)
            {
                pngFiles = pngFileLocations;
            }
        private Rectangle[] getRegions(string file)
            {
                imageProcessingLibrary process = new imageProcessingLibrary(file);
                Rectangle[] rect = process.getTRegions(); 
                return rect;
            }

        public void buildSVG()
            {
                string picEmbedd = @"<?xml version=""1.0"" encoding=""utf-8""?> <!DOCTYPE svg PUBLIC ""-//W3C//DTD SVG 1.1//EN"" ""http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd"">
                <svg version=""1.1"" id=""Layer_1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" x=""0px"" y=""0px""
	                 width=""270px"" height=""455.977px"" viewBox=""0 0 270 455.977"" enable-background=""new 0 0 270 455.977"" xml:space=""preserve""> <image overflow=""visible""";

                foreach (string pngFile in pngFiles)
                {
                    Bitmap myBitmap = new Bitmap(pngFile);
                     picEmbedd += "width=" + "\"" + myBitmap.Width + "\"" + "height=" + "\"" + myBitmap.Height + "\"" + @"xlink:href=""data:image/png;base64,";
                    string base64 = ImageToBase64(myBitmap);
                    picEmbedd += "" + base64 + "\">" + "</image> </svg>";
                    myBitmap.Dispose();
                    picEmbedd.Save("file.svg");
                    

                }
            
             
            }

        public string ImageToBase64(Bitmap myBitmap)
                {
                    MemoryStream ms = new MemoryStream();
                    myBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] byteImage = ms.ToArray();
                    return Convert.ToBase64String(byteImage);
                }



        
        
    }
}
