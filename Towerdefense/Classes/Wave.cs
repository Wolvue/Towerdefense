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
    
    class Wave
    {
        public List<Enemy> enemylist;


        private double enemyhealth;
        private int enemyspeed;
        private int enemydamage;
        private int enemygolddrop;



        
        private Wavelist wavelist;

        private double spawndelay;
        private int spawnamount;
        private int spawnedamount;
        private int spawnhex;
        private bool allowedtospawn;

        private float lasttime;

        public Wave()
        {
            enemylist = new List<Enemy>();
            wavelist = new Wavelist();
            enemydamage = 1;
            enemyspeed = 2;
            spawnamount = 15;
            enemyhealth = 8;
            
        }


        public void SpawnWave(Map map, GameTime gametime, Texture2D enemytexture, Texture2D healthbar)
        {
            if (enemylist.Count == 0 && allowedtospawn == false)
            {
                
                NextWave();
                allowedtospawn = true;
                spawndelay = 1.5;

            }
            
            
            if (spawnedamount == spawnamount)
            {
                spawnhex = 0;
                spawnedamount = 0;
                allowedtospawn = false;
            }
            else if (spawndelay >= 1.5 && spawnedamount <= spawnamount && allowedtospawn == true)
            {
                enemylist.Add(new Enemy(enemyhealth, enemyspeed, enemydamage, enemygolddrop, enemytexture, healthbar));
                enemylist[spawnhex].Loadwaypoints(map.waypoints);
                spawndelay = 0;
                spawnhex++;
                spawnedamount++;
            }
            

            spawndelay += gametime.ElapsedGameTime.TotalSeconds;



        }

        public void CheckAliveEnemy()
        {
            foreach (var enemy in enemylist)
            {
                if (enemy.Alive != true)
                {
                    enemylist.Remove(enemy);
                    spawnhex--;
                    if (spawnhex < 0)
                    {
                        spawnhex = 0;
                    }
                    return;
                }
            }
        }

        public void MoveEnemies(float timer)
        {   if (enemylist.Count >= 1 && timer - lasttime >= 0.02)
            {
                lasttime = timer;
                foreach (var enemy in enemylist)
                {
                    if(enemy.waypointindex >= enemy.waypoints.Count)
                    {
                        enemylist.Remove(enemy);
                        
                        return;
                    }
                    else
                    {
                        enemy.Move();
                    }
                
                
                }
            }
            
            
        }

        public void DrawEnemies(SpriteBatch batch)
        {
            foreach (var enemy in enemylist)
            {
                enemy.Draw(batch);
            }
        }

        public void NextWave()
        {
            enemyhealth = enemyhealth * 1.2;
            enemygolddrop += 1;
        }
    }
}
