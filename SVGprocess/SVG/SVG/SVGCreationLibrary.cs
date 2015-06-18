using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
namespace SVG
{

    public class SVGCreationLibrary
    {
        private string[] pngFilePaths;
        private string[] pngFileNames;
        private string[] sourceFileLocat;

        private string outLocation = "";
        private string linkedImageURL = "";
        private string urlFinalImage = "";


        public SVGCreationLibrary(string[] pngFileLocation, string locat, string[] pngFile, string[] locate)
        {   //creation of everything
            pngFilePaths = pngFileLocation;
            outLocation = locat;
            pngFileNames = pngFile;
            sourceFileLocat = locate;

        }
        private RectangleP[] getRegions(System.Drawing.Bitmap file)
        {
            imageProcessingLibrary process = new imageProcessingLibrary(file);

            RectangleP[] rect = process.getTRegions();
            return rect;
        }


        /// <summary>
        /// 
        /// </summary>
        public void buildEmbeddSVG()
        {
            var pathsAndName = pngFilePaths.Zip(pngFileNames, (path, name) => new { Path = path, Name = name });

            double amount = pngFilePaths.Length;

            System.Threading.Tasks.Parallel.ForEach(pathsAndName, pngFile =>
            {
                embeddedImage(pngFile.Path, pngFile.Name);//send to the embedding method 
            });

        }


        /// <summary>
        /// 
        /// </summary>
        public void buildLinkedSVG()
        {
            var pathsAndName = pngFilePaths.Zip(pngFileNames, (path, name) => new { Path = path, Name = name });
            System.Threading.Tasks.Parallel.ForEach(pathsAndName, pngFile =>
            {
                linkedImage(pngFile.Path, pngFile.Name);//sent to the linked method 

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
            System.IO.FileInfo filePath = new System.IO.FileInfo(outLocation + "\\" + pngFileName + ".svg");
            filePath.Directory.Create();
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
            System.Drawing.Bitmap myBitmap = new System.Drawing.Bitmap(pngFilePath + "\\" + pngFileName);//create bitmap of the image  
            StringBuilder picEmbedd = new StringBuilder(@"<?xml version=""1.0""?><svg xmlns=""http://www.w3.org/2000/svg""
            xmlns:svg=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" viewBox=""0 0 " + myBitmap.Width + " " + myBitmap.Height + "\">"); //top part of svg
            //where the unique ids will be put into the SVG
            RectangleP[] ids = getRegions(myBitmap);
            for (int i = 0; i < ids.Length; i++)
            {
                int X = 0;
                if (ids[i].X == 0) X = 0;
                else X = (ids[i].X - 2);

                int Y = 0;
                if (ids[i].Y == 0) Y = 0;
                else Y = (ids[i].Y - 1);

                picEmbedd.AppendLine("<rect id=\"" + i + "\" x= \"" + X + "\" y=\"" + Y + "\" width=\"" + (ids[i].Width + 5) + "\" height=\"" + (ids[i].Height + 5) + "\"  style=\"fill: transparent\" transform = \"rotate(" + ids[i].Angle + " " + X + " " + Y + ")\" />");

            }
            string base64 = ImageToBase64(myBitmap);//change the image into base64 for the svg  
            picEmbedd.Append(@"<image overflow=""visable""" + " width=" + "\"" + myBitmap.Width + "\"" + " height=" + "\"" +
                myBitmap.Height + "\"" + @" xlink:href=""data:image/png;base64," + base64 + "\"><g></image></svg>");

            save(picEmbedd.ToString(), pngFileName);
            myBitmap.Dispose();//dispose of the image

        }


        /// <summary>
        /// creation of the svg file with a linked image 
        /// </summary>
        private void linkedImage(string filePath, string fileName)
        {
            Image newImage = Image.FromFile(filePath + "/" + fileName);
            Bitmap myBitmap = new Bitmap(newImage);
            StringBuilder picEmbedd =  new StringBuilder( @"<?xml version=""1.0""?><svg xmlns=""http://www.w3.org/2000/svg""
            xmlns:svg=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" viewBox=""0 0 " + myBitmap.Width + " " + myBitmap.Height + "\">"); //top part of svg

            RectangleP[] ids = getRegions(myBitmap);
            for (int i = 0; i < ids.Length; i++)
            {
                int X = 0;
                if (ids[i].X == 0) X = 0;
                else X = (ids[i].X - 2);

                int Y = 0;
                if (ids[i].Y == 0) Y = 0;
                else Y = (ids[i].Y - 1);

                picEmbedd.AppendLine("<rect id=\"" + i + "\" x= \"" + X + "\" y=\"" + Y + "\" width=\"" + (ids[i].Width + 5) + "\" height=\"" + (ids[i].Height + 5) + "\"  style=\"fill: transparent\" transform = \"rotate(" + ids[i].Angle + " " + X + " " + Y + ")\" />");

            }
            picEmbedd.Append("<g>" + "<image x=\"0\" y=\"0\" width=\"" + newImage.Width + "\" height=\"" + newImage.Height + "\" xlink:href=\"");
            picEmbedd.Append( fileName);
            picEmbedd.AppendLine("\"/> </g></svg>");
            save(picEmbedd.ToString(), fileName);


            System.IO.File.Copy(Path.Combine(filePath, fileName), Path.Combine(outLocation, fileName), true);
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
