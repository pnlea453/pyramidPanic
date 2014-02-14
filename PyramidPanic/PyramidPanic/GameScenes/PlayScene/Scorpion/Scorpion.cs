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

//namespace 
namespace PyramidPanic
{
    //classe naam
    public class Scorpion : IAnimatedSprite
    {
        //Fields

        // game instantie
        private PyramidePanic game;
        // ietitystate state
        private IEntityState state;
        //texture 2d
        private Texture2D texture;
        // speed veranderen
        private int speed = 2;
        //vector 2 position veranderen
        private Vector2 position;

        //Fields

        //walkleft
        private WalkLeft walkLeft;
        //walkright
        private WalkRight walkRight;

        private int rightBorder;
        private int leftBorder;
        private Rectangle collisionRect;

        //Properties
        public int RightBorder
        {
            get { return this.rightBorder; }
            set { this.rightBorder = value; }
        }
        public int LeftBorder
        {
            get { return this.leftBorder; }
            set { this.leftBorder = value; }
        }
        public Rectangle CollisionRect
        {
            get {
                this.collisionRect.X = (int)this.position.X;
                this.collisionRect.Y = (int)this.position.Y;
                return this.collisionRect; }
        }

        //getter voor walkleft
        public WalkLeft WalkLeft
        {
            // return walkleft
            get { return this.walkLeft; }
        }
        //getter voor walkright
        public WalkRight WalkRight
        {
            //return walkright
            get { return this.walkRight; }
        }
        //getter en setter voor position
        public Vector2 Position
        {
            //getter voor positie
            get { return this.position; }
            //setter
            set { this.position = value; }
        }
        //setter voor de state
        public IEntityState State
        {
            //verander de value
            set { this.state = value; }
        }
        // game instatie
        public PyramidePanic Game
        {
            //return de game instantie
            get { return this.game; }
        }
        // de speed instantie
        public int Speed
        {
            // return speed
            get { return this.speed; }

        }
        // texture 
        public Texture2D Texture
        {
            //return texture
            get { return this.texture; }
        }

        //Constructor
        public Scorpion(PyramidePanic game, Vector2 position)
        {
            // game
            this.game = game;
            // positie
            this.position = position;
            //plaatje wordt geload
            this.texture = game.Content.Load<Texture2D>(@"Scorpion\Scorpion");
            //walkleft
            this.walkLeft = new WalkLeft(this);
            //walkright
            this.walkRight = new WalkRight(this);
            //state classe
            this.state = this.walkRight;
            this.collisionRect = new Rectangle((int)this.position.X,(int)this.position.Y, 32, 32);
           

        }



        //Update
        public void Update(GameTime gameTime)
        {
            // gametime meegeven aan update
            this.state.Update(gameTime);

        }



        //Draw
        public void Draw(GameTime gameTime)
        {
            // gamtime meegeven aan draw
            this.state.Draw(gameTime);
            
        }

    }
}

