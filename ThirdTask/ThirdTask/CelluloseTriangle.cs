using Figures;
using System;
using System.Collections.Generic;
using System.Text;
using ThirdTask.Materials;

namespace ThirdTask
{
    class CelluloseTriangle : Triangle, ICelluloseTape
    {
        public CelluloseTriangle(int x1, int y1, int x2, int y2, int x3, int y3) : base(x1, y1, x2, y2, x3, y3) 
        { }
    }
}
