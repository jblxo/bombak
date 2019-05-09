using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombak
{
    class Runner : Entity
    {
        

        public Runner(Point p) : base()
        {
            this.color = Color.Blue;
            this.position = p;
            this.size = new Size(50, 50);
            this.rect = new Rectangle(this.position, this.size);
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(this.color), this.rect);
        }

        public override void Update(float deltaTime)
        {
            Random r = new Random();
            int x = r.Next(0, Settings.Instance.fieldSizePx.Width);
            int y = r.Next(0, Settings.Instance.fieldSizePx.Height);
            updateRectPosition(x, y);
        }

        private void updateRectPosition(int x, int y)
        {
            this.rect.X = x;
            this.rect.Y = y;
        }
    }
}
