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
