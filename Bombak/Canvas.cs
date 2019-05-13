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
        public PictureBox Pb { get { return this.pictureBox; } }
        public Canvas()
        {
            InitializeComponent();

            size = new Size(this.pictureBox.Width - 1, this.pictureBox.Height - 1);
            x = Settings.Instance.fieldSize.Width;
            y = Settings.Instance.fieldSize.Height;
        }

        private void drawField(Graphics g)
        {
            float sizeX = size.Width / x;
            float sizeY = size.Height / y;

            for (int i = 0; i < x + 1; i++)
            {
                for(int j = 0; j < y + 1; j++)
                {
                    g.DrawLine(Pens.Black, 0, i * sizeX, size.Width, i * sizeX);
                    g.DrawLine(Pens.Black, j * sizeY, 0, j * sizeY, size.Height);
                }
            }
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            drawField(e.Graphics);
        }
    }
}
