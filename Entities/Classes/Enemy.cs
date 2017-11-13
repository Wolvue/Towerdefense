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
    public class Enemy : Game
    {
        private float health;
        private float maxhealth;
        private int speed;
        private int damage;
        private int golddrop;
        public bool Alive;

        public Vector2 enemybox;
        private Texture2D enemytexture;
        public List<Rectangle> waypoints;
        private Rectangle headingwaypoint;
        public int waypointindex;

        private Texture2D healthbartexture;


        public Enemy(double health, int speed, int damage, int golddrop , Texture2D enemytexture, Texture2D healthbartexture)
        {
            this.health = (float)health;
            this.maxhealth = (float)health;
            this.speed = speed;
            this.damage = damage;
            this.golddrop = golddrop;
            Alive = true;
            enemybox = new Vector2(60, -50);
            this.enemytexture = enemytexture;
            this.healthbartexture = healthbartexture;
            waypointindex = 0;



        }

        public void Loadwaypoints(List<Rectangle> waypoints)
        {
            this.waypoints = waypoints;
        }

        public void Move()
        {
            headingwaypoint = waypoints[waypointindex];
            if (headingwaypoint.X >= enemybox.X)
            {
                enemybox.X = enemybox.X + speed;
            }
            if (headingwaypoint.Y >= enemybox.Y)
            {
                enemybox.Y = enemybox.Y + speed;
            }
            if (headingwaypoint.X <= enemybox.X)
            {
                enemybox.X = enemybox.X - speed;
            }
            if (headingwaypoint.Y <= enemybox.Y)
            {
                enemybox.Y = enemybox.Y - speed;
            }

            if (headingwaypoint.X + 5 >= enemybox.X && headingwaypoint.X - 5 <= enemybox.X && headingwaypoint.Y + 5 >= enemybox.Y && headingwaypoint.Y - 5 <= enemybox.Y)
            {
                waypointindex++;
            }



        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(enemytexture, enemybox, Color.White);
            
            if (Alive == true)
            {
            float healthpercentage = (health * 30) / maxhealth;
             
            int a = Convert.ToInt32(enemybox.X);
            int b = Convert.ToInt32(enemybox.Y + 35);
            Rectangle healthbarbox = new Rectangle(a,b, (int)healthpercentage, 5);
            batch.Draw(healthbartexture, healthbarbox, Color.Red);
            }

            



        }

        public void Damage(int dmg)
        {
            health -= dmg;
            if (health <= 0)
            {
                Alive = false;
            }
        }
        
    }
}
