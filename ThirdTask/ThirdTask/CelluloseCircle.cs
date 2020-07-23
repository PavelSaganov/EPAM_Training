using Figures;
using System;
using System.Collections.Generic;
using System.Text;
using ThirdTask.Materials;

namespace ThirdTask
{
    class CelluloseCircle : Circle, ICelluloseTape
    {
        public CelluloseCircle(int x, int y, double radius) : base(x, y, radius) 
        { }
    }
}
