using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Mapbuilder.Classes;

namespace MapBuilder.Classes
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Map : Game
    {   
        private Texture2D pathtiletexture;
        private Texture2D turrettiletexture;
        private Texture2D highlight;
        
        
        private List<Pathtile> pathtiles;
        public List<Turrettile> turrettiles;
        public List<Rectangle> waypoints;

        public Mainbase Mainbase
        {
            get;
            set;
        }
        public TurretTextures Turrettexture
        {
            get;
            set;
        }
        

        

        int tileplacementx;
        int tileplacementy;

        public Map(Texture2D turrettiletexture, Texture2D pathtiletexture, Texture2D mainbasetexture, Texture2D highlight)
        {
            this.turrettiletexture = turrettiletexture;
            this.pathtiletexture = pathtiletexture;
            this.highlight = highlight;
            Mainbase = new Mainbase(mainbasetexture);

            pathtiles = new List<Pathtile>();
            turrettiles = new List<Turrettile>();
            waypoints = new List<Rectangle>();
            
    }

        public void LoadTextures()
        {
            //turrettexture = new TurretTextures();
        }

        public void Setup()
        {
            
            Pathcreation();
            TurretTilescreation();
            Waypointscreation();
        }

        private void TurretTilescreation()
        {

                tileplacementy = 0;
                for (int i = 0; i < 12; i++)
                {
                    tileplacementx = 0;

                    for (int j = 0; j < 16; j++)
                    {


                        turrettiles.Add(new Turrettile(tileplacementx, tileplacementy, turrettiletexture, highlight));



                        tileplacementx += 50;
                    }
                    tileplacementy += 50;
                }
        
            foreach (var pathtile in pathtiles)
            {
                foreach (var turtile in turrettiles)
                {
                    if (turtile.tilebox.X == pathtile.tilebox.X && turtile.tilebox.Y == pathtile.tilebox.Y)
                    {
                        turrettiles.Remove(turtile);
                        break;
                    }
                }
            }

        }

        public void Generate(SpriteBatch batch) // draws all the tiles into the field
        {
            
            foreach (var turrettile in turrettiles)
            {
                turrettile.DrawTile(batch);
                if (turrettile.Highlighted == true)
                {
                turrettile.Drawhighlight(batch);
                }
                
                
            }
            foreach (var Pathtile in pathtiles)
            {
                Pathtile.DrawTile(batch);
            }
            

            Mainbase.DrawBase(batch);

        }

        private void Waypointscreation()
        {
            waypoints.Add(new Rectangle(60, 510, 30, 30));
            waypoints.Add(new Rectangle(160, 510, 30, 30));
            waypoints.Add(new Rectangle(160, 410, 30, 30));
            waypoints.Add(new Rectangle(260, 410, 30, 30));
            waypoints.Add(new Rectangle(260, 510, 30, 30));
            waypoints.Add(new Rectangle(410, 510, 30, 30));
            waypoints.Add(new Rectangle(410, 310, 30, 30));
            waypoints.Add(new Rectangle(260, 310, 30, 30));
            waypoints.Add(new Rectangle(260, 160, 30, 30));
            waypoints.Add(new Rectangle(610, 160, 30, 30));
            waypoints.Add(new Rectangle(610, 360, 30, 30));
            waypoints.Add(new Rectangle(760, 360, 30, 30));
        }

        private void Pathcreation()
        {
            pathtiles.Add(new Pathtile(50, 0, pathtiletexture));
            pathtiles.Add(new Pathtile(50, 50, pathtiletexture));
            pathtiles.Add(new Pathtile(50, 100, pathtiletexture));
            pathtiles.Add(new Pathtile(50, 150, pathtiletexture));
            pathtiles.Add(new Pathtile(50, 200, pathtiletexture));
            pathtiles.Add(new Pathtile(50, 250, pathtiletexture));
            pathtiles.Add(new Pathtile(50, 300, pathtiletexture));
            pathtiles.Add(new Pathtile(50, 350, pathtiletexture));
            pathtiles.Add(new Pathtile(50, 400, pathtiletexture));
            pathtiles.Add(new Pathtile(50, 450, pathtiletexture));
            pathtiles.Add(new Pathtile(50, 500, pathtiletexture));
            pathtiles.Add(new Pathtile(100, 500, pathtiletexture));
            pathtiles.Add(new Pathtile(150, 500, pathtiletexture));
            pathtiles.Add(new Pathtile(150, 450, pathtiletexture));
            pathtiles.Add(new Pathtile(150, 400, pathtiletexture));
            pathtiles.Add(new Pathtile(200, 400, pathtiletexture));
            pathtiles.Add(new Pathtile(250, 400, pathtiletexture));
            pathtiles.Add(new Pathtile(250, 450, pathtiletexture));
            pathtiles.Add(new Pathtile(250, 500, pathtiletexture));
            pathtiles.Add(new Pathtile(300, 500, pathtiletexture));
            pathtiles.Add(new Pathtile(350, 500, pathtiletexture));
            pathtiles.Add(new Pathtile(400, 500, pathtiletexture));
            pathtiles.Add(new Pathtile(400, 450, pathtiletexture));
            pathtiles.Add(new Pathtile(400, 400, pathtiletexture));
            pathtiles.Add(new Pathtile(400, 350, pathtiletexture));
            pathtiles.Add(new Pathtile(400, 300, pathtiletexture));
            pathtiles.Add(new Pathtile(350, 300, pathtiletexture));
            pathtiles.Add(new Pathtile(300, 300, pathtiletexture));
            pathtiles.Add(new Pathtile(250, 300, pathtiletexture));
            pathtiles.Add(new Pathtile(250, 250, pathtiletexture));
            pathtiles.Add(new Pathtile(250, 200, pathtiletexture));
            pathtiles.Add(new Pathtile(250, 150, pathtiletexture));
            pathtiles.Add(new Pathtile(300, 150, pathtiletexture));
            pathtiles.Add(new Pathtile(350, 150, pathtiletexture));
            pathtiles.Add(new Pathtile(400, 150, pathtiletexture));
            pathtiles.Add(new Pathtile(450, 150, pathtiletexture));
            pathtiles.Add(new Pathtile(500, 150, pathtiletexture));
            pathtiles.Add(new Pathtile(550, 150, pathtiletexture));
            pathtiles.Add(new Pathtile(600, 150, pathtiletexture));
            pathtiles.Add(new Pathtile(600, 200, pathtiletexture));
            pathtiles.Add(new Pathtile(600, 250, pathtiletexture));
            pathtiles.Add(new Pathtile(600, 300, pathtiletexture));
            pathtiles.Add(new Pathtile(600, 350, pathtiletexture));
            pathtiles.Add(new Pathtile(650, 350, pathtiletexture));
            pathtiles.Add(new Pathtile(700, 350, pathtiletexture));
        }
    }
}
