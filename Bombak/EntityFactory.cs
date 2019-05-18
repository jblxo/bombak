using System;
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
        public List<Entity> Bombs => this.bombs;

        private static Random r = new Random();
        private PointF mousePosition = new PointF();
        public PointF MousePosition
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
            float x = Math.Min(r.Next(0, (int) Settings.Instance.fieldSize.Width) * Settings.Instance.cellSize.Width, Settings.Instance.fieldSizePx.Width);
            float y = Math.Min(r.Next(0, (int) Settings.Instance.fieldSize.Height) * Settings.Instance.cellSize.Height, Settings.Instance.fieldSizePx.Height);
            runnersToBeAdded.Add(new Runner(new PointF(x, y)));
        }

        public void thanosRunners()
        {
            int count = runners.Count;
            Random r = new Random();
            int rr;
            for (int i = 0; i < count/2; i++)
            {
                rr = r.Next(0, count - 2);
                Console.WriteLine(runners[rr] + "-" + rr);
                runners.RemoveAt(rr);
                count = runners.Count;
            }
            
        }
        public void IMRunners()
        {
            int count = runners.Count;
            for (int i = 0; i <= count/2; i++)
            {
                createRunner();
            }
            addRunners();
            Console.WriteLine(runners.Count);
        }

        public void createBomb(float deltaTime)
        {
            bombs.Add(new Bomb(mousePosition, deltaTime));
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
