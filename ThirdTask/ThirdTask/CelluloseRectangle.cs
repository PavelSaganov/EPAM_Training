using Figures;
using System;
using System.Collections.Generic;
using System.Text;
using ThirdTask.Materials;

namespace ThirdTask
{
    class CelluloseRectangle : Rectangle, ICelluloseTape
    {
        public CelluloseRectangle(double Width, double Hight) : base(Width, Hight) 
        { }
    }
}
