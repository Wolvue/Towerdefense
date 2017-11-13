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
        private Texture2D upgradebar;
        private Texture2D upgradebarfill;
        public Rectangle towerguibox;
        private SpriteFont spriteFont;
        public IngameGUI(Texture2D towergui, Texture2D upgradebar, Texture2D upgradebarfill, SpriteFont spriteFont)
        {
            this.towergui = towergui;
            this.upgradebar = upgradebar;
            this.upgradebarfill = upgradebarfill;
            this.spriteFont = spriteFont;
            towerguibox = new Rectangle(800, 0, 200, 600);
        }

        public void Draw(SpriteBatch batch, TurretTextures turrettextures)
        {
            Vector2 vec;
            batch.Draw(towergui, towerguibox, Color.White);
            batch.Draw(turrettextures.Texturebasewood, (new Vector2(805, 50)),Color.White);
            batch.Draw(turrettextures.Texturebarrelspike, (new Vector2(807, 53)), Color.White);
            batch.Draw(turrettextures.Texturebasewood, (new Vector2(855, 50)), Color.White);
            batch.Draw(turrettextures.Texturebarrelcannon, (new Vector2(857, 53)), Color.White);
            batch.Draw(turrettextures.Texturebasewood, (new Vector2(905, 50)), Color.White);
            batch.Draw(turrettextures.Texturebarrelarrow, (new Vector2(907, 53)), Color.White);
            batch.Draw(turrettextures.Texturebasewood, (new Vector2(955, 50)), Color.White);
            batch.Draw(turrettextures.Texturebarrelminigun, (new Vector2(957, 53)), Color.White);
            batch.Draw(upgradebarfill, (new Rectangle(810, 156,152,25)), Color.White);
            batch.Draw(upgradebar, (new Vector2(810, 156)), Color.White);
            batch.DrawString(spriteFont, "Test number 5671", new Vector2(815, 106), Color.Black);
        }
    }
}
