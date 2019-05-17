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
        private float radius = 3f;
        private Color color = Color.PaleVioletRed;
        private float delay = 1.5f;
        private float detonationTime = 0.0f;
        private RectangleF radiusRect;
        private float detonationStep = 360.0f;

        public Bomb(PointF position, float deltaTime)
        {
            this.detonationTime = deltaTime + delay;
            this.color = Color.Black;
            this.position = position;
            SizeF computedSize = new SizeF(Settings.Instance.cellSize.Width, Settings.Instance.cellSize.Height);
            this.rect = new RectangleF(this.position, computedSize);
            this.radiusRect = new RectangleF(new PointF(this.position.X - computedSize.Width, this.position.Y - computedSize.Height), new SizeF(computedSize.Width * radius, computedSize.Height * radius));
        }

        public override void Draw(Graphics g)
        {
            g.FillPie(Brushes.Beige, radiusRect.X, radiusRect.Y, radiusRect.Height, radiusRect.Height, 0, detonationStep);
            g.FillEllipse(new SolidBrush(this.color), rect);
            g.DrawEllipse(Pens.Red, rect);
            g.DrawEllipse(Pens.Red, radiusRect);
        }

        public override void Update(float deltaTime)
        {
            if(deltaTime > detonationTime)
            {
                EntityFactory.Instance.Bombs.Remove(this);
            } else
            {
                detonationStep -= 12f;
            }
        }
    }
}
