using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;

namespace SVG_Template_Processor
{
    class imageProcessingLibrary
    {
        private Bitmap myBitmap;

        public imageProcessingLibrary(Bitmap bits)
        {
            myBitmap = bits;

        }
        /// <summary>
        ///  get all regions that are transparent and sent back an array of RectanglePs  
        ///  
        /// </summary>
        public RectangleP[] getTRegions()
        {
            BitmapData bmData = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height), ImageLockMode.ReadOnly, myBitmap.PixelFormat);
            RectangleP[] amount = mapTpoints(findTPoints(myBitmap, bmData));
            if (amount.Count() > 1)
                return amount;
            else
                return GetMinMaxBox(findTPoints(myBitmap, bmData));
        }
        /// <summary>
        ///  map out the points for the RectangleP holes 
        ///  put those into an array for easy labeling of where they are
        /// </summary>
        private RectangleP[] mapTpoints(List<Point> points)
        {
            List<RectangleP> ret = new List<RectangleP>();
            while (points.Count > 0)
            {
                Point pBase = points[0];
                RectangleP baseR = new RectangleP(pBase, new Size(1, 1)); //create RectangleP with first point of transparancy and size of 1,1
                List<Point> RecPoints = new List<Point> { };

                foreach (Point P in points)
                {
                    if (P.Y == (baseR.Y + baseR.Height) + 1)
                        baseR.Height++;
                    if (P.X == (baseR.X + baseR.Width) + 1)
                        baseR.Width++;
                }

                /* //problem mapping some templates
                  foreach (Point point in RecPoints)
                  {
                     if (point.Y == (baseR.Y + baseR.Height) + 1) //mapping the height of each RectangleP within the template
                         baseR.Height++;
                     if (point.X == (baseR.X + baseR.Width) + 1) // mapping the width of each RectangleP within the template
                         baseR.Width++;
                 }*/
                points.RemoveAll(P => baseR.Contains(P));
                if (baseR.Width > 100 && baseR.Height > 100)
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
            {
                for (int x = startX; x < stopX; x++)
                    for (int p = 0; p < pixelSize; p++, point++)
                    {
                        switch (p)
                        {
                            case 3:
                                if (*point == 0)
                                    Points.Add(new Point(x, y));

                                break;
                        }
                    }
                point += offset;
            }


            return Points;

        }
        // Find the points nearest the upper left, upper right,
        // lower left, and lower right corners.
        private static void GetMinMaxCorners(List<Point> points, ref Point upperMostPoint, ref Point lowerMostPoint, ref Point leftMost, ref Point rightMost)
        {  //Start with the first point
            upperMostPoint = lowerMostPoint = leftMost = rightMost = points[0];
            //Search the other points.
            foreach (Point point in points)
            {
                if (point.Y > lowerMostPoint.Y)
                    lowerMostPoint.Y = point.Y;
                if (point.Y < upperMostPoint.Y)
                    upperMostPoint.Y = point.Y;
                if (point.X < leftMost.X)
                    leftMost.X = point.X;
                if (point.X > rightMost.X)
                    rightMost.X = point.X;
            }
        }


        // Find a box that fits inside the MinMax quadrilateral.
        private static RectangleP[] GetMinMaxBox(List<Point> points)
        { // Find the MinMax quadrilateral.
            Point lowerMost = new Point(0, 0), leftMost = lowerMost, rightMost = lowerMost, upperMost = lowerMost;
            GetMinMaxCorners(points, ref upperMost, ref lowerMost, ref leftMost, ref rightMost);
            RectangleP[] result = new RectangleP[] { new RectangleP(leftMost.X, upperMost.Y, rightMost.X - leftMost.X, lowerMost.Y - upperMost.Y) };
            return result;
        }

        public Bitmap MyBitmap
        {
            get { return myBitmap; }
            set { myBitmap = value; }
        }
    }
}