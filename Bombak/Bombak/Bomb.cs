using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombak
{

    class Bomb : Entity
    {
        private int radius = 3;
        private Color color = Color.PaleVioletRed;
        private double delay = 3.0;

        public Bomb(Point position)
        {
            this.position = position;
            Size computedSize = new Size(this.size, this.size);
            this.rect = new Rectangle(this.position, computedSize);
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(this.color), rect);
        }
    }
}
