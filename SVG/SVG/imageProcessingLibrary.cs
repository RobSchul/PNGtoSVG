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
        private BitmapData bmData;

        public imageProcessingLibrary(Bitmap bits)
        {
            myBitmap = bits;
            bmData = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height), ImageLockMode.ReadOnly, myBitmap.PixelFormat);

        }
        /// <summary>
        ///  get all regions that are transparent and sent back an array of rectangles  
        ///  
        /// </summary>
        public Rectangle[] getTRegions()
        {
            List<Point> Points = findTPoints(myBitmap, bmData);
            return mapTpoints(Points);

        }
        /// <summary>
        ///  map out the points for the rectangle holes 
        ///  put those into an array for easy labeling of where they are
        /// </summary>
        private Rectangle[] mapTpoints(List<Point> points)
        {
            List<Rectangle> ret = new List<Rectangle>();
            while (points.Count > 0)
            {
                Point pBase = points[0];
                Rectangle baseR = new Rectangle(pBase, new Size(1, 1)); //create rectangle with first point of transparancy and size of 1,1 because one pixel
                List<Point> RecPoints = (from P in points where P.X == baseR.X || P.Y == baseR.Y select P).ToList(); //list of points? creating the rectangle problem is here
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

        // Find the polygon's centroid.
        public PointF FindCentroid()
        {
            List<Point> Points = findTPoints(myBitmap, bmData);
            // Add the first point at the end of the array.
            int num_points = Points.Count;
            List<Point> pts = new List<Point>(Points);
            pts[num_points] = Points[0];

            // Find the centroid.
            float X = 0;
            float Y = 0;
            float second_factor;
            for (int i = 0; i < num_points; i++)
            {
                second_factor =
                    pts[i].X * pts[i + 1].Y -
                    pts[i + 1].X * pts[i].Y;
                X += (pts[i].X + pts[i + 1].X) * second_factor;
                Y += (pts[i].Y + pts[i + 1].Y) * second_factor;
            }

            // Divide by 6 times the polygon's area.
            float polygon_area = PolygonArea(Points);
            X /= (6 * polygon_area);
            Y /= (6 * polygon_area);

            // If the values are negative, the polygon is
            // oriented counterclockwise so reverse the signs.
            if (X < 0)
            {
                X = -X;
                Y = -Y;
            }

            return new PointF(X, Y);
        }

        public float PolygonArea(List<Point> Points)
        {
            // Return the absolute value of the signed area.
            // The signed area is negative if the polyogn is
            // oriented clockwise.
            return Math.Abs(SignedPolygonArea(Points));
        }
        private float SignedPolygonArea(List<Point> Points)
        {
            int num_points = Points.Count;
            List<Point> pts = new List<Point>(Points);
            pts[num_points] = Points[0];
            
            
            // Get the areas.
            float area = 0;
            for (int i = 0; i < num_points; i++)
            {
                area +=
                    (pts[i + 1].X - pts[i].X) *
                    (pts[i + 1].Y + pts[i].Y) / 2;
            }

            // Return the result.
            return area;
        }
    }
  }
