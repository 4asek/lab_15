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
        private const int DefaultRadius = 50;
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
            this.X = X;
            this.Y = Y;
            this.Side = Side;
            this.Radius = Radius;
        }

        protected override void Draw(Pen pen)
        {
            // Малюємо коло
            Rectangle circle = new Rectangle(X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            graphics.DrawEllipse(pen, circle);

            // Обчислюємо розміри квадрата в межах кола
            int squareSize = (int)(Math.Sqrt(2) * Radius); // Діагональ квадрата = діаметр кола
            int squareX = X - squareSize / 2;
            int squareY = Y - squareSize / 2;

            // Зберігаємо поточний стан графіки для відновлення пізніше
            GraphicsState state = graphics.Save();

            // Переносимо та повертаємо систему координат для відображення квадрата
            graphics.TranslateTransform(X, Y);
            graphics.RotateTransform(45);

            // Малюємо квадрат усередині кола
            Rectangle square = new Rectangle(-squareSize / 2, -squareSize / 2, squareSize, squareSize);
            graphics.DrawRectangle(pen, square);

            // Відновлюємо попередній стан графіки
            graphics.Restore(state);

            // Обчислюємо нові координати для трикутника, щоб він був рівно в середині кола
            double height = Side * Math.Sin(Math.PI / 3);
            int triangleY = Y - Radius + (int)(height / 2); // Висота трикутника + радіус кола знизу

            Point p1 = new Point(X, triangleY - (int)(height / 2)); // Вершина
            Point p2 = new Point(X - Side / 2, triangleY + (int)(height / 2)); // Ліва нижня точка
            Point p3 = new Point(X + Side / 2, triangleY + (int)(height / 2)); // Права нижня точка
            Point[] triangle = { p1, p2, p3 };
            graphics.DrawPolygon(pen, triangle);
        }

        public override void Expand(int dX)
        {
            Hide();
            Side = Math.Min(200, Side + dX + 5);
            Radius = Math.Min(200, Radius + dX);
            Show();
        }

        public override void Collapse(int dX)
        {
            Hide();
            Side = Math.Max(5, Side - dX - 5);
            Radius = Math.Max(5, Radius - dX);
            Show();
        }


    }
}