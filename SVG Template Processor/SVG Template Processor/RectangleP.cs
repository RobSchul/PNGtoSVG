

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
/// <summary>
/// Creates and new Instance of the RectanglePF Class
/// Provides a Rotatable Rectangle 
/// </summary>
public class RectanglePF
{
    private float _Angle = 0;
    private RectangleF _Rectangle = new RectangleF(0, 0, 0, 0);
    /// <summary>
    /// Gets or Sets the X coordinate
    /// </summary>
    public float X
    {
        get
        {
            return _Rectangle.X;
        }
        set
        {
            _Rectangle.X = value;
        }
    }
    /// <summary>
    /// Gets or Sets the Y coordinate
    /// </summary>
    public float Y
    {
        get
        {
            return _Rectangle.Y;
        }
        set
        {
            _Rectangle.Y = value;
        }
    }
    /// <summary>
    /// Gets or Sets the Width
    /// </summary>
    public float Width
    {
        get
        {
            return _Rectangle.Width;
        }
        set
        {
            _Rectangle.Width = value;
        }
    }
    /// <summary>
    /// Gets or Sets the Height
    /// </summary>
    public float Height
    {
        get
        {
            return _Rectangle.Height;
        }
        set
        {
            _Rectangle.Height = value;
        }
    }
    /// <summary>
    /// Gets or Sets the Location
    /// </summary>
    public PointF Location
    {
        get
        {
            return _Rectangle.Location;
        }
        set
        {
            _Rectangle.Location = value;
        }
    }
    /// <summary>
    /// Gets or Sets the Rectangle Size
    /// </summary>
    public SizeF Size
    {
        get
        {
            return _Rectangle.Size;
        }
        set
        {
            _Rectangle.Size = value;
        }
    }
    /// <summary>
    /// Gets weather the Rectangle Contains any Space
    /// </summary>
    public bool IsEmpty
    {
        get
        {
            return _Rectangle.Width == 0 || _Rectangle.Height == 0;
        }
    }
    /// <summary>
    /// Gets left most value of the rectangle
    /// </summary>
    public float Left
    {
        get
        {
            float ret = _Rectangle.X;
            PointF[] _Points = Points;
            foreach (PointF Point in _Points)
            {
                if (Point.X < ret) ret = Point.X;
            }
            return ret;
        }
    }
    /// <summary>
    /// Gets the right-most value of the rectangle
    /// </summary>
    public float Right
    {
        get
        {
            float ret = _Rectangle.X;
            PointF[] _Points = Points;
            foreach (PointF Point in _Points)
            {
                if (Point.X > ret) ret = Point.X;
            }
            return ret;
        }
    }
    /// <summary>
    /// Gets the top most value of the rectangle
    /// </summary>
    public float Top
    {
        get
        {
            float ret = _Rectangle.Y;
            PointF[] _Points = Points;
            foreach (PointF Point in _Points)
            {
                if (Point.Y < ret) ret = Point.Y;
            }
            return ret;
        }
    }
    /// <summary>
    /// Gets the bottom most value of the rectangle
    /// </summary>
    public float Bottom
    {
        get
        {
            float ret = _Rectangle.Y;
            PointF[] _Points = Points;
            foreach (PointF Point in _Points)
            {
                if (Point.Y > ret) ret = Point.Y;
            }
            return ret;
        }
    }
    /// <summary>
    /// Inflates the rectangle by the givent size
    /// </summary>
    /// <param name="Width">Value to increase the widht by</param>
    /// <param name="Height">value to increase the height by</param>
    public void Inflate(float Width, float Height)
    {
        this.Inflate(new SizeF(Width, Height));
    }
    /// <summary>
    /// Inflates the rectangle by the given size
    /// </summary>
    /// <param name="size">Size to increase the rectangle by</param>
    public void Inflate(SizeF size)
    {
        _Rectangle.Inflate(size);
    }
    /// <summary>
    /// Gets the 4 points of the rectangle, adjusted for rotation
    /// </summary>
    public PointF[] Points
    {
        get
        {
            Matrix mx = new Matrix();
            PointF[] Points = GetPRect(_Rectangle);
            mx.RotateAt(_Angle, _Rectangle.Location);
            mx.TransformPoints(Points);
            return Points;
        }
        set
        {
            if (value.Length != 4) return;
            SetPoints(value[0], value[1], value[2], value[3]);
        }
    }
    /// <summary>
    /// GetImagePoints
    /// Returns an array of points adjusted for rotation, that are fit to draw an Image to using Graphics.DrawImage
    /// </summary>
    /// <returns>Array of Points</returns>
    public PointF[] GetImagePoints()
    {
        PointF[] points = Points;
        return new PointF[] { points[0], points[1], points[2] };
    }
    /// <summary>
    /// GetPolygonPoints
    /// Returns an Array of points adjusted for rotation, that are fit to draw a polygon using Graphics.DrawPolygon
    /// </summary>
    /// <returns>Array of Points</returns>
    public PointF[] GetPolygonPoints()
    {
        PointF[] points = Points;
        return new PointF[] { points[0], points[1], points[3], points[2] };
    }
    /// <summary>
    /// Returns weather the Rectangle Contains the given Location, Even for rotated Points
    /// </summary>
    /// <param name="Location">Location to Check</param>
    /// <param name="Delta">Allows the point to be outside the rectangle by this Delta</param>
    /// <returns>Weather the Retangle Contains the Point</returns>
    public bool Contains(PointF Location, int Delta)
    {
        Location = new PointF(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        PointF[] Points = new PointF[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return _Rectangle.Contains(Location) || OnSide(Location, Delta); ;
    }
    /// <summary>
    /// Returns weathr the given point is on a Side of the rectangle
    /// </summary>
    /// <param name="Location">The Location to Check</param>
    /// <param name="Delta">Allows the point to be outside the rectangle by this Delta</param>
    /// <returns>Weather the Point is On a Side</returns>
    public bool OnSide(PointF Location, int Delta)
    {
        return OnTopSide(Location, Delta) || OnBottomSide(Location, Delta) || OnLeftSide(Location, Delta) || OnRightSide(Location, Delta);
    }
    /// <summary>
    /// Returns weather the Rectangle Contains the given Location, Even for rotated Points
    /// </summary>
    /// <param name="x">Point X Corrdinate</param>
    /// <param name="y">Point Y Corrdinate</param>
    /// <returns>Weather the Point is in the Rectangle</returns>
    public bool Contains(float x, float y)
    {
        return Contains(new PointF(x, y));
    }
    /// <summary>
    /// Returns weather the Rectangle Contains the given Location, Even for rotated Points
    /// </summary>
    /// <param name="Location">Location to Check</param>
    public bool Contains(PointF Location)
    {
        Location = new PointF(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        PointF[] Points = new PointF[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return _Rectangle.Contains(Location);
    }
    /// <summary>
    /// Returns weather the Rectangle Contains entire Given Rectangle, Even for rotated Points
    /// </summary>
    /// <param name="Rectangle">Area to Check</param>
    public bool Contains(RectangleF Rectangle)
    {
        bool ret = true;
        PointF[] points = GetPRect(Rectangle);
        foreach (PointF point in points)
        {
            ret = ret && Contains(point);
        }
        return ret;
    }
    /// <summary>
    /// Returns weather the Rectangle Contains entire Given Rectangle, Even for rotated Points
    /// </summary>
    /// <param name="Rectangle">Area to Check</param>
    public bool Contains(RectanglePF Rectangle)
    {
        bool ret = true;
        PointF[] points = Rectangle.Points;
        foreach (PointF point in points)
        {
            ret = ret && Contains(point);
        }
        return ret;
    }
    /// <summary>
    /// Moves the entire rectangle by this Point Value
    /// </summary>
    /// <param name="x">X offset</param>
    /// <param name="y">Y Offset</param>
    public void Offset(float x, float y)
    {
        _Rectangle.Offset(x, y);
    }
    /// <summary>
    /// Moves the entire rectangle by this Point Value
    /// </summary>
    /// <param name="pos">Point to adjust the rectangle By</param>
    public void Offset(PointF pos)
    {
        _Rectangle.Offset(pos);
    }
    private static PointF[] GetPRect(RectangleF _Rectangle)
    {
        return new PointF[] { _Rectangle.Location, new PointF(_Rectangle.Right, _Rectangle.Top), new PointF(_Rectangle.Left, _Rectangle.Bottom), new PointF(_Rectangle.Right, _Rectangle.Bottom) };
    }
    /// <summary>
    /// Gets or Sets the Rotation angle from the upper left hand corner
    /// </summary>
    public float Angle
    {
        get
        {
            return _Angle;
        }
        set
        {
            _Angle = value;

        }
    }
    /// <summary>
    /// Gets the Un-Rotated Rectangle
    /// </summary>
    public RectangleF Rectangle
    {
        get
        {
            return _Rectangle;
        }
    }
    /// <summary>
    /// Creates a new RectanglePF 
    /// </summary>
    public RectanglePF()
    {

    }
    /// <summary>
    /// Copyies the current givien RectanglPF
    /// </summary>
    /// <param name="Rectangle"></param>
    public RectanglePF(RectanglePF Rectangle)
        : this(Rectangle.Rectangle, Rectangle.Angle)
    {
    }
    /// <summary>
    /// Creates a new RectanglePF 
    /// </summary>
    ///<param name="Rectangle">Original Rectangle</param>
    public RectanglePF(RectangleF Rectangle)
        : this(Rectangle.Location, Rectangle.Size)
    {
    }
    /// <summary>
    /// Creates a new RectanglePF
    /// </summary>
    ///<param name="Rectangle">Original Rectangle</param>
    ///<param name="Angle">Angle to Rotate from Location</param>
    public RectanglePF(RectangleF Rectangle, float Angle)
        : this(Rectangle.Location, Rectangle.Size, Angle)
    {
    }
    /// <summary>
    /// Creates a new RectanglePF 
    /// </summary>
    /// <param name="Location">X,Y Location</param>
    /// <param name="Size">Rectangle Size</param>
    public RectanglePF(PointF Location, SizeF Size)
    {
        _Rectangle = new RectangleF(Location, Size);
    }
    /// <summary>
    /// Creates a new RectanglePF 
    /// </summary>
    /// <param name="Location">X,Y Location</param>
    /// <param name="Size">Rectangle Size</param>
    /// <param name="Angle">Angle to rotate from Location</param>
    public RectanglePF(PointF Location, SizeF Size, float Angle)
    {
        _Rectangle = new RectangleF(Location, Size);
        _Angle = Angle;
    }
    /// <summary>
    /// Creates a new RectanglePF
    /// </summary>
    /// <param name="x">Location X Co-ordinate</param>
    /// <param name="y">Location Y co-ordinate</param>
    /// <param name="width">Rectangle Width</param>
    /// <param name="height">Rectangle Height</param>
    public RectanglePF(float x, float y, float width, float height)
    {
        _Rectangle = new RectangleF(x, y, width, height);

    }
    /// <summary>
    /// Creates a new RectanglePF
    /// </summary>
    /// <param name="x">Location X Co-ordinate</param>
    /// <param name="y">Location Y co-ordinate</param>
    /// <param name="width">Rectangle Width</param>
    /// <param name="height">Rectangle Height</param>
    /// <param name="angle">Rectangle Angle</param>
    public RectanglePF(float x, float y, float width, float height, float angle)
    {
        _Rectangle = new RectangleF(x, y, width, height);
        _Angle = angle;
    }
    /// <summary>
    /// Builds the Point Rectangle out of the following four Points
    /// </summary>
    /// <param name="P1">Upper Left Corner</param>
    /// <param name="P2">Upper Right Corner</param>
    /// <param name="P3">Lower Left Corner</param>
    /// <param name="P4">Lower Right Corner.</param>
    public RectanglePF(PointF P1, PointF P2, PointF P3, PointF P4)
    {
        SetPoints(P1, P2, P3, P4);
    }
    private void SetPoints(PointF P1, PointF P2, PointF P3, PointF P4)
    {
        double w2 = Math.Sqrt(((P2.Y - P1.Y) * (P2.Y - P1.Y)) + ((P2.X - P1.X) * (P2.X - P1.X)));
        double h2 = Math.Sqrt(((P3.Y - P1.Y) * (P3.Y - P1.Y)) + ((P3.X - P1.X) * (P3.X - P1.X)));
        _Rectangle = new RectangleF(P1, new SizeF((float)Math.Abs(w2), (float)Math.Abs(h2)));
        double w = (w2 - (P2.X - _Rectangle.Right));
        double h = (P2.Y - _Rectangle.Top);
        _Angle = (float)(Math.Atan(h / w) * 57.2957795130823);
    }

    internal bool OnRightSide(PointF Location, int delta)
    {
        Location = new PointF(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        PointF[] Points = new PointF[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return (Math.Abs((decimal)(Location.X - _Rectangle.Right)) < (delta / 2)) && (Location.Y > (_Rectangle.Top - delta) && Location.Y < (_Rectangle.Bottom + delta));
    }

    internal bool OnLeftSide(PointF Location, int delta)
    {
        Location = new PointF(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        PointF[] Points = new PointF[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return (Math.Abs((decimal)(Location.X - _Rectangle.Left)) < (delta / 2)) && (Location.Y > (_Rectangle.Top - delta) && Location.Y < (_Rectangle.Bottom + delta));
    }

    internal bool OnTopSide(PointF Location, int delta)
    {
        Location = new PointF(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        PointF[] Points = new PointF[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return (Math.Abs((decimal)(Location.Y - _Rectangle.Top)) < (delta / 2)) && (Location.X > (_Rectangle.Left - delta) && Location.X < (_Rectangle.Right + delta));
    }

    internal bool OnBottomSide(PointF Location, int delta)
    {
        Location = new PointF(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        PointF[] Points = new PointF[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return (Math.Abs((decimal)(Location.Y - _Rectangle.Bottom)) < (delta / 2)) && (Location.X > (_Rectangle.Left - delta) && Location.X < (_Rectangle.Right + delta));
    }
}
/// <summary>
/// an Integer Based Rectangle with Rotation
/// </summary>
public class RectangleP
{
    private float _Angle = 0;
    private Rectangle _Rectangle = new Rectangle(0, 0, 0, 0);
    /// <summary>
    /// gets or sets the X coordinate of the rectangle
    /// </summary>
    public int X
    {
        get
        {
            return _Rectangle.X;
        }
        set
        {
            _Rectangle.X = value;
        }
    }
    /// <summary>
    /// Gets or sets the Y coordinate of the rectangle
    /// </summary>
    public int Y
    {
        get
        {
            return _Rectangle.Y;
        }
        set
        {
            _Rectangle.Y = value;
        }
    }
    /// <summary>
    /// Gets or sets the Width of the rectangle
    /// </summary>
    public int Width
    {
        get
        {
            return _Rectangle.Width;
        }
        set
        {
            _Rectangle.Width = value;
        }
    }
    /// <summary>
    /// gets or sets the Height of the rectangle
    /// </summary>
    public int Height
    {
        get
        {
            return _Rectangle.Height;
        }
        set
        {
            _Rectangle.Height = value;
        }
    }
    /// <summary>
    /// Gets or sets the Location  of the rectangle
    /// </summary>
    public Point Location
    {
        get
        {
            return _Rectangle.Location;
        }
        set
        {
            _Rectangle.Location = value;
        }
    }
    /// <summary>
    /// Gets or sets the Size of the rectangle
    /// </summary>
    public Size Size
    {
        get
        {
            return _Rectangle.Size;
        }
        set
        {
            _Rectangle.Size = value;
        }
    }
    /// <summary>
    /// Gets weather the rectangle has area
    /// </summary>
    public bool IsEmpty
    {
        get
        {
            return _Rectangle.Width == 0 || _Rectangle.Height == 0;
        }
    }
    /// <summary>
    /// gets the left most value of the rectangle
    /// </summary>
    public int Left
    {
        get
        {
            int ret = _Rectangle.X;
            Point[] _Points = Points;
            foreach (Point Point in _Points)
            {
                if (Point.X < ret) ret = Point.X;
            }
            return ret;
        }
    }
    /// <summary>
    /// gets the right most value of the rectangle
    /// </summary>
    public int Right
    {
        get
        {
            int ret = _Rectangle.X;
            Point[] _Points = Points;
            foreach (Point Point in _Points)
            {
                if (Point.X > ret) ret = Point.X;
            }
            return ret;
        }
    }
    /// <summary>
    /// Gets the Top most value of the rectangle
    /// </summary>
    public int Top
    {
        get
        {
            int ret = _Rectangle.Y;
            Point[] _Points = Points;
            foreach (Point Point in _Points)
            {
                if (Point.Y < ret) ret = Point.Y;
            }
            return ret;
        }
    }
    /// <summary>
    /// Gets the bottom most Value of the rectangle
    /// </summary>
    public int Bottom
    {
        get
        {
            int ret = _Rectangle.Y;
            Point[] _Points = Points;
            foreach (Point Point in _Points)
            {
                if (Point.Y > ret) ret = Point.Y;
            }
            return ret;
        }
    }
    /// <summary>
    /// Gets or Sets The Points of the rotated rectangle
    /// </summary>
    public Point[] Points
    {
        get
        {
            Matrix mx = new Matrix();
            Point[] Points = GetPRect(_Rectangle);
            mx.RotateAt(_Angle, _Rectangle.Location);
            mx.TransformPoints(Points);
            return Points;
        }
        set
        {
            if (value.Length != 4) return;
            SetPoints(value[0], value[1], value[2], value[3]);
        }
    }
    /// <summary>
    /// Inflates the rectangle by the given size
    /// </summary>
    /// <param name="Width">Width delta</param>
    /// <param name="Height">Heigh delta</param>
    public void Inflate(int Width, int Height)
    {
        this.Inflate(new Size(Width, Height));
    }
    /// <summary>
    /// Inflates the rectangle by the given size
    /// </summary>
    /// <param name="size">Size delta</param>
    public void Inflate(Size size)
    {
        _Rectangle.Inflate(size);
    }
    /// <summary>
    /// Gets an array of points suitable for drawing a Image with Graphic.DrawImage
    /// </summary>
    /// <returns>Array of Points</returns>
    public Point[] GetImagePoints()
    {
        Point[] points = Points;
        return new Point[] { points[0], points[1], points[2] };
    }
    /// <summary>
    /// Gets an array of points suitable for drawing a Polygon with Graphic.DrawPolygon
    /// </summary>
    /// <returns>Array of Points</returns>
    public Point[] GetPolygonPoints()
    {
        Point[] points = Points;
        return new Point[] { points[0], points[1], points[3], points[2] };
    }
    /// <summary>
    /// Returns weather the Rectangle contains the given Location 
    /// </summary>
    /// <param name="x">X corrdinate</param>
    /// <param name="y">Y Corrdinate</param>
    /// <returns></returns>
    public bool Contains(int x, int y)
    {
        return Contains(new Point(x, y));
    }
    /// <summary>
    /// Returns weather the Rectangle contains the given Location 
    /// </summary>
    /// <param name="Location">Point to check</param>
    /// <returns>weather the Rectangle contains the given Location</returns>
    public bool Contains(Point Location, Boolean tru)
    {
        Location = new Point(Location.X, Location.Y);

        return _Rectangle.Contains(Location);
    }
    /// <summary>
    /// Returns weather the Rectangle contains the given Location 
    /// </summary>
    /// <param name="Location">Point to check</param>
    /// <returns>weather the Rectangle contains the given Location</returns>
    public bool Contains(Point Location)
    {
        Location = new Point(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        Point[] Points = new Point[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return _Rectangle.Contains(Location);
    }
    /// <summary>
    /// Returns weather the Rectangle contains the given area
    /// </summary>
    /// <param name="Rectangle">Area to check</param>
    /// <returns>weather the Rectangle contains the given area</returns>
    public bool Contains(Rectangle Rectangle)
    {
        bool ret = true;
        Point[] points = GetPRect(Rectangle);
        foreach (Point point in points)
        {
            ret = ret && Contains(point);
        }
        return ret;
    }
    /// <summary>
    /// Returns weather the Rectangle contains the given area
    /// </summary>
    /// <param name="Rectangle">Area to check</param>
    /// <returns>weather the Rectangle contains the given area</returns>
    public bool Contains(RectangleP Rectangle)
    {
        bool ret = true;
        Point[] points = Rectangle.Points;
        foreach (Point point in points)
        {
            ret = ret && Contains(point);
        }
        return ret;
    }
    /// <summary>
    /// Offset the Rectangle by the given value
    /// </summary>
    /// <param name="x">X Offset</param>
    /// <param name="y">Y Offset</param>
    public void Offset(int x, int y)
    {
        _Rectangle.Offset(x, y);
    }
    /// <summary>
    /// Offset the Rectangle by the given value
    /// </summary>
    /// <param name="pos">Point object containing the offseting X and Y coordinates</param>
    public void Offset(Point pos)
    {
        _Rectangle.Offset(pos);
    }
    private static Point[] GetPRect(Rectangle _Rectangle)
    {
        return new Point[] { _Rectangle.Location, new Point(_Rectangle.Right, _Rectangle.Top), new Point(_Rectangle.Left, _Rectangle.Bottom), new Point(_Rectangle.Right, _Rectangle.Bottom) };
    }
    /// <summary>
    /// gets or sets the Rotation Angle relative to the Upper Right hand conder
    /// </summary>
    public float Angle
    {
        get
        {
            return _Angle;
        }
        set
        {
            _Angle = value;

        }
    }
    /// <summary>
    /// Gets the Un-Rotated Rectangle
    /// </summary>
    public Rectangle Rectangle
    {
        get
        {
            return _Rectangle;
        }
    }
    /// <summary>
    /// Creates a new RectangleP
    /// </summary>
    public RectangleP()
    {

    }
    /// <summary>
    /// Creates a new RectangleP 
    /// </summary>
    ///<param name="Rectangle">Original Rectangle</param>
    public RectangleP(Rectangle Rectangle)
        : this(Rectangle.Location, Rectangle.Size)
    {
    }
    /// <summary>
    /// Creates a new RectangleP 
    /// </summary>
    ///<param name="Rectangle">Original Rectangle</param>
    ///<param name="Angle">Angle to Rotate from Location</param>
    public RectangleP(Rectangle Rectangle, float Angle)
        : this(Rectangle.Location, Rectangle.Size, Angle)
    {
    }
    /// <summary>
    /// Creates a new RectangleP 
    /// </summary>
    /// <param name="Location">X,Y Location</param>
    /// <param name="Size">Rectangle Size</param>
    public RectangleP(Point Location, Size Size)
    {
        _Rectangle = new Rectangle(Location, Size);
    }
    /// <summary>
    /// Creates a new RectangleP 
    /// </summary>
    /// <param name="Location">X,Y Location</param>
    /// <param name="Size">Rectangle Size</param>
    /// <param name="Angle">Angle to rotate from Location</param>
    public RectangleP(Point Location, Size Size, float Angle)
    {
        _Rectangle = new Rectangle(Location, Size);
        _Angle = Angle;
    }
    /// <summary>
    /// Creates a new RectangleP
    /// </summary>
    /// <param name="x">Location X Co-ordinate</param>
    /// <param name="y">Location Y co-ordinate</param>
    /// <param name="width">Rectangle Width</param>
    /// <param name="height">Rectangle Height</param>
    public RectangleP(int x, int y, int width, int height)
    {
        _Rectangle = new Rectangle(x, y, width, height);

    }
    /// <summary>
    /// Creates a new RectangleP
    /// </summary>
    /// <param name="x">Location X Co-ordinate</param>
    /// <param name="y">Location Y co-ordinate</param>
    /// <param name="width">Rectangle Width</param>
    /// <param name="height">Rectangle Height</param>
    /// <param name="angle">Rectangle Angle</param>
    public RectangleP(int x, int y, int width, int height, float angle)
    {
        _Rectangle = new Rectangle(x, y, width, height);
        _Angle = angle;
    }
    /// <summary>
    /// Builds the Point Rectangle out of the following four Points
    /// </summary>
    /// <param name="P1">Upper Left Corner</param>
    /// <param name="P2">Upper Right Corner</param>
    /// <param name="P3">Lower Left Corner</param>
    /// <param name="P4">Lower Right Corner.</param>
    public RectangleP(Point P1, Point P2, Point P3, Point P4)
    {
        SetPoints(P1, P2, P3, P4);
    }
    private void SetPoints(Point P1, Point P2, Point P3, Point P4)
    {
        double w2 = Math.Sqrt((((double)P2.Y - (double)P1.Y) * ((double)P2.Y - (double)P1.Y)) + (((double)P2.X - (double)P1.X) * ((double)P2.X - (double)P1.X)));
        double h2 = Math.Sqrt((((double)P3.Y - (double)P1.Y) * ((double)P3.Y - (double)P1.Y)) + (((double)P3.X - (double)P1.X) * ((double)P3.X - (double)P1.X)));
        _Rectangle = new Rectangle(P1, new Size((int)w2, (int)h2));
        double w = (w2 - ((double)P2.X - (double)_Rectangle.Right));
        double h = ((double)P2.Y - (double)_Rectangle.Top);
        _Angle = (float)(Math.Atan(h / w) * 57.2957795130823);
    }
    internal bool OnRightSide(Point Location, int delta)
    {
        Location = new Point(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        Point[] Points = new Point[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return (Math.Abs((decimal)(Location.X - _Rectangle.Right)) < (delta / 2)) && (Location.Y > (_Rectangle.Top - delta) && Location.Y < (_Rectangle.Bottom + delta));
    }

    internal bool OnLeftSide(Point Location, int delta)
    {
        Location = new Point(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        Point[] Points = new Point[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return (Math.Abs((decimal)(Location.X - _Rectangle.Left)) < (delta / 2)) && (Location.Y > (_Rectangle.Top - delta) && Location.Y < (_Rectangle.Bottom + delta));
    }

    internal bool OnTopSide(Point Location, int delta)
    {
        Location = new Point(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        Point[] Points = new Point[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return (Math.Abs((decimal)(Location.Y - _Rectangle.Top)) < (delta / 2)) && (Location.X > (_Rectangle.Left - delta) && Location.X < (_Rectangle.Right + delta));
    }

    internal bool OnBottomSide(Point Location, int delta)
    {
        Location = new Point(Location.X, Location.Y);
        Matrix mx = new Matrix();
        mx.RotateAt(-_Angle, _Rectangle.Location);
        Point[] Points = new Point[] { Location };
        mx.TransformPoints(Points);
        Location = Points[0];
        return (Math.Abs((decimal)(Location.Y - _Rectangle.Bottom)) < (delta / 2)) && (Location.X > (_Rectangle.Left - delta) && Location.X < (_Rectangle.Right + delta));
    }


}