using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Towerdefense.Classes
{
    class Timer
    {
        public float time;

        public void UpdateTimer(GameTime gametime)
        {
            time += (float)gametime.ElapsedGameTime.TotalSeconds;

        }
    }
}
