using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombak
{
    public partial class Form1 : Form
    {
        private int x;
        private int y;
        private Thread updateThread;
        private Thread drawThread;
        private EntityFactory factory;
        private List<Entity> runners;
        private float deltaTime;

        public Form1()
        {
            InitializeComponent();

            x = Settings.Instance.fieldSize.Width;
            y = Settings.Instance.fieldSize.Height;
            updateThread = new Thread(new ThreadStart(updateThreadFunc));
            drawThread = new Thread(new ThreadStart(drawThreadFunc));
            factory = new EntityFactory();
            runners = new List<Entity>();
            deltaTime = 0.00f;
            generateRunners();
            updateThread.Start();
            drawThread.Start();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            drawField(e);
            foreach (Entity runner in runners)
            {
                runner.Draw(e.Graphics);
            }
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

        private void updateThreadFunc()
        {
            try
            {
                while(true)
                {
                    deltaTime += 0.05f;

                    foreach(Entity runner in runners)
                    {
                        runner.Update(deltaTime);

                        Thread.Sleep(50);
                    }
                }
            }
            catch (Exception e)
            {
                // Log errors ?
                Console.WriteLine(e);
            }
        }
        
        private void generateRunners()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                int x = r.Next(0, 10) * 50;
                int y = r.Next(0, 10) * 50;
                Point p = new Point(x, y);
                runners.Add(factory.GenerateEntity("RUNNER",p));
            }
            
        }

        private void drawRunners(PaintEventArgs e){
            Graphics g = e.Graphics;     
        }

        private void drawThreadFunc()
        {
            // Runners draw logic here
            // Call thread start somewhere with the parameter

            while (true)
            {
                updateField(pictureBox1);
                
                Thread.Sleep(50);
            }
        }

        private void updateField(PictureBox pb)
        {
            if (pb.InvokeRequired)
                Invoke(new MethodInvoker(() => { updateField(pictureBox1); }));
            else
                pb.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(runners[2]);
        }
    }
}
