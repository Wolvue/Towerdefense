﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MapBuilder.Classes;
using Towerdefense.Classes;
using Entities.Classes;
using Entities;
using Towerdefense.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Towerdefense
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // walkable player that creates / upgrades the turrets
        Player player;
        //
        Timer timer;
        // class that builds waves
        Wave wave;
        // class that creates ingame gui for building turrets
        IngameGUI ingamegui;
        // class that loads the map
        Map map;

        KeyboardState keyboardstate;







        private Vector2 vector;
        private Vector2 vector2;
        private float rotation;

        private Vector2 vectortt = new Vector2(400,400);
        private Vector2 vectortt2 = new Vector2(450, 400);
        private Vector2 vectortt3 = new Vector2(500, 400);
        private Vector2 vectortt4 = new Vector2(550, 400);

        private List<Turret> turretlist;


        private TurretTextures turrettextures;
        



        public Game()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            wave = new Wave();
            player = new Player(Content.Load<Texture2D>(@"playermodel1"));
            map = new Map(Content.Load<Texture2D>(@"grasstile"), Content.Load<Texture2D>(@"path"), Content.Load<Texture2D>(@"base"), Content.Load<Texture2D>(@"highlight"));
            ingamegui = new IngameGUI(Content.Load<Texture2D>(@"towermenu"));
            // setup for the map, loads all content into the game
            map.Setup();

            PullTextures();

            turretlist = new List<Turret>
            {

                new Turret(turrettextures.Texturebasemetal, turrettextures.Texturebarrelcannon, turrettextures.Textureprojectilecannon, vectortt)
            };








            timer = new Timer();

            // width / height of screen in pixels
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 600;
           // graphics.IsFullScreen = true;
            graphics.ApplyChanges();


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            vector = new Vector2(425, 425);
            vector2 = new Vector2(22, 22);
            rotation = 0.1f;

            







            // TODO: use this.Content to load your game content here



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {


            // TODO: Add your update logic here
            keyboardstate = Keyboard.GetState();
            player.PlayerMovement(keyboardstate, map.turrettiles, turrettextures);
            player.Position(map.turrettiles);

            // spawns next wave if enemies == 0
            wave.SpawnWave(map, gameTime, Content.Load<Texture2D>(@"Enemy1"), Content.Load<Texture2D>(@"healthbarcolor"));

            // makes the enemies move towards the selected waypoint
            wave.MoveEnemies(timer.time);
            wave.CheckAliveEnemy();

            rotation += 0.01f;

            player.Updateturrets(timer.time, wave.enemylist);



            timer.UpdateTimer(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            

            // begins spritebatch
            spriteBatch.Begin();

            // draws all parts needed into the game
            map.Generate(spriteBatch);
            wave.DrawEnemies(spriteBatch);
            player.DrawPlayer(spriteBatch);
            ingamegui.Draw(spriteBatch,turrettextures);
            player.Drawturrets(spriteBatch);

            
          //  spriteBatch.Draw(boxt, vector, null, Color.White, 0,vector2,1f,SpriteEffects.None, 1  );
          //  spriteBatch.Draw(boxt2, vector, null, Color.White, rotation, vector2, 1f, SpriteEffects.None, 1);
            
            //spriteBatch.Draw(boxt2, box1, Color.White);
            

            // ends spritebatch
            spriteBatch.End();
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void PullTextures()
        {
            Texture2D texturebasewood = Content.Load<Texture2D>(@"turretbasewood");
            Texture2D texturebasestone = Content.Load<Texture2D>(@"turretbasestone");
            Texture2D texturebasemetal = Content.Load<Texture2D>(@"turretbasemetal");
            Texture2D texturebasegold = Content.Load<Texture2D>(@"turretbasegold");

            Texture2D texturebarrelspike = Content.Load<Texture2D>(@"turrettopspike");
            Texture2D texturebarrelcannon = Content.Load<Texture2D>(@"turrettopcannon");
            Texture2D texturebarrelarrow = Content.Load<Texture2D>(@"turrettoparrow");
            Texture2D texturebarrelminigun = Content.Load<Texture2D>(@"turrettopminigun");

            Texture2D textureprojectilespike = Content.Load<Texture2D>(@"projectilespike");
            Texture2D textureprojectilecannon = Content.Load<Texture2D>(@"projectilecannonball");
            Texture2D textureprojectilearrow = Content.Load<Texture2D>(@"turretbasewood");
            Texture2D textureprojectileminigun = Content.Load<Texture2D>(@"turretbasewood");


            turrettextures = new TurretTextures(texturebasewood, texturebasestone, texturebasemetal, texturebasegold, texturebarrelspike, texturebarrelcannon, texturebarrelarrow, texturebarrelminigun, textureprojectilespike, textureprojectilecannon, textureprojectilearrow, textureprojectileminigun);
        }
    }
}
