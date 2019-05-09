using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int x;
        private void Button1_Click(object sender, EventArgs e)
        {
            x = (int)numericUpDown1.Value;
            pictureBox1.Refresh();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            drawField(e);
        }

        private void drawField(PaintEventArgs e)
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            Graphics g = e.Graphics;
            Pen p = Pens.Black;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    g.DrawLine(p, 0, j * height / x, width, j * height / x);
                    g.DrawLine(p, i * height / x, 0, i * height / x, height);

                }
            }
            g.DrawLine(p, 0, height - 1, 0, 0);
            g.DrawLine(p, width - 1, 0, 0, 0);

            g.DrawLine(p, 0, height - 1, width, height - 1);
            g.DrawLine(p, width - 1, 0, width - 1, height);
        }
    }
}
