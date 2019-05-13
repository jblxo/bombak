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
        private static Random r = new Random();
        private Size cellSize = new Size();
        private float speed = 0.5f;

        public Runner(Point p) : base()
        {
            this.speed = (float) r.Next(1, 50) / 10;
            this.cellSize.Width = Settings.Instance.cellSize.Width;
            this.cellSize.Height = Settings.Instance.cellSize.Height;
            this.color = Color.Blue;
            this.position = p;
            this.size = new Size(cellSize.Width, cellSize.Height);
            this.rect = new Rectangle(this.position, this.size);
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(this.color), this.rect);
            g.DrawEllipse(Pens.Black, this.rect);
        }

        public override void Update(float deltaTime)
        {
            if (deltaTime > lastUpdate * speed)
            {
                Console.WriteLine("MOVE");

                int x = Math.Min(r.Next(0, Settings.Instance.fieldSize.Width) * cellSize.Width, Settings.Instance.fieldSizePx.Width);
                int y = Math.Min(r.Next(0, Settings.Instance.fieldSize.Height) * cellSize.Height, Settings.Instance.fieldSizePx.Height);
                updateRectPosition(x, y);

                lastUpdate = deltaTime;
            }
        }
        private void updateRectPosition(int x, int y)
        {
            this.rect.X = x;
            this.rect.Y = y;
        }
    }
}
