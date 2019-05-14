using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombak
{
    class Settings
    {
        public static Settings Instance = new Settings();
        public SizeF fieldSize = new SizeF(10f, 10f);
        public SizeF fieldSizePx = new SizeF(501f, 501f);
        public SizeF cellSize = new SizeF();
        public float speed = 1f;
        public Settings() { }
    }
}
