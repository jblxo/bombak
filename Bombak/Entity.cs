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
        protected Point position;
        protected int size;
        protected Color color;
        protected Rectangle rect;

        public Entity()
        {

        }

        public abstract void Draw(Graphics g);
    }
}
