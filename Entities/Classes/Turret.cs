using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Entities.Classes
{
    
    public class Turret
    {
        private Texture2D turretbase;
        private Texture2D turretbarrel;
        private Texture2D projectiletexture;
        private Vector2 turretbox;

        private int range;
        private double damage;
        private double attackspeed;

        private float lasttime;
        private Enemy target;


        Projectile projectile;
        List<Projectile> projectiles;



        public Turret(Texture2D turretbase, Texture2D turretbarrel, Texture2D projectiletexture, Vector2 box)
        {
            this.turretbase = turretbase;
            this.turretbarrel = turretbarrel;
            this.projectiletexture = projectiletexture; 
            this.turretbox.X = box.X + 5;
            this.turretbox.Y = box.Y + 5;
            projectiles = new List<Projectile>();
            range = 150;
            attackspeed = 5;
        }



        public void Shoot(List<Enemy> enemylist, float time )
        {
            
            if (enemylist.Count >= 1 && (time - lasttime) >= (1 / attackspeed) && target != null)
            {
                Vector2 shotbox = new Vector2(turretbox.X + (turretbarrel.Width / 2),turretbox.Y +  (turretbase.Height / 2));
                projectiles.Add(new Projectile(projectiletexture, shotbox, target.enemybox));
                lasttime = time;
            }
           
        }

        public void Update(List<Enemy> enemylist)
        {
            foreach (var enemy in enemylist)
            {
                if (enemy.enemybox.X > turretbox.X - range && enemy.enemybox.X < turretbox.X + range + 17 && enemy.enemybox.Y > turretbox.Y - range && enemy.enemybox.Y < turretbox.Y + range + 17)
                {
                    target = enemy;
                    break;
                }
                else { target = null; }
            }
            if (projectiles.Count == 0)
            {
                        return;
            }
            else
            {
                foreach (var shot in projectiles)
                {

                    if (enemylist.Count >= 1)
                    {

                        if (target != null)
                        {
                            shot.Update(target.enemybox);
                            if (target.enemybox.X + 30 >= shot.Position.X && target.enemybox.X <= shot.Position.X && target.enemybox.Y + 30 >= shot.Position.Y && target.enemybox.Y <= shot.Position.Y)
                            {
                                target.Damage(2);
                                projectiles.Remove(shot);

                                if (target.Alive == false)
                                {
                                    projectiles.Clear();
                                }
                                return;
                            }
                        }
                        else
                        {
                            projectiles.Clear();
                            return;
                        }
                        

                    }
                    else
                    {
                        projectiles.Clear();
                        return;
                    }


                   


            }
            }
          

        }

        public void Upgrade(string type)
        {
            switch (type)
            {
                case "damage":


                    break;

                case "range":


                    break;

                case "attackspeed":


                    break;
            }
            
        }
        
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(turretbase, turretbox, Color.White);
            Vector2 barrelbox = new Vector2(turretbox.X + 2, turretbox.Y + 2);
            spritebatch.Draw(turretbarrel, barrelbox, Color.White);

            foreach (var shot in projectiles)
            {
                shot.Draw(spritebatch);
            }
        }
    }
}
