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
        public Texture2D playermodel;
        public Vector2 playermodelbox;
        public List<Turrettile> turrettiles;
        public List<Turret> turretlist;


        

        public Player(Texture2D playermodel)
        {
            this.playermodel = playermodel;
            playermodelbox = new Vector2(400, 300);
            turretlist = new List<Turret>();
        }

        public void DrawPlayer(SpriteBatch batch)
        {
            batch.Draw(playermodel, playermodelbox, Color.White);
        }







        public void Position(List<Turrettile> tiles)
        {
            foreach (var tile in tiles)
            {
                if (tile.tilebox.X <= playermodelbox.X + 17 && tile.tilebox.Y <= playermodelbox.Y + 17 && tile.tilebox.X + 50 >= playermodelbox.X + 17 && tile.tilebox.Y + 50 >= playermodelbox.Y + 17)
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

                foreach (var tur in turretlist)
                {
                   tur.Shoot(enemylist, timer);
                   tur.Update(enemylist);
                }
                

        }

        public void Drawturrets(SpriteBatch spriteBatch)
        {

                foreach (var tur in turretlist)
                {
                    tur.Draw(spriteBatch);
                }

        }

        public void PlayerMovement(KeyboardState currentkeypressed, List<Turrettile> tiles, TurretTextures textures)
        {
            // up
            if (currentkeypressed.IsKeyDown(Keys.W))
            {
                playermodelbox = new Vector2(playermodelbox.X, playermodelbox.Y - 2);
            }
            // left
            if (currentkeypressed.IsKeyDown(Keys.A))
            {
                playermodelbox = new Vector2(playermodelbox.X - 2, playermodelbox.Y);
            }
            // down
            if (currentkeypressed.IsKeyDown(Keys.S))
            {
                playermodelbox = new Vector2(playermodelbox.X, playermodelbox.Y + 2);
            }
            // right
            if (currentkeypressed.IsKeyDown(Keys.D))
            {
                playermodelbox = new Vector2(playermodelbox.X + 2, playermodelbox.Y);
            }

            if (currentkeypressed.IsKeyDown(Keys.Enter))
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
            turretlist.Add(new Turret(textures.Texturebasestone, textures.Texturebarrelspike, textures.Textureprojectilespike, box));
        }
    }
}
