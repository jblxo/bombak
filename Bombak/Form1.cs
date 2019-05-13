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
        private int x;
        private int y;

        public Form1()
        {
            InitializeComponent();

            x = Settings.Instance.fieldSize.Width;
            y = Settings.Instance.fieldSize.Height;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            drawField(e);
        }

        private void drawField(PaintEventArgs e)
        {
            int height = pictureBox1.Height-1;
            int width = pictureBox1.Width-1;
            Graphics g = e.Graphics;
            Pen p = new Pen(Brushes.Black);
            int n;
            if (x < y)
            {
                n = y;
            }
            else
            {
                n = x;
            }
            int m = width / n;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    g.DrawRectangle(p, i * m, j * m, m, m);
                }
            }
        }
    }
}
