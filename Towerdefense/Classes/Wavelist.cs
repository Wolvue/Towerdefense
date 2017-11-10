using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities.Classes;
using MapBuilder.Classes;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Towerdefense.Classes
{
    public class Wavelist
    {
        public List<Enemy> enemylist;

        public Wavelist()
        {
            enemylist = new List<Enemy>();
        }

        public List<Enemy> LoadWave(int wavenumber)
        {
            if (wavenumber == 1)
            {

            }


            return enemylist;
        }
            
    }
}
