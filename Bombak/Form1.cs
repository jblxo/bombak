﻿using System;
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
        private bool appRunning;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            Settings.Instance.fieldSizePx.Width = pictureBox1.Width - 1;
            Settings.Instance.fieldSizePx.Height = pictureBox1.Height -1;

            x = Settings.Instance.fieldSize.Width;
            y = Settings.Instance.fieldSize.Height;
            updateThread = new Thread(new ThreadStart(updateThreadFunc));
            drawThread = new Thread(new ThreadStart(drawThreadFunc));
            factory = new EntityFactory();
            runners = new List<Entity>();
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
            int height = pictureBox1.Height - 1;
            int width = pictureBox1.Width - 1;
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

        private void updateThreadFunc()
        {
            try
            {
                while(appRunning)
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
            Console.WriteLine(runners[2]);
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
