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
        private static Random r = new Random();
        private Point mousePosition = new Point();
        public Point MousePosition
        {
            get { return mousePosition; }
            set { mousePosition = value; }
        }

        public EntityFactory()
        {

        }

        public Entity GenerateEntity(string entityType)
        {
            switch (entityType)
            {
                case "RUNNER":
                    return createNewRunner();
                case "BOMB":
                    return new Bomb(mousePosition);
                default:
                    return null;
            }
        }

        private Runner createNewRunner()
        {
            int x = Math.Min(r.Next(0, Settings.Instance.fieldSize.Width) * Settings.Instance.cellSize.Width, Settings.Instance.fieldSizePx.Width);
            int y = Math.Min(r.Next(0, Settings.Instance.fieldSize.Height) * Settings.Instance.cellSize.Height, Settings.Instance.fieldSizePx.Height);
            return new Runner(new Point(x, y));
        }
    }
}
