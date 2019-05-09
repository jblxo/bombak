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
        private EntityFactory factory;
        private List<Entity> runners;

        public Form1()
        {
            InitializeComponent();

            x = Settings.Instance.fieldSize.Width;
            y = Settings.Instance.fieldSize.Height;
            factory = new EntityFactory();
            runners = new List<Entity>();
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
            Pen p = Pens.Black;
            int n;
            int m1 = 0;
            int m2 = 0;
            if (x < y)
            {
                n = y;  
                m1 = width / n * (y-x)+1;

            }else
            {
                n = x;
                m2 = height / n * (x-y)+1;
            }
                
            for (int i = 0; i < x+1; i++)
            {
                for (int j = 0; j < y+1; j++)
                {
                    g.DrawLine(p, 0, j * height / n, width - m1, j * height / n);
                    g.DrawLine(p, i * height / n, 0, i * height / n, height-m2);

                }
            }
            
        }

        private void generateRunners()
        {
            for (int i = 0; i < 20; i++)
            {
                runners.Add(factory.GenerateEntity("RUNNER"));
            }
        }
    }
}
