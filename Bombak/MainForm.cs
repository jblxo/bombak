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
    public partial class MainForm : Form
    {
        private float x;
        private float y;
        private Thread updateThread;
        private Thread drawThread;
        private float deltaTime;
        private bool appRunning;

        public MainForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            x = Settings.Instance.fieldSize.Width;
            y = Settings.Instance.fieldSize.Height;

            if(y == x)
            {
                Settings.Instance.cellSize.Width = Settings.Instance.fieldSizePx.Width / x;
                Settings.Instance.cellSize.Height = Settings.Instance.fieldSizePx.Height / y;
            }
            else
            {
                Settings.Instance.cellSize.Width = Settings.Instance.fieldSizePx.Width / y;
                Settings.Instance.cellSize.Height = Settings.Instance.fieldSizePx.Height / x;
            } 

            updateThread = new Thread(new ThreadStart(updateThreadFunc));
            drawThread = new Thread(new ThreadStart(drawThreadFunc));
            deltaTime = 0.00f;
            appRunning = true;
            generateRunners();
            updateThread.Start();
            drawThread.Start();
        }

        private void updateThreadFunc()
        {
            try
            {
                while(appRunning)
                {
                    deltaTime += 0.05f;

                    EntityFactory.Instance.addRunners();

                    for (int i = 0; i < EntityFactory.Instance.Runners.Count; i++)
                    {
                        Entity runner = EntityFactory.Instance.Runners[i];
                        runner.Update(deltaTime);
                    }

                    for (int i = 0; i < EntityFactory.Instance.Bombs.Count; i++)
                    {
                        Entity bomb = EntityFactory.Instance.Bombs[i];
                        bomb.Update(deltaTime);
                    }

                    Thread.Sleep(50);
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
            for (int i = 0; i < 10; i++)
            {
                EntityFactory.Instance.createRunner();
            }

            EntityFactory.Instance.addRunners();
        }

        private void drawThreadFunc()
        {
            // Runners draw logic here

            while (appRunning)
            {
                updateField(canvas.Pb);
                
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
            EntityFactory.Instance.createRunner();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            appRunning = false;
            EntityFactory.Instance.Runners.Clear();
            EntityFactory.Instance.RunnersToBeAdded.Clear();
            EntityFactory.Instance.Bombs.Clear();
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EntityFactory.Instance.thanosRunners();
        }
        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            EntityFactory.Instance.MousePosition = new PointF(e.X - Settings.Instance.cellSize.Width/2, e.Y - Settings.Instance.cellSize.Height / 2);
            EntityFactory.Instance.createBomb(deltaTime);
        }
    }
}
