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
            SizeF computedSize = new SizeF(this.size.Width, this.size.Height);
            this.rect = new RectangleF(this.position, computedSize);
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(this.color), rect);
        }

        public override void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
