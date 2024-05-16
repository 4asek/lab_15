using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace lab_15
{
class CRectangle : CFigure
    {
        
        private int _sideA;   
         private int _sideB;   
    
    public int SideA 
    {         get         { 
            return _sideA; 
        }
    set         { 
            _sideA = value >= 200 ? 200 : value; 
            _sideA = value <= 5 ? 5 : value; 
        } 
    }  
    public int SideB
{
    get
    {
        return _sideB;
    }
    set
    {
        _sideB = value >= 200 ? 200 : value;
        _sideB = value <= 5 ? 5 : value;
    }
}




public CRectangle(Graphics graphics, int X, int Y, int SideA, int SideB)
{
    this.graphics = graphics; this.X = X; this.Y = Y; this.SideA = SideA; this.SideB = SideB;
}


protected override void Draw(Pen pen) 
{
    Rectangle rectangle = new Rectangle(X - SideA / 2, Y - SideB / 2, SideA, SideB); graphics.DrawRectangle(pen, rectangle);
}


override public void Expand(int dX) 
{
    Hide();
    SideA = SideA + dX;
    SideB = SideB + dX;
    Show();
}


override public void Collapse(int dX) 
{
    Hide();
    SideA = SideA - dX;
    SideB = SideB - dX;
    Show();
} 
 
}  

}

