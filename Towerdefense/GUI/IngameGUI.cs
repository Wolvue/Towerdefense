using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MapBuilder.Classes;

namespace Towerdefense.GUI
{
    class IngameGUI
    {
        private Texture2D towergui;
        public Rectangle towerguibox;
        public IngameGUI(Texture2D towergui)
        {
            this.towergui = towergui;
            towerguibox = new Rectangle(800, 0, 200, 600);
        }

        public void Draw(SpriteBatch batch, TurretTextures turrettextures)
        {
            Vector2 vec;
            batch.Draw(towergui, towerguibox, Color.White);
            batch.Draw(turrettextures.Texturebasewood, (vec = new Vector2(805, 50)),Color.White);
            batch.Draw(turrettextures.Texturebarrelspike, (vec = new Vector2(807, 53)), Color.White);
            batch.Draw(turrettextures.Texturebasewood, (vec = new Vector2(855, 50)), Color.White);
            batch.Draw(turrettextures.Texturebarrelcannon, (vec = new Vector2(857, 53)), Color.White);
            batch.Draw(turrettextures.Texturebasewood, (vec = new Vector2(905, 50)), Color.White);
            batch.Draw(turrettextures.Texturebarrelarrow, (vec = new Vector2(907, 53)), Color.White);
            batch.Draw(turrettextures.Texturebasewood, (vec = new Vector2(955, 50)), Color.White);
            batch.Draw(turrettextures.Texturebarrelminigun, (vec = new Vector2(957, 53)), Color.White);
        }
    }
}
