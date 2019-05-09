using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombak
{
    class EntityFactory
    {
        private Random r;
        private Point mousePosition = new Point();
        public Point MousePosition
        {
            get { return mousePosition; }
            set { mousePosition = value; }
        }

        public EntityFactory()
        {
            r = new Random();
        }

        public Entity GenerateEntity(string entityType)
        {
            switch (entityType)
            {
                case "RUNNER":
                    return new Runner();
                case "BOMB":
                    return new Bomb(mousePosition);
                default:
                    return null;
            }
        }
    }
}
