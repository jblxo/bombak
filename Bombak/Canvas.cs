using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombak
{
    public partial class Canvas : UserControl
    {
        private Size size;
        private float x;
        private float y;
        private float sizeX;
        private float sizeY;
        public PictureBox Pb { get { return this.pictureBox; } }
        public Canvas()
        {
            InitializeComponent();

            size = new Size(this.pictureBox.Width - 1, this.pictureBox.Height - 1);
            Settings.Instance.fieldSizePx = size;
            x = Settings.Instance.fieldSize.Width;
            y = Settings.Instance.fieldSize.Height;
            sizeX = size.Width / x;
            sizeY = size.Height / y;

            Settings.Instance.cellSize.Width = (int) sizeX;
            Settings.Instance.cellSize.Height = (int) sizeY;
        }

        private void drawField(Graphics g)
        {        
            for (int i = 0; i < x + 1; i++)
            {
                for(int j = 0; j < y + 1; j++)
                {
                    g.DrawLine(Pens.Black, 0, i * sizeX, size.Width, i * sizeX);
                    g.DrawLine(Pens.Black, j * sizeY, 0, j * sizeY, size.Height);
                }
            }
        }

        private void drawEntities(List<Entity> entities, Graphics g)
        {
            foreach(Entity entity in entities)
            {
                entity.Draw(g);
            }
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            drawEntities(EntityFactory.Instance.Runners, e.Graphics);
            drawField(e.Graphics);
        }
    }
}
