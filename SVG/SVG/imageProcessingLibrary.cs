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

namespace SVG
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
            RectangleP[] amount = mapTpoints(myBitmap,findTPoints(myBitmap, bmData));
            return amount;

        }

        private Point calcFirst(List<Point> _Points, Boolean[,] _ACheck)
        {
            foreach (Point P in _Points)
            {
                if (_ACheck[P.X, P.Y] == false)
                {
                    _ACheck[P.X, P.Y] = true;
                    return  new Point(P.X, P.Y);
                    
                }
            }
            return new Point(-1, -1);
           
        }

        /// <summary>
        ///  map out the points for the RectangleP holes 
        ///  put those into an array for easy labeling of where they are
        /// </summary>
        private unsafe RectangleP[] mapTpoints(Bitmap myBitmap, List<Point> _Points)
        {   List<RectangleP> ret = new List<RectangleP>();
            Boolean[,] _ACheck = new Boolean[myBitmap.Width, myBitmap.Height]; //all set to false meaning not used
            Point _First = calcFirst(_Points,_ACheck);
            
           while (!Point.Equals(_First, new Point(-1, -1)))
            {
                Point pBase = _First;
                RectangleP baseR = new RectangleP(pBase, new Size(1, 1)); //create RectangleP with first point of transparancy and size of 1,1

                ContiguousPointList mappingPoints = new ContiguousPointList() { Variance = 5 };
                mappingPoints.Add(pBase);
                

                foreach (Point P in _Points)
                {
                    if (_ACheck[P.X, P.Y] == false)
                        if (mappingPoints.Touches(P))
                        {
                            mappingPoints.Add(P);
                      
                            _ACheck[P.X, P.Y] = true;
                        }
                }

                 baseR = new RectangleP(mappingPoints.TopLeft, mappingPoints.TopRight, mappingPoints.BottomLeft, mappingPoints.BottomRight);
                 bool dupe = false;
                foreach(RectangleP P in ret)
                {
                    if (P.Contains(baseR.Location))
                    {
                        dupe = true;
                    }
                }
                // 2 dem boolean array 
                 if (!dupe && baseR.Width > 1 && baseR.Height > 1)
                 {
                     
                     ret.Add(baseR);
                 }
                
                _First = calcFirst(_Points, _ACheck);
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
            //List<Point> Points = new List<Point>();
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
                                if (*point < 255)
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