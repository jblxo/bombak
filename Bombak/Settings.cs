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
        public Size fieldSize = new Size(10, 10);
        public Size fieldSizePx = new Size(501, 501);
        public Size cellSize = new Size();
        public int speed = 1;
        public Settings() { }
    }
}
