﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombak
{
    class EntityFactory
    {
        public static EntityFactory Instance = new EntityFactory();

        private List<Entity> runners;
        private List<Entity> bombs;
        private List<Entity> runnersToBeAdded;

        public List<Entity> Runners => this.runners;
        public List<Entity> RunnersToBeAdded => this.runnersToBeAdded;

        private static Random r = new Random();
        private Point mousePosition = new Point();
        public Point MousePosition
        {
            get { return mousePosition; }
            set { mousePosition = value; }
        }

        public EntityFactory()
        {
            runners = new List<Entity>();
            runnersToBeAdded = new List<Entity>();
            bombs = new List<Entity>();
        }

        public void createRunner()
        {
            int x = Math.Min(r.Next(0, Settings.Instance.fieldSize.Width) * Settings.Instance.cellSize.Width, Settings.Instance.fieldSizePx.Width);
            int y = Math.Min(r.Next(0, Settings.Instance.fieldSize.Height) * Settings.Instance.cellSize.Height, Settings.Instance.fieldSizePx.Height);
            runnersToBeAdded.Add(new Runner(new Point(x, y)));
        }

        public void createBomb()
        {
            bombs.Add(new Bomb(mousePosition));
        }

        public void addRunners()
        {
            if (runnersToBeAdded.Count > 0)
            {
                runners.AddRange(runnersToBeAdded);
                runnersToBeAdded.Clear();
            }
        }
    }
}
