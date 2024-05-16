using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_15
{
    public partial class fMain : Form
    {
        CFigure[] figures;
        int FiguresCount = 0;
        int CurrentFigureIndex;
        public fMain()
        {
            InitializeComponent();
            figures = new CFigure[100];
            cbFigureType.SelectedIndex = 0;
        }
        
        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            if (FiguresCount >= 99)
            {
                MessageBox.Show("Досягнуто межі кількості об'єктів!"); return;
            }
            Graphics graphics = pnMain.CreateGraphics();
            CurrentFigureIndex = FiguresCount;     // Створення нового об'єкта - фігури 
            if (cbFigureType.SelectedIndex == 0)      // Створюємо коло 
            {
                figures[CurrentFigureIndex] =
                    new CCircle(graphics, pnMain.Width / 2, pnMain.Height / 2,
                        50);
                cbFigures.Items.Add("Фігура №" + (FiguresCount - 1).ToString() +
                    " [коло]");
            }
            else if (cbFigureType.SelectedIndex == 1) // Створюємо прямокутник 
            {
                figures[CurrentFigureIndex] = new CRectangle(graphics, pnMain.Width / 2, pnMain.Height / 2, 100, 50);
                cbFigures.Items.Add("Фігура №" + (FiguresCount - 1).ToString() +
                    " [прямокутник]");
            }
            else if (cbFigureType.SelectedIndex == 2) // Створюємо трикутник 
            {
                figures[CurrentFigureIndex] = new CTriangle(graphics, pnMain.Width / 2, pnMain.Height / 2, 100);
                cbFigures.Items.Add("Фігура №" + (FiguresCount - 1).ToString() +
                    " [трикутник]");
            }
            else if (cbFigureType.SelectedIndex == 3) // Створюємо емблему 
            {
                figures[CurrentFigureIndex] = new CEmblem(graphics, pnMain.Width / 2, pnMain.Height / 2, 88, 50);
                cbFigures.Items.Add("Фігура №" + (FiguresCount - 1).ToString() +
                    " [емблема]");
            }
            figures[CurrentFigureIndex].Show(); FiguresCount++;
            cbFigures.SelectedIndex = FiguresCount - 1;
        }

        private void btnHide_Click(object sender, EventArgs e) 
        {
           CurrentFigureIndex = cbFigures.SelectedIndex;    
            if ((CurrentFigureIndex > FiguresCount) ||  
       (CurrentFigureIndex< 0))          return; 
    // -------------------------------------------------------------- 
    // Приховування поточного об'єкта
    figures[CurrentFigureIndex].Hide(); 

        }

    private void btnShow_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
     (CurrentFigureIndex < 0)) return;

            // -------------------------------------------------------------- 
            // Відображення поточного об'єкта
            figures[CurrentFigureIndex].Show(); 

        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
   (CurrentFigureIndex < 0)) return;
            // ------------------------------------------------------------- 
            // Розширення поточного об'єкта
            figures[CurrentFigureIndex].Expand(5); 

        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
    (CurrentFigureIndex < 0)) return;
            // -------------------------------------------------------------     // Розширення поточного об'єкта - екземпляра класу CCircle
            figures[CurrentFigureIndex].Collapse(5);     

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
(CurrentFigureIndex < 0)) return;
            // -------------------------------------------------------------- 
            // Переміщення вверх поточного об'єкта
            figures[CurrentFigureIndex].Move(0, -10); 

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
   (CurrentFigureIndex < 0)) return;
            // -------------------------------------------------------------- 
            // Переміщення вниз поточного об'єкта
            figures[CurrentFigureIndex].Move(0, 10);     

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
    (CurrentFigureIndex < 0)) return;
            // -----------------------------------------
            
            // Переміщення вправо поточного об'єкта
            figures[CurrentFigureIndex].Move(10, 0); 

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
     (CurrentFigureIndex < 0)) return;
            // -------------------------------------------------------------- 
            // Переміщення вліво поточного об'єкта
            figures[CurrentFigureIndex].Move(-10, 0); 

        }

        private void btnRightFar_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
   (CurrentFigureIndex < 0)) return;
            // --------------------------------------------------------------     // Переміщення поточного об'єкта вправо на більшу відстань
            for (int i = 0; i < 100; i++) 
            {
                figures[CurrentFigureIndex].Move(1, 0);
                System.Threading.Thread.Sleep(5);
            }

        }

        private void btnLeftFar_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
   (CurrentFigureIndex < 0)) return;
            // -------------------------------------------------------------- 
            // Переміщення поточного об'єкта вліво на більшу відстань
            for (int i = 0; i < 100; i++) 
            {
                figures[CurrentFigureIndex].Move(-1, 0);
                System.Threading.Thread.Sleep(5);
            }

        }

        private void btnUpFar_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
    (CurrentFigureIndex < 0)) return;
            // -------------------------------------------------------------- 
            // Переміщення поточного об'єкта вверх на більшу відстань
            for (int i = 0; i < 100; i++) 
            {
                figures[CurrentFigureIndex].Move(0, -1); System.Threading.Thread.Sleep(5);
            }

        }

        private void btnDownFar_Click(object sender, EventArgs e)
        {
            CurrentFigureIndex = cbFigures.SelectedIndex; if ((CurrentFigureIndex > FiguresCount) ||
   (CurrentFigureIndex < 0)) return;
            // -------------------------------------------------------------- 
            // Переміщення поточного об'єкта вниз на більшу відстань
            for (int i = 0; i < 100; i++) 
            {
                figures[CurrentFigureIndex].Move(0, 1);
                System.Threading.Thread.Sleep(5);
            }

        }
        private void fMain_Load(object sender, EventArgs e)
        {

        }
    }
}
