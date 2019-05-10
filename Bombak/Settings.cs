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
        public Size fieldSize = new Size();
        public Size fieldSizePx = new Size();
        public Size cellSize = new Size();
        public int speed;

        public Settings() { }
    }
}
