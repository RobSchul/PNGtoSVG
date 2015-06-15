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
            return amount;

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
                    if (P.X == baseR.X - 1)
                    {
                        baseR.X = P.X;
                        baseR.Width++;
                    }
                    if (P.Y == baseR.Y - 1)
                    {
                        baseR.Y = P.Y;
                        baseR.Height++;
                    }
                }

                points.RemoveAll(P => baseR.Contains(P, true));
                Boolean dupe = false;
                foreach (RectangleP rectan in ret)
                {
                    Rectangle rec = baseR.Rectangle;
                    Rectangle old = rectan.Rectangle;
                    if (baseR.Location == rectan.Location || rec.IntersectsWith(old) || old.IntersectsWith(rec))
                    {
                        dupe = true;
                        break;
                    }
                }
                if (!dupe && baseR.Width > 100 && baseR.Height > 100)
                {
                    ret.Add(baseR);
                }

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

        public Bitmap MyBitmap
        {
            get { return myBitmap; }
            set { myBitmap = value; }
        }
    }
}