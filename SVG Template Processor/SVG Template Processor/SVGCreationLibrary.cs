using System;
using System.Drawing;
using System.Linq;
namespace SVG_Template_Processor
{

    public class SVGCreationLibrary
    {
        private string[] pngFilePaths;
        private string[] pngFileNames;
        
        private string outLocation = "";
        private string linkedImageURL = "";
        private string urlFinalImage = "";


        public SVGCreationLibrary(string[] pngFileLocation, string locat, string[] pngFile)
        {   //creation of everything
            pngFilePaths = pngFileLocation;
            outLocation = locat;
            pngFileNames = pngFile;
           
        }
        private System.Drawing.Rectangle[] getRegions(System.Drawing.Bitmap file)
        {
            imageProcessingLibrary process = new imageProcessingLibrary(file);
            imageProcessingLibrary process2 = new imageProcessingLibrary(file);
            System.Drawing.Rectangle[] rect = {new Rectangle(1,1,1,1) }; // = process.getTRegions();
            return rect;
        }

        /// <summary>
        /// build the svg depending on what was chosen 
        /// either embedded or linked image
        /// </summary>
        public void buildSVG()
        {
            var pathsAndName = pngFilePaths.Zip(pngFileNames, (path, name) => new { Path = path, Name = name });

            double amount = pngFilePaths.Length;

            System.Threading.Tasks.Parallel.ForEach(pathsAndName, pngFile =>
            {
                if(!pngFile.Path.Contains(".Png"))
                    embeddedImage(pngFile.Path, pngFile.Name);//send to the embedding method 
                else
                    linkedImage(pngFile.Path);//sent to the linked method 

              });
        }




        /// <summary>
        /// change the bitmap file into a base64 string for the svg file
        /// </summary>
        /// <param name="myBitmap"></param>
        /// <returns></returns>
        private string ImageToBase64(System.Drawing.Bitmap myBitmap)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();//change the bitmap file into base64 for the svg file
            myBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            ms.Dispose();//cleaning 
            return Convert.ToBase64String(byteImage);//return the convert
        }

        /// <summary>
        /// Save the file into a certian location
        /// </summary>
        /// <param name="picEmbedd">file to be saved</param>
        /// <param name="pngFileName">location to be saved</param>
        private void save(string picEmbedd, string pngFileName)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outLocation + "\\" + pngFileName + ".svg")) //write the file to the certian location
            {
                file.Write(picEmbedd);//write to location  
                file.Dispose();
            } //cleaning
        }

        

        /// <summary>
        /// creation of the svg file with an embedded image 
        /// </summary>
        private void embeddedImage(string pngFilePath, string pngFileName)
        {
            System.Drawing.Bitmap myBitmap = new System.Drawing.Bitmap(pngFilePath);//create bitmap of the image  
            double num = autoSize(myBitmap);
            string picEmbedd = @"<svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink""><g transform=""matrix("+ num + " 0 0 "+ num +" 0 0)\">"; //top half of svg
            //where the unique ids will be put into the SVG
            System.Drawing.Rectangle[] ids = getRegions(myBitmap);
            for (int i = 0; i < ids.Length; i++)
            {
                picEmbedd += "<rect id=\"" + i + "\" x= \"" + ids[i].X + "\" y=\"" + ids[i].Y + "\" width=\"" + ids[i].Width + "\" height=\"" + ids[i].Height + "\"  style=\"fill: #00cc00\"/>";

            }
            string base64 = ImageToBase64(myBitmap);//change the image into base64 for the svg  
            picEmbedd += @"<image overflow=""visable""" + " width=" + "\"" + myBitmap.Width + "\"" + " height=" + "\"" +
                myBitmap.Height + "\"" + @" xlink:href=""data:image/png;base64," + base64 + "\"><g></image></svg>";

            save(picEmbedd, pngFileName);
            myBitmap.Dispose();//dispose of the image

        }


        /// <summary>
        /// creation of the svg file with a linked image 
        /// </summary>
        private void linkedImage(string pngFile)
        {
            string picEmbedd = @"<?xml version=""1.0"" encoding=""utf-8""?> <!DOCTYPE svg PUBLIC ""-//W3C//DTD SVG 1.1//EN"" ""http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd"">
            <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:svg=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"">"; //top part of svg
            picEmbedd += "<g>" + @"<image xlink:href=""";
            picEmbedd += pngFile;
            picEmbedd += " </g></svg>";

        }



        /// <summary>
        /// get the image of what has been linked into the linked embedding
        /// </summary>
        /// <param name="link"> where you would get the image</param>
        private void getImage(string link)
        {
            System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(link);
            System.Net.HttpWebResponse httpWebReponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
            System.IO.Stream stream = httpWebReponse.GetResponseStream();
            //Image.FromStream(stream).Save("c:\\button.png", System.Drawing.Imaging.ImageFormat.Png);


        }

        private double autoSize(Bitmap myBitmap)
        {
            double dpiX = myBitmap.Height / myBitmap.VerticalResolution;
            double dpiY = myBitmap.Width / myBitmap.HorizontalResolution;
            double num = 0;
            if (dpiY != dpiX && dpiX < dpiY)
                num = (dpiX + dpiY) / (myBitmap.Height + myBitmap.Width);
            else if (dpiY == dpiX && myBitmap.Width == myBitmap.Height)
                num = (dpiX + dpiY) / (myBitmap.Height + myBitmap.Width);
            else
            {
                num = (dpiX / myBitmap.Width) / (dpiY / myBitmap.Height);
                if (num >= 1)
                {
                    num = .17;
                }
            }

            while (num < .1)
            {
                num *= 10;
            }
            return num = Math.Floor(num * 100) / 100;
        }
        public string LinkedImageURL
        {
            get { return linkedImageURL; }
            set { linkedImageURL = value; }
        }
        public string OutLocation
        {
            get { return outLocation; }
            set { outLocation = value; }
        }
        public string UrlFinalImage
        {
            get { return urlFinalImage; }
            set { urlFinalImage = value; }
        }
        public string[] PngFilePaths
        {
            get { return pngFilePaths; }
            set { pngFilePaths = value; }
        }
        

        public string[] PngFileNames
        {
            get { return pngFileNames; }
            set { pngFileNames = value; }
        }


    }
}
