private static List<Point> HullCull(List<Point> points)
            {   
                Rectangle[] culling_box = GetMinMaxBox(points);
                List<Point> results = new List<Point>();
                foreach (Point point in points)
                {
                    // See if (this point lies outside of the culling box.
                    if (point.X <= culling_box[0].Left ||
                        point.X >= culling_box[0].Right ||
                        point.Y <= culling_box[0].Top ||
                        point.Y >= culling_box[0].Bottom)
                    {
                        results.Add(point);  // Add point to the results.
                    }
                }
                return results;
            }//56464


public static List<Point> MakeConvexHull(List<Point> points)
            {   points = HullCull(points);

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

                 List<Point> hull = new List<Point>();
                hull.Add(bestPoint); // add point
                points.Remove(bestPoint);

                // Start wrapping up the other points.
                float sweep_angle = 0;
                for (;;)
                {   // Find the point with smallest AngleValue
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
                    if ((first_angle >= sweep_angle)&&(best_angle >= first_angle)) break;
                   
                    // Add the best point 
                    hull.Add(bestPoint);
                    points.Remove(bestPoint);

                    sweep_angle = best_angle;

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







Point pBase = points[0];
                RectanglePF baseR = new RectanglePF(pBase, new Size(1, 1)); //create rectangle with first point of transparancy and size of 1,1
                List<Point> RecPoints = new List<Point> { };

                Point upperMostPoint = points[0], lowerMostPoint = upperMostPoint, leftMost = lowerMostPoint, rightMost = lowerMostPoint;

                foreach (Point P in points)
                {
                    if (P.X == baseR.X || P.Y == baseR.Y) 
                        RecPoints.Add(P);
                }

                foreach (Point point in RecPoints)
                {
                    if (point.Y == pBase.Y && point.X == (baseR.X + baseR.Width) + 1)
                    {
                        baseR.Width++;
                       
                    }
                    if (point.X == pBase.X && point.Y == (baseR.Y + baseR.Height) + 1) 
                    {
                        baseR.Height++;
                       
                    }
                    
                }
                

                
                points.RemoveAll(P => baseR.Contains(P));// problem in this area
                if (baseR.Width > 1 && baseR.Height > 1)
                    ret.Add(baseR);

            }
            return ret.ToArray();
