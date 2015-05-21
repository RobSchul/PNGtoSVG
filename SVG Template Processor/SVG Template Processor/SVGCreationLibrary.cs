using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVG_Template_Processor
{   
    class SVGCreationLibrary
    {   private string[] pngFilePaths;
        private string[] pngFileNames;
        private string type ="";
        private string outLocation = "";

        public SVGCreationLibrary(string[] pngFileLocation ,string sType, string locat, string[] pngFile)
            {   //creation of everything
                pngFilePaths = pngFileLocation;
                type = sType;
                outLocation = locat;
                pngFileNames = pngFile;
            }
        private Rectangle[] getRegions(string file)
            {
                imageProcessingLibrary process = new imageProcessingLibrary(file);
                Rectangle[] rect = process.getTRegions(); 
                return rect;
            }

        /// <summary>
        /// build the svg depending on what was chosen 
        /// either embedded or linked image
        /// </summary>
        public void buildSVG()
            {
                if (type.Equals("Embedded Image"))
                    embeddedImage(); //send to the embedding method
                else
                {
                    linkedImage(); // sent to the linked method
                }
            
             
            }

        /// <summary>
        /// change the bitmap file into a base64 string for the svg file
        /// </summary>
        /// <param name="myBitmap"></param>
        /// <returns></returns>
        public string ImageToBase64(Bitmap myBitmap)
                {  //change the bitmap file into base64 for the svg file
                    MemoryStream ms = new MemoryStream();
                    myBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] byteImage = ms.ToArray();
                    ms.Dispose(); //cleaning
                    return Convert.ToBase64String(byteImage); //return the convert
                }
        /// <summary>
        /// creation of the svg file with an embedded image 
        /// </summary>
        public void embeddedImage()
        {
            foreach (var pngFile in pngFilePaths.Zip(pngFileNames, (path, name) => new { Path = path, Name = name })) // go through the files 
            {
                string picEmbedd = @"<?xml version=""1.0"" encoding=""utf-8""?> <!DOCTYPE svg PUBLIC ""-//W3C//DTD SVG 1.1//EN"" ""http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd"">
                <svg version=""1.1"" id=""Layer_1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink""> <image overflow=""visible"""; //top half of svg
                Bitmap myBitmap = new Bitmap(pngFile.Path); // create bitmap of the image
                picEmbedd += " width=" + "\"" + myBitmap.Width + "\"" + " height=" + "\"" + myBitmap.Height + "\"" + @" xlink:href=""data:image/png;base64,"; // embedd image into the svg file
                string base64 = ImageToBase64(myBitmap); // change the image into base64 for the svg
                picEmbedd += "" + base64 + "\" transform=\"matrix(0.24 0 0 0.24 0 0)\"></image> </svg>"; // end of the svg file
                myBitmap.Dispose(); // dispose of the image
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(outLocation + "\\" + pngFile.Name + ".svg")) // write the file to the certian location
                {   file.Write(picEmbedd); // write to location
                    file.Dispose();} // cleaning
            }
        }

        /// <summary>
        /// creation of the svg file with a linked image 
        /// </summary>
        public void linkedImage()
        {
            foreach (string pngFile in pngFilePaths)
            {
                Bitmap myBitmap = new Bitmap(pngFile);
                int hight = myBitmap.Height;
                int width = myBitmap.Width;

                Color[][] colorMatrix = new Color[width][];
                for (int i = 0; i < width; i++)
                {
                    colorMatrix[i] = new Color[hight];
                    for (int j = 0; j < hight; j++)
                    {
                        colorMatrix[i][j] = new Color();
                        colorMatrix[i][j] = myBitmap.GetPixel(i, j);
                    }
                }
            }
                
        }

        /// <summary>
        /// set the type of image that will be put in the SVG
        /// either Embedded or linked image
        /// </summary>
        /// /// <param name="sType"></param>
        public void setType(string sType)
        {
            type = sType;
        }
        /// <summary>
        /// set the location that the file will be put
        /// </summary>
        /// <param name="locat"></param>
        public void setOutLoca(string locat)
        {
            outLocation = locat;
        }
        /// <summary>
        /// get the type of image that is going to be put into the SVG
        /// </summary>
        /// <returns>Embedded Image, Linked Image will, or null</returns>
        public string getType()
        {
            return type;
        }
        /// <summary>
        /// get the location that the files will be put after turning into an SVG
        /// </summary>
        /// <returns></returns>
        public string getOutLoca()
        {
            return outLocation;
        }
    }
}
