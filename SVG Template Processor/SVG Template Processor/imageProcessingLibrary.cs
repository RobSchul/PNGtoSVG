using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;


namespace SVG_Template_Processor
{
    class imageProcessingLibrary
    {
        public static Rectangle[] fileChange(String file)
        {
            
            Bitmap myBitmap = new Bitmap(file);
            Size ImageSize = myBitmap.Size;
            BitmapData bmData = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height), ImageLockMode.ReadOnly, myBitmap.PixelFormat);

            int pixelSize = 4;
            int startX = 0;
            int startY = 0;
            int stopX = startX + myBitmap.Width;
            int stopY = startY + myBitmap.Height;
            int offset = bmData.Stride - myBitmap.Width * pixelSize;
            List<Point> Points = new List<Point>();
            List<Rectangle> ret = new List<Rectangle>();
            unsafe
            {
                // do the job
                byte* ptr = (byte*)bmData.Scan0;

                // allign pointer to the first pixel to process
                ptr += (startY * bmData.Stride + startX);

                for (int y = startY; y < stopY; y++)
                {
                    for (int x = startX; x < stopX; x++)
                    {
                        // process each pixel
                        for (int p = 0; p < pixelSize; p++, ptr++)
                        {
                            switch (p)
                            {
                                case 3:
                                    if (*ptr == 0)
                                    {
                                        Points.Add(new Point(x, y));
                                    }
                                    break;
                            }
                        }
                    }
                    ptr += offset;
                }
            }
            myBitmap.UnlockBits(bmData);
            myBitmap.Dispose();
            myBitmap = null;
            while (Points.Count > 0)
            {
                Point Base = Points[0];
                Rectangle BaseR = new Rectangle(Base, new Size(1, 1));
                List<Point> RecPoints = (from P in Points where P.X == Base.X || P.Y == Base.Y select P).ToList();
                foreach (Point P in RecPoints)
                {
                    if (P.X == Base.X && P.Y == (BaseR.Y + BaseR.Height) + 1) BaseR.Height++;
                    if (P.Y == Base.Y && P.X == (BaseR.X + BaseR.Width) + 1) BaseR.Width++;
                }
                Points.RemoveAll(P => BaseR.Contains(P));
                if (BaseR.Width > 1 && BaseR.Height > 1) ret.Add(BaseR);
            }

            return ret.ToArray();
            
        }
        
        public static Bitmap Transparent2Color(Bitmap bmp1, Color target)
        {
            Bitmap bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
            Rectangle rect = new Rectangle(Point.Empty, bmp1.Size);
            using (Graphics G = Graphics.FromImage(bmp2))
            {
                G.Clear(target);
                
                G.DrawImageUnscaledAndClipped(bmp1, rect);
            }
            return bmp2;
        }

         static void Main()
        {
            
                try
                {   Rectangle[] rNew = new Rectangle[10];
                rNew = fileChange(@"\\chptfs\Shared\Intern Projects\SVG Template Creation\pngTemplatesApetureAreas\1141_2226x1047_11ozMug_4up_Misc_LoveNeverFailsLabel.png");
                }
            catch(Exception e)
                {

            }
            finally{
                    
                }

        }

    }
}
