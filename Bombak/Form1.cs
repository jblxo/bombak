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
        private List<Entity> runnersToBeAdded;
        private float deltaTime;
        private bool appRunning;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            Settings.Instance.fieldSizePx.Width = pictureBox1.Width - 1;
            Settings.Instance.fieldSizePx.Height = pictureBox1.Height -1;

            x = Settings.Instance.fieldSize.Width;
            y = Settings.Instance.fieldSize.Height;

            Settings.Instance.cellSize.Width = Settings.Instance.fieldSizePx.Width / (y * (y - x) + 1) / x;
            Settings.Instance.cellSize.Height = Settings.Instance.fieldSizePx.Height / (x * (x - y) + 1) / y;

            updateThread = new Thread(new ThreadStart(updateThreadFunc));
            drawThread = new Thread(new ThreadStart(drawThreadFunc));
            factory = new EntityFactory();
            runners = new List<Entity>();
            runnersToBeAdded = new List<Entity>();
            deltaTime = 0.00f;
            appRunning = true;
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
                while(appRunning)
                {
                    Console.WriteLine(deltaTime);

                    if (runnersToBeAdded.Count > 0)
                    {
                        runners.AddRange(runnersToBeAdded);
                        runnersToBeAdded.Clear();
                    }

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
            for (int i = 0; i < 1; i++)
            {
                runners.Add(factory.GenerateEntity("RUNNER"));
            }
            
        }

        private void drawThreadFunc()
        {
            // Runners draw logic here

            while (appRunning)
            {
                updateField(pictureBox1);
                
                Thread.Sleep(50);
            }
        }

        private void updateField(PictureBox pb)
        {
            if (pb.InvokeRequired)
                Invoke(new MethodInvoker(() => { updateField(pb); }));
            else
                pb.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            runnersToBeAdded.Add(factory.GenerateEntity("RUNNER"));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            appRunning = false;
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }
    }
}
