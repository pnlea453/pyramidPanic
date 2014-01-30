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

//Namespace
namespace PyramidPanic
{
    public class Beetle : IAnimatedSprite
    {
        //Fields

        // game istantie meegeven
        private PyramidePanic game;
        // voor de states 
        private IEntityState state;
        // een afbeelding op het scherm is texture
        private Texture2D texture;
        // de snelheid
        private int speed = 2;
        // de positie
        private Vector2 position;

        //Fields

        // walkdon
        private WalkDown walkDown;
        //walkup
        private WalkUp walkUp;

        //Properties

        //get methode voor walkdom
        public WalkDown WalkDown
        {
            // geeft terug de walkdown
            get { return this.walkDown; }
        }
        
        //get methode voor walkup
        public WalkUp WalkUp
        {
            // geeft terug de walkup
            get { return this.walkUp; }
        }

        // vector 2 postion getter en setter
        public Vector2 Position
        {
            // getter en setter
            get { return this.position; }
            set { this.position = value; }
        }
        // ientitystate voor de stare
        public IEntityState State
        {
            // setter value
            set { this.state = value; }
        }

        // game instatie pyramid panic
        public PyramidePanic Game
        {
            // return this. game
            get { return this.game; }
        }
        // int speed 
        public int Speed
        {
            // return the speed
            get { return this.speed; }

        }
        // texture getter
        public Texture2D Texture
        {
            // return this.texture
            get { return this.texture; }
        }

        //Constructor
        public Beetle(PyramidePanic game, Vector2 position)
        {
            // de variable meegegeven in de constructor
            // game
            this.game = game;
            //positie
            this.position = position;
            //texture
            this.texture = game.Content.Load<Texture2D>(@"Beetle\Beetle");
            //walkup nieuwe aangemaakt
            this.walkUp = new WalkUp(this);
            //walkdown nieuwe aangemaakt
            this.walkDown = new WalkDown(this);
            //state
            this.state = this.walkUp;

        }



        //Update
        public void Update(GameTime gameTime)
        {
            // heeft de methode gametime
            this.state.Update(gameTime);

        }



        //Draw
        public void Draw(GameTime gameTime)
        {
            // heeft de methode draw
            this.state.Draw(gameTime);
        }

    }
}

