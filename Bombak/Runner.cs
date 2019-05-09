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
        public Runner() : base()
        {
            this.color = Color.Blue;
            this.position = new Point(50, 50);
            this.size = new Size(10, 10);
            this.rect = new Rectangle(this.position, this.size);
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(this.color), this.rect);
        }

        public override void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
