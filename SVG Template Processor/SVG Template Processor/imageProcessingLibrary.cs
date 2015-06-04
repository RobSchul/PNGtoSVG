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
        ///  get all regions that are transparent and sent back an array of rectangles  
        ///  
        /// </summary>
        public Rectangle[] getTRegions()
        {
            BitmapData bmData = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height), ImageLockMode.ReadOnly, myBitmap.PixelFormat);
            List<Point> Points = findTPoints(myBitmap, bmData);
            Points = MakeConvexHull(Points);
            //return mapTpoints(Points); 
            return GetMinMaxBox(Points);
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
                Rectangle baseR = new Rectangle(pBase, new Size(1, 1)); //create rectangle with first point of transparancy and size of 1,1
                List<Point> RecPoints = new List<Point> { }; 

                foreach (Point P in points)
                {
                    if (P.X == baseR.X || P.Y == baseR.Y) // what is actually happeneing 
                        RecPoints.Add(P);
                }

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
                        {    case 3:
                                if (*point == 0)
                                    Points.Add(new Point(x, y));

                                break;
                        }
                    }
                point += offset;
            }

            myBitmap.UnlockBits(bmData);
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

                /*
                List<Rectangle> ret = new List<Rectangle>();
                while (points.Count > 0)
                {
                    Point pBase = points[0];
                    Rectangle baseR = new Rectangle(pBase, new Size(1, 1)); //create rectangle with first point of transparancy and size of 1,1

                    List<Point> RecPoints = new List<Point> { }; //(from P in points where P.X == baseR.X || P.Y == baseR.Y select P).ToList(); //list of points?

                    foreach(Point P in points)
                    {
                        if (P.X == baseR.X || P.Y == baseR.Y) // what is actually happeneing 
                            RecPoints.Add(P);
                    }
                    foreach (Point point in RecPoints)
                    {
                        if (point.X == pBase.X && point.Y == (baseR.Y + baseR.Height) + 1)
                            baseR.Height++;
                        if (point.Y == pBase.Y && point.X == (baseR.X + baseR.Width) + 1)
                            baseR.Width++;
                    }
                    points.RemoveAll(P => baseR.Contains(P));
                    if (baseR.Width > 1 && baseR.Height > 1)
                        ret.Add(baseR);
                
                }*/
            }

            // Find a box that fits inside the MinMax quadrilateral.
            private static Rectangle[] GetMinMaxBox(List<Point> points)
            {
                // Find the MinMax quadrilateral.
                Point lowerMost = new Point(0, 0),  leftMost = lowerMost, rightMost = lowerMost, upperMost = lowerMost;
                GetMinMaxCorners(points,ref upperMost , ref lowerMost, ref leftMost, ref rightMost);


                Rectangle[] result = new Rectangle[] { new Rectangle(leftMost.X, upperMost.Y, rightMost.X - leftMost.X, lowerMost.Y - upperMost.Y) };
                return result;
            }

            // Cull points out of the convex hull that lie inside the
            // trapezoid defined by the vertices with smallest and
            // largest X and Y coordinates.
            // Return the points that are not culled.
            private static List<Point> HullCull(List<Point> points)
            {
                // Find a culling box.
                Rectangle[] culling_box = GetMinMaxBox(points);

                // Cull the points.
                List<Point> results = new List<Point>();
                foreach (Point point in points)
                {
                    // See if (this point lies outside of the culling box.
                    if (point.X <= culling_box[0].Left ||
                        point.X >= culling_box[0].Right ||
                        point.Y <= culling_box[0].Top ||
                        point.Y >= culling_box[0].Bottom)
                    {
                        // This point cannot be culled.
                        // Add it to the results.
                        results.Add(point);
                    }
                }
                return results;
            }

            // Return the points that make up a polygon's convex hull.
            // This method leaves the points list unchanged.
            public static List<Point> MakeConvexHull(List<Point> points)
            {
                // Cull.
                points = HullCull(points);

                // Find the remaining point with the smallest Y value.
                // if (there's a tie, take the one with the smaller X value.
                Point bestPoint = points[0];
                foreach (Point point in points)
                {
                    if ((point.Y < bestPoint.Y) ||
                       ((point.Y == bestPoint.Y) && (point.X < bestPoint.X)))
                    {
                        bestPoint = point;
                    }
                }

                // Move this point to the convex hull.
                List<Point> hull = new List<Point>();
                hull.Add(bestPoint);
                points.Remove(bestPoint);

                // Start wrapping up the other points.
                float sweep_angle = 0;
                for (;;)
                {   // Find the point with smallest AngleValue
                    // from the last point.
                    int X = hull[hull.Count - 1].X;
                    int Y = hull[hull.Count - 1].Y;
                    bestPoint = points[0];
                    float best_angle = 3600;

                    // Search the rest of the points.
                    foreach (Point pt in points)
                    {
                        float test_angle = AngleValue(X, Y, pt.X, pt.Y);
                        if ((test_angle >= sweep_angle) &&
                            (best_angle > test_angle))
                        {
                            best_angle = test_angle;
                            bestPoint = pt;
                        }
                    }

                    // See if the first point is better.
                    // If so, we are done.
                    float first_angle = AngleValue(X, Y, hull[0].X, hull[0].Y);
                    if ((first_angle >= sweep_angle) &&
                        (best_angle >= first_angle))
                    {
                        // The first point is better. We're done.
                        break;
                    }

                    // Add the best point to the convex hull.
                    hull.Add(bestPoint);
                    points.Remove(bestPoint);

                    sweep_angle = best_angle;

                    // If all of the points are on the hull, we're done.
                    if (points.Count == 0) break;
                }

                return hull;
            }

            // Return a number that gives the ordering of angles
            // WRST horizontal from the point (x1, y1) to (x2, y2).
            // In other words, AngleValue(x1, y1, x2, y2) is not
            // the angle, but if:
            //   Angle(x1, y1, x2, y2) > Angle(x1, y1, x2, y2)
            // then
            //   AngleValue(x1, y1, x2, y2) > AngleValue(x1, y1, x2, y2)
            // this angle is greater than the angle for another set
            // of points,) this number for
            //
            // This function is dy / (dy + dx).
            private static float AngleValue(int x1, int y1, int x2, int y2)
            {
                float dx, dy, ax, ay, t;

                dx = x2 - x1;
                ax = Math.Abs(dx);
                dy = y2 - y1;
                ay = Math.Abs(dy);
                if (ax + ay == 0)
                {
                    // if (the two points are the same, return 360.
                    t = 360f / 9f;
                }
                else
                {
                    t = dy / (ax + ay);
                }
                if (dx < 0)
                {
                    t = 2 - t;
                }
                else if (dy < 0)
                {
                    t = 4 + t;
                }
                return t * 90;
            }

            public Bitmap MyBitmap
            {
                get { return myBitmap; }
                set { myBitmap = value; }
            }
    }
}