using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace SVG_Template_Processor
{
    class imageProcessingLibrary
    {
        private Bitmap myBitmap;

        public  imageProcessingLibrary(Bitmap bits)
            {
                myBitmap = bits;
           
            }
        /// <summary>
        ///  get all regions that are transparent and sent back an array of rectangles  
        ///  
        /// </summary>
        public Rectangle[] getTRegions()
        {
            BitmapData bmData = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height), ImageLockMode.ReadOnly, myBitmap.PixelFormat);
            List<Point> Points = findTPoints(myBitmap, bmData);
             return mapTpoints(Points);

        }
        /// <summary>
        ///  map out the points for the rectangle holes 
        ///  put those into an array for easy labeling of where they are
        /// </summary>
        private Rectangle[] mapTpoints(List<Point> points)
        {   List<Rectangle> ret = new List<Rectangle>();
            while (points.Count > 0)
            {
                Point pBase = points[0];
                Rectangle baseR = new Rectangle(pBase, new Size(1, 1)); //create rectangle with first point of transparancy and size of 1,1 because one pixel
                List<Point> RecPoints = (from P in points where P.X == baseR.X || P.Y == baseR.Y select P).ToList(); //list of points?
                foreach (Point point in RecPoints)
                {
                    if (point.X == pBase.X && point.Y == (baseR.Y + baseR.Height) + 1)
                        baseR.Height++;
                    if (point.Y == pBase.Y && point.X == (baseR.X + baseR.Width) + 1)
                        baseR.Width++;
                }
                points.RemoveAll(P => baseR.Contains(P));// problem in this area
                if (baseR.Width > 1 && baseR.Height > 1)
                    ret.Add(baseR);
                
            }
            return ret.ToArray();
        }
        /// <summary>
        ///  find the transparent points
        /// </summary>
        private unsafe List<Point> findTPoints(Bitmap myBitmap, BitmapData bmData)
        {
            int pixelSize = 4, startX = 0, startY = 0;
            int stopX = startX + myBitmap.Width;
            int stopY = startY + myBitmap.Height;
            int offset = bmData.Stride - myBitmap.Width * pixelSize;
            List<Point> Points = new List<Point>();


            byte* point = (byte*)bmData.Scan0;
            //point to the first pixel 
            point += (startY * bmData.Stride + startX);
            //search through the picture finding all transparent points and adding them to a points list
            for (int y = startY; y < stopY; y++)
            {   for (int x = startX; x < stopX; x++)
                    for (int p = 0; p < pixelSize; p++, point++)
                    {  switch (p)
                        {   case 3:
                                if (*point < 255)
                                    Points.Add(new Point(x, y));

                                break;
                        }
                }
                point += offset;
            }
            
            myBitmap.UnlockBits(bmData);
            //myBitmap.Dispose();
            myBitmap = null;
            return Points;

        }

        public Bitmap MyBitmap
        {
            get { return myBitmap; }
            set { myBitmap = value; }
        }

        public Bitmap Transparent2Color()
        {   Color white = Color.White;
            
            Rectangle[] rect = getTRegions();

            
            SolidBrush blueBrush = new SolidBrush(Color.Yellow);

            for (int i = 0, b = 0; i < rect.Length; i++, b++)
            {
                Rectangle r;
                r = rect[i];
                SolidBrush[] aColors = new SolidBrush[] { new SolidBrush(Color.Blue), new SolidBrush(Color.Red), new SolidBrush(Color.Black),
                            new SolidBrush(Color.Brown),new SolidBrush(Color.Purple),new SolidBrush(Color.SeaGreen)};
                Graphics g = Graphics.FromImage(myBitmap);
                g.FillRectangle(aColors[b], r);
                if (b == aColors.Length - 1)
                    b = 0;
                string text2 = "" + i;
                Font font2 = new Font("Arial",  100, FontStyle.Bold, GraphicsUnit.Point);


                TextFormatFlags flags = TextFormatFlags.WordBreak;
                TextRenderer.DrawText(g, text2, font2, r, Color.White, flags);
                g.Dispose();
                
    }

            /*for (int x = 0; x < myBitmap.Width; x++)
                for (int y = 0; y < myBitmap.Height; y++)
                {
                    c = myBitmap.GetPixel(x, y);
                    myBitmap.SetPixel(x, y, ((((short)(c.A)) & 0x00FF) <= 0) ? white : c); 
                }
             * 
             * Rectangle r;
                r = rect[i];
                Graphics g = Graphics.FromImage(myBitmap);
                System.Drawing.SolidBrush myBrush = aColors[1];
                g.FillRectangle(myBrush, r);
                string text2 = "" + i;
                Font font2 = new Font("Arial", 60, FontStyle.Bold, GraphicsUnit.Point);
                 TextFormatFlags flags = TextFormatFlags.WordBreak;
                TextRenderer.DrawText(g, text2, font2, r, Color.Blue, flags);
                if (b == aColors.Length - 2)
                    b = 0;
                g.Dispose(); myBrush.Dispose();
             * 
             * 
        */
            return myBitmap;

        }




    }
}
