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
        private SizeF cellSize = new Size();
        private float speed = 0.5f;

        public Runner(PointF p) : base()
        {
            this.speed = this.speed + (r.Next(2, 5) / 10);
            this.cellSize.Width = Settings.Instance.cellSize.Width;
            this.cellSize.Height = Settings.Instance.cellSize.Height;
            int red = r.Next(0, 256);
            int blue = r.Next(0, 256);
            int green = r.Next(0, 256);
            this.color = Color.FromArgb(red, green, blue);
            this.position = p;
            this.size = new SizeF(cellSize.Width, cellSize.Height);
            this.rect = new RectangleF(this.position, this.size);
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(this.color), this.rect);
            g.DrawEllipse(Pens.Black, this.rect);
        }

        public override void Update(float deltaTime)
        {
            if (deltaTime > lastUpdate + speed)
            {
                int direction = r.Next(0, 4);
                float x = this.rect.X;
                float y = this.rect.Y;

                switch (Enum.GetName(typeof(Directions), direction))
                {
                    case "Up":
                        y = Math.Min(y + cellSize.Height, Settings.Instance.fieldSizePx.Height - cellSize.Height);
                        break;
                    case "Right":
                        x = Math.Min(x + cellSize.Width, Settings.Instance.fieldSizePx.Width - cellSize.Width);
                        break;
                    case "Down":
                        y = Math.Max(y - cellSize.Height, 0);
                        break;
                    case "Left":
                        x = Math.Max(x - cellSize.Width, 0);
                        break;
                }

                updateRectPosition(x, y);

                lastUpdate = deltaTime;
            }
        }
        private void updateRectPosition(float x, float y)
        {
            this.rect.X = x;
            this.rect.Y = y;
        }
    }

    enum Directions
    {
        Up,
        Right,
        Down,
        Left
    }
}
