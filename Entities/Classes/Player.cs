using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using MapBuilder.Classes;



namespace Entities.Classes
{

    public class Player : Game
    {
        public Texture2D Playermodel { get; set; }
        public Vector2 Playermodelbox { get; set; }
        public List<Turrettile> Turrettiles { get; set; }
        public List<Turret> Turretlist { get; set; }


        

        public Player(Texture2D playermodel)
        {
            this.Playermodel = playermodel;
            Playermodelbox = new Vector2(400, 300);
            Turretlist = new List<Turret>();
        }

        public void DrawPlayer(SpriteBatch batch)
        {
            batch.Draw(Playermodel, Playermodelbox, Color.White);
        }







        public void Position(List<Turrettile> tiles)
        {
            foreach (var tile in tiles)
            {
                if (tile.tilebox.X <= Playermodelbox.X + 17 && tile.tilebox.Y <= Playermodelbox.Y + 17 && tile.tilebox.X + 50 >= Playermodelbox.X + 17 && tile.tilebox.Y + 50 >= Playermodelbox.Y + 17)
                {
                    tile.Highlighted = true;
                }
                else if (tile.Highlighted == true)
                {
                    tile.Highlighted = false;
                }
            }


        }

        public void Updateturrets(float timer, List<Enemy> enemylist)
        {

                foreach (var tur in Turretlist)
                {
                   tur.Shoot(enemylist, timer);
                   tur.Update(enemylist);
                }
                

        }

        public void Drawturrets(SpriteBatch spriteBatch)
        {

                foreach (var tur in Turretlist)
                {
                    tur.Draw(spriteBatch);
                }

        }

        public void PlayerMovement(KeyboardState currentkeypressed, List<Turrettile> tiles, TurretTextures textures)
        {
            // up
            if (currentkeypressed.IsKeyDown(Keys.W))
            {
                Playermodelbox = new Vector2(Playermodelbox.X, Playermodelbox.Y - 2);
            }
            // left
            if (currentkeypressed.IsKeyDown(Keys.A))
            {
                Playermodelbox = new Vector2(Playermodelbox.X - 2, Playermodelbox.Y);
            }
            // down
            if (currentkeypressed.IsKeyDown(Keys.S))
            {
                Playermodelbox = new Vector2(Playermodelbox.X, Playermodelbox.Y + 2);
            }
            // right
            if (currentkeypressed.IsKeyDown(Keys.D))
            {
                Playermodelbox = new Vector2(Playermodelbox.X + 2, Playermodelbox.Y);
            }

            if (currentkeypressed.IsKeyDown(Keys.Space))
            {
                foreach (var tile in tiles)
                {
                    if (tile.Highlighted == true && tile.Hasturret != true)
                    {
                        Vector2 vector = new Vector2();
                        vector.X = tile.tilebox.X + 5;
                        vector.Y = tile.tilebox.Y + 5;
                        CreateTurret(tile.tilebox, textures);
                        tile.Hasturret = true;

                    }
                }
            }


        }


        public void CreateTurret(Vector2 box, TurretTextures textures)
        {
            Turretlist.Add(new Turret(textures.Texturebasegold, textures.Texturebarrelminigun, textures.Textureprojectileminigun, box));
        }
    }
}
