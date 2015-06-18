using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SVG
{
    internal class ContiguousPointList : IList<Point>
    {
        List<Point> _List = new List<Point>();

        public bool Irregular
        {
            get
            {
                double Left = GetDistanceBetweenPoints(TopLeft, BottomLeft);
                double Right = GetDistanceBetweenPoints(TopRight, BottomRight);
                double Top = GetDistanceBetweenPoints(TopLeft, TopRight);
                double Bottom = GetDistanceBetweenPoints(BottomLeft, BottomRight);
                double Cross1 =GetDistanceBetweenPoints(TopLeft,BottomRight);
                double Cross2 = GetDistanceBetweenPoints(BottomLeft,TopRight);
                return !((Math.Abs(Top-Bottom)/((Top + Bottom)/2)*100) < _Variance &&
                     (Math.Abs(Left - Right) / ((Left + Right) / 2) * 100) < _Variance &&
                     (Math.Abs(Cross1 - Cross2)/((Cross1 + Cross1)/2)*100) < _Variance);
                    

            }
        }
        public Point Location
        {
            get { return new Point(_Left, _Top); }
        }
        public Size RecSize
        {
            get
            {
                return new Size(_Right - _Left, _Bottom - _Top);
            }
        }
        public static double GetDistanceBetweenPoints(Point p, Point q)
        {
            double a = p.X - q.X;
            double b = p.Y - q.Y;
            double distance = Math.Sqrt(a * a + b * b);
            return distance;
        }
        private int _Variance = 1;
        public int Variance { get { return _Variance; } set { _Variance = value; } }
        public bool Touches(Point P)
        {
            try
            {
                return ((P.Y >= _Top-_Variance && P.Y <= _Bottom+_Variance) && (Math.Abs(P.X - _Left) < Variance || Math.Abs(P.X - _Right) < Variance))
                    || ((P.X >= _Left-_Variance && P.X <= _Right+_Variance) && (Math.Abs(P.Y - _Top) < Variance || Math.Abs(P.Y - _Bottom) < Variance))
                    || ((P.Y >= _Top && P.Y <= _Bottom) && (P.X >= _Left && P.X <= _Right))
                    || ((Math.Abs(P.X - _Left) < Variance || Math.Abs(P.X - _Right) < Variance) && (Math.Abs(P.Y - _Top) < Variance || Math.Abs(P.Y - _Bottom) < Variance));
            }
            catch
            {
                return false;
            }
        }
        private Point ITopRight
        {
            get
            {
                if (Left.Y > Right.Y && Math.Abs(Left.Y - Right.Y) > Variance * 2)
                {
                    return Right;
                }
                else if (Math.Abs(Left.Y - Right.Y) <= Variance)// No Rotation
                {
                    return new Point(_Right, _Top);
                }
                else if (!Top.Equals(Left))
                {
                    return Top;
                }
                else
                {
                    return new Point(_Right, _Top);
                }
            }
        }
        private Point ITopLeft
        {
            get
            {
                if (Left.Y > Right.Y && Math.Abs(Left.Y - Right.Y) > Variance * 2)
                {
                    return Top;
                }
                else if (Math.Abs(Left.Y - Right.Y) <= Variance)// No Rotation
                {
                    return new Point(_Left, _Top);
                }
                else if (!Top.Equals(Right))
                {
                    return Left;
                }
                else
                {
                    return new Point(_Left, _Top);
                }

            }
        }
        private Point IBottomRight
        {
            get
            {

                if (Left.Y > Right.Y && Math.Abs(Left.Y - Right.Y) > Variance * 2)
                {
                    return Bottom;
                }
                else if (Math.Abs(Left.Y - Right.Y) <= Variance)// No Rotation
                {
                    return new Point(_Right, _Bottom);
                }
                else if (!Bottom.Equals(Left) && TopLeft.Y != TopRight.Y)
                {
                    return Right;
                }
                else
                {
                    return new Point(_Right, _Bottom);
                }
            }
        }
        private Point IBottomLeft
        {
            get
            {

                if (Left.Y > Right.Y && Math.Abs(Left.Y - Right.Y) > Variance * 2)
                {
                    return Left;
                }
                else if (Math.Abs(Left.Y - Right.Y) <= Variance)// No Rotation
                {
                    return new Point(_Left, _Bottom);
                }
                else if (!Bottom.Equals(Right) && TopLeft.Y != TopRight.Y)
                {
                    return Bottom;
                }
                else
                {
                    return new Point(_Left, _Bottom);
                }
            }
        }
        public Point TopRight
        {
            get
            {
                if (!ITopLeft.Equals(ITopRight))
                {
                    return ITopRight;
                }
                else
                {
                    return new Point(_Right, _Top);
                }
            }
        }
        public Point TopLeft
        {
            get
            {
                if (!ITopLeft.Equals(ITopRight))
                {
                    return ITopLeft;
                }
                else
                {
                    return new Point(_Left, _Top);
                }

            }
        }
        public Point BottomRight
        {
            get
            {

                if (!IBottomLeft.Equals(IBottomRight))
                {
                    return IBottomRight;
                }
                else
                {
                    return new Point(_Right, _Bottom);
                }
            }
        }
        public Point BottomLeft
        {
            get
            {

                if (!IBottomLeft.Equals(IBottomRight))
                {
                    return IBottomLeft;
                }
                else
                {
                    return new Point(_Left, _Bottom);
                }
            }
        }
        int _Top = int.MaxValue;
        int _Bottom = int.MinValue;
        int _Right = int.MinValue;
        int _Left = int.MaxValue;
        public Point Top { get { return (from P in _List where P.Y == _Top select P).First(); } }
        public Point Bottom { get { return (from P in _List where P.Y == _Bottom select P).First(); } }
        public Point Right { get { return (from P in _List where P.X == _Right select P).First(); } }
        public Point Left { get { return (from P in _List where P.X == _Left select P).First(); } }
        public int IndexOf(Point item)
        {
            return _List.IndexOf(item);
        }

        public void Insert(int index, Point item)
        {
            _Top = Math.Min(_Top, item.Y);
            _Bottom = Math.Max(_Bottom, item.Y);
            _Left = Math.Min(_Left, item.X);
            _Right = Math.Max(_Right, item.X);
            _List.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _List.RemoveAt(index);
        }

        public Point this[int index]
        {
            get
            {
                return _List[index];
            }
            set
            {
                _List[index] = value;
            }
        }
        public void AddRange(IEnumerable<Point> Range)
        {
            if (Range != null)
            {
                foreach(Point P in Range)
                {
                    Add(P);
                }
            }
        }
        public void Add(Point item)
        {
            _Top = Math.Min(_Top, item.Y);
            _Bottom = Math.Max(_Bottom, item.Y);
            _Left = Math.Min(_Left, item.X);
            _Right = Math.Max(_Right, item.X);
            _List.Add(item);
        }

        public void Clear()
        {
            _Top = int.MaxValue;
            _Bottom = int.MinValue;
            _Left = int.MaxValue;
            _Right = int.MinValue;
            _List.Clear();
        }

        public bool Contains(Point item)
        {
            return _List.Contains(item);
        }

        public void CopyTo(Point[] array, int arrayIndex)
        {
            _List.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _List.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Point item)
        {
            return _List.Remove(item);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return _List.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _List.GetEnumerator();
        }
    }
}
