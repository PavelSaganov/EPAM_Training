using Enumerables;
using Figures;
using System;
using System.Collections.Generic;
using System.Text;
using ThirdTask.Materials;

namespace ThirdTask
{
    class PaperCircle : Circle, IPaper
    {
        public Colors Color { get; set; }

        public PaperCircle(int x, int y, double radius) : base(x, y, radius) 
        { }
    }
}
