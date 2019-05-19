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
        private List<Entity> bombsInRange = new List<Entity>();

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
            if (deltaTime > lastUpdate + speed + Settings.Instance.speed)
            {
                int direction = r.Next(0, 4);
                if (bombsInRange.Count > 0)
                {
                    foreach (Bomb bomba in bombsInRange)
                    {
                        double vx = this.rect.X + Settings.Instance.cellSize.Width / 2 - bomba.RadiusRect.X;
                        double vy = this.rect.Y + Settings.Instance.cellSize.Height / 2 - bomba.RadiusRect.Y;
                        if (Math.Abs(vx) > Math.Abs(vy))
                        {
                            if (vx > 0)
                            {
                                direction = 1;
                            }
                            else
                            {
                                direction = 3;
                            }
                        }
                        else
                        {
                            if(vy > 0)
                            {
                                direction = 0;
                            }
                            else
                            {
                                direction = 2;
                            }
                        }
                    }
                }
                
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

        public void checkBombs(List<Bomb> bombs)
        {
            bombsInRange.Clear();
            foreach (Bomb bomb in bombs)
            {
                double ac = Math.Abs(bomb.RadiusRect.X + Settings.Instance.cellSize.Width / 2 - this.rect.X);
                double bc = Math.Abs(bomb.RadiusRect.Y + Settings.Instance.cellSize.Height / 2 - this.rect.Y);
                float vzdalenost = (float)Math.Sqrt(Math.Pow(ac,2) + Math.Pow(bc,2));
                if(vzdalenost <= 180f)
                {
                    bombsInRange.Add(bomb);
                }
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
