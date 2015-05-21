using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
                <svg version=""1.1"" id=""Layer_1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink""> <image overflow=""visible""";

                foreach (string pngFile in pngFiles)
                {
                    Bitmap myBitmap = new Bitmap(pngFile);
                     picEmbedd += " width=" + "\"" + myBitmap.Width + "\"" + " height=" + "\"" + myBitmap.Height + "\"" + @" xlink:href=""data:image/png;base64,";
                    string base64 = ImageToBase64(myBitmap);
                    Image image;
                    byte[] data = Convert.FromBase64String(base64);
                    using (var stream = new MemoryStream(data, 0, data.Length))
                    {
                         image = Image.FromStream(stream);
                        //TODO: do something with image
                    } try
                    {
                        image.Save(@"c:\Users\rschultz\Desktop\myfilename5.png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch(Exception e)
                    {

                    }
                    picEmbedd += "" + base64 + "\">" + "</image> </svg>";
                    myBitmap.Dispose();

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\Users\rschultz\Desktop\myfilename.svg"))
                    {
                        file.Write(picEmbedd);
                    }
                    

                    
                    

                }
            
             
            }

        public string ImageToBase64(Bitmap myBitmap)
                {
                    MemoryStream ms = new MemoryStream();
                    myBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] byteImage = ms.ToArray();
                    ms.Dispose();
                    return Convert.ToBase64String(byteImage);
                }



        
        
    }
}
