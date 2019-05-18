using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombak
{
    abstract class Entity
    {
        public PointF position;
        protected SizeF size;
        protected Color color;
        protected RectangleF rect;
        protected float lastUpdate = 0.05f;

        public Entity()
        {

        }

        public abstract void Draw(Graphics g);
        public abstract void Update(float deltaTime);
    }
}
