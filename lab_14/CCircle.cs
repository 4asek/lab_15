using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
namespace lab_15
{
    class CCircle : CFigure
    {
        
        private int _radius;   
                              
        public int Radius
        {   
        get         { 
            return _radius;
        }
        set         { 
            _radius = value >= 200 ? 200 : value; 
            _radius = value <= 5  ? 5  : value; 
        }
    }

    
    public CCircle(Graphics graphics, int X, int Y, int Radius) 
    {
        this.graphics = graphics; this.X = X; this.Y = Y;
        this.Radius = Radius;
    }

   
    protected override void Draw(Pen pen) 
    {
        Rectangle rectangle = new Rectangle(X - Radius, Y - Radius,
        2 * Radius, 2 * Radius);
        graphics.DrawEllipse(pen, rectangle);
    }

   
    override public void Expand(int dR) 
    {
        Hide();
        Radius = Radius + dR;
        Show();
    }   
  
    override public void Collapse(int dR) 
    {
        Hide();
        Radius = Radius - dR;
        Show();
    } 
}  


}
