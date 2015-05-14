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
        public Rectangle[] fileChange(String file)
        {

            Bitmap myBitmap = new Bitmap(file);
            BitmapData bmData = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height), ImageLockMode.ReadOnly, myBitmap.PixelFormat);
            List<Point> Points = findTPoints(myBitmap, bmData);
             return mapTpoints(Points);

        }

        private Rectangle[] mapTpoints(List<Point> Points)
        {
            List<Rectangle> ret = new List<Rectangle>();
            while (Points.Count > 0)
            {
                Point Base = Points[0];
                Rectangle BaseR = new Rectangle(Base, new Size(1, 1));
                List<Point> RecPoints = (from P in Points where P.X == Base.X || P.Y == Base.Y select P).ToList();
                foreach (Point P in RecPoints)
                {
                    if (P.X == Base.X && P.Y == (BaseR.Y + BaseR.Height) + 1)
                        BaseR.Height++;
                    if (P.Y == Base.Y && P.X == (BaseR.X + BaseR.Width) + 1)
                        BaseR.Width++;
                }
                Points.RemoveAll(P => BaseR.Contains(P));
                if (BaseR.Width > 1 && BaseR.Height > 1)
                    ret.Add(BaseR);
            }
            return ret.ToArray();
        }

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

            for (int y = startY; y < stopY; y++)
            {
                for (int x = startX; x < stopX; x++)
                {
                    for (int p = 0; p < pixelSize; p++, point++)
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
            myBitmap.UnlockBits(bmData);
            myBitmap.Dispose();
            myBitmap = null;
            return Points;

        }


        public Bitmap Transparent2Color(String file)
        {
            Image image = Image.FromFile(file);
            Bitmap myBitmap = new Bitmap(file);
            Color white = Color.Blue;
            Bitmap bmp2 = new Bitmap(myBitmap.Width, myBitmap.Height);
            Rectangle[] rect = fileChange(file);

            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            for (int i = 0; i < rect.Length; i++)
            {
                Rectangle r;
                r = rect[i];
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.Red);
                Graphics g = Graphics.FromImage(myBitmap);
                g.FillRectangle(myBrush, r);
                myBrush.Dispose();
                string text2 = "" + i;
                Font font2 = new Font("Arial", 40, FontStyle.Bold, GraphicsUnit.Point);


                TextFormatFlags flags = TextFormatFlags.WordBreak;
                TextRenderer.DrawText(g, text2, font2, r, Color.Blue, flags);
                g.Dispose();
            }

            /*for (int x = 0; x < myBitmap.Width; x++)
                for (int y = 0; y < myBitmap.Height; y++)
                {
                    c = myBitmap.GetPixel(x, y);
                    myBitmap.SetPixel(x, y, ((((short)(c.A)) & 0x00FF) <= 0) ? white : c); //replace 0 here with some higher tolerance if needed
                }
        */
            return myBitmap;

        }




    }
}
