// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class PyramidePanic : Microsoft.Xna.Framework.Game
    {
        //Fields 
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        

        // Maak een variabele aan van het type StartScene 
        private StartScene startScene;

        // Maak een variabele aan van het type PlayScene 
        private PlayScene playScene;

        // Maak een variabele aan van het type HelpScene 
        private HelpScene helpscene;

        // Maak een variabele aan van het type GameOverScene
        private GameOverScene GameOverScene;

        // Dit is de constructor. heeft altijd dezelfde naam als de class
        public PyramidePanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
           // Verander de titel van het canvas
            Window.Title = "Pyramid Panic Beta 00.00.00.01";

           // Maakt de muis zichtbaar 
            IsMouseVisible = true;

           // Verandert de breedte van het canvas
            this.graphics.PreferredBackBufferWidth = 640;

          // Verandert de hoogte van het canvas
            this.graphics.PreferredBackBufferHeight = 480;

          // Past de nieuwe hoogte en breedte toe
            this.graphics.ApplyChanges();

            base.Initialize();
        }

     
        protected override void LoadContent()
        {
          // Een spritebatch is nodig voor het tekenen van tetures op het canvas
            spriteBatch = new SpriteBatch(GraphicsDevice);

          // We maken nu het object/instantie aan van het type StartScene. Dit doe je door
          // de constructor aan te roepen van de StartScene class.
            this.startScene = new StartScene(this);
            this.playScene = new PlayScene(this);
            this.helpscene = new HelpScene(this);
            this.GameOverScene = new GameOverScene(this);
        }

       
        protected override void UnloadContent()
        {
          
        }

        
        protected override void Update(GameTime gameTime)
        {
            // Zorgt dat het spel stopt wanneer je op de gamepad button Back indrukt
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) || 
                (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();
           
            
            // Roep de Update methode aan van de StartScene class
            this.startScene.Update();

            // Roep de Update methode aan van de PlayScene class
            this.playScene.Update();

            // Roep de Update methode aan van de HelpScene class
            this.helpscene.Update();

            // Roep de Update methode aan van de gameOverScene class
            this.GameOverScene.Update();
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            // Geeft de achtergrond een kleur
            GraphicsDevice.Clear(Color.Black);
            
            // Voor een spriteBatch instantie iets kan tekenen moet de Begin() methode 
            // aangeroepen worden
            this.spriteBatch.Begin();

            // Roep de Draw methode aan van de StartScene class
            this.startScene.Draw();

            // Roep de Draw methode aan van de playScene class
            this.playScene.Draw();

            // Roep de Draw methode aan van de helpScene class
            this.helpscene.Draw();

            // Roep de Draw methode aan van de GameOverScene class
            this.GameOverScene.Draw();


            // Nadat de spriteBatch.Draw() is aangeroepen moet de End() methode van de 
            // SpriteBatch class worden aangeroepen
            this.spriteBatch.End();

        

            base.Draw(gameTime);
        }
    }
}
