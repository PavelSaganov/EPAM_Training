using Enumerables;
using Figures;
using System;
using System.Collections.Generic;
using System.Text;
using ThirdTask.Materials;

namespace ThirdTask
{
    class PaperRectangle : Rectangle, IPaper
    {
        public Colors Color { get; set; }

        public PaperRectangle(double Width, double Hight) : base(Width, Hight) 
        { }
    }
}
