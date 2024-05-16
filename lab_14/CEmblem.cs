using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_15
{
    class CEmblem : CFigure
    {
        const int DefaultRadius = 50;

        private int _side;
        private int _radius;
        public int Side
        {
            get { return _side; }
            set { _side = value >= 200 ? 200 : (value <= 5 ? 5 : value); }
        }
        public int Radius
        {
            get { return _radius; }
            set { _radius = value >= 200 ? 200 : (value <= 5 ? 5 : value); }
        }
        public CEmblem(Graphics graphics, int X, int Y, int Side, int Radius)
        {
            this.graphics = graphics;
            this.X = X; this.Y = Y;
            this.Side = Side;
            this.Radius = DefaultRadius;
            this.Radius = Radius;
        }
        public CEmblem(Graphics graphics, int X, int Y, int Radius)
        {
            this.graphics = graphics; 
            this.X = X; 
            this.Y = Y;
            this.Radius = Radius;
        }
        protected override void Draw(Pen pen)
        {
            // Малюємо коло
            Rectangle circle = new Rectangle(X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            graphics.DrawEllipse(pen, circle);

            // Малюємо квадрат усередині кола (повернутий на 90 градусів)
            Rectangle square = new Rectangle(X - Radius / 2, Y - Radius / 2, Radius, Radius);
            graphics.RotateTransform(90); // Поворот на 90 градусів
            graphics.DrawRectangle(pen, square);
            graphics.ResetTransform(); // Скидаємо поворот

            // Малюємо трикутник до гори низом
            double r = (Side / 2) / Math.Sin(Math.PI / 3);
            Point p1 = new Point(X, Y - (int)r);
            Point p2 = new Point(X - (int)(r * Math.Cos(Math.PI / 6)), Y + (int)(r * Math.Sin(Math.PI / 6)));
            Point p3 = new Point(X + (int)(r * Math.Cos(Math.PI / 6)), Y + (int)(r * Math.Sin(Math.PI / 6)));
            Point[] triangle = { p1, p2, p3 };
            graphics.DrawPolygon(pen, triangle);
        }
        override public void Expand(int dX)
        {
            Hide();
            Side = Math.Min(200, Side + dX + 5);
            Radius = Math.Min(200, Radius + dX);
            Show();
        }
        override public void Collapse(int dX)
        {
            Hide();
            Side = Math.Max(5, Side - dX - 5);
            Radius = Math.Max(5, Radius - dX);
            Show();
        }
       

    }
}