using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Entities
{

    public class Player : Game
    {
        public Texture2D playermodel;
        public Rectangle playermodelsize;

        public Player()
        {
            playermodelsize = new Rectangle(400,300,25,25);
        }

        public void drawPlayer(SpriteBatch batch)
        {
            batch.Draw(playermodel, playermodelsize, Color.White);
        }
    }
}
