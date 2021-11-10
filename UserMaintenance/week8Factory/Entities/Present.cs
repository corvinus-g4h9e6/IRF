using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week8Factory.Abstractions;

namespace week8Factory.Entities
{
    class Present : Toy
    {
        public SolidBrush RibbonColor { get; private set; }
        public SolidBrush BoxColor { get; private set; }

        public Present(Color ribbon, Color box)
        {
            RibbonColor = new SolidBrush(ribbon);
            BoxColor = new SolidBrush(box);
        }
        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(BoxColor, 0, 0, 55, 55);
            g.FillRectangle(RibbonColor, 25, 0, 5, 55);
            g.FillRectangle(RibbonColor, 0, 25, 55, 5);
        }
    }
}
