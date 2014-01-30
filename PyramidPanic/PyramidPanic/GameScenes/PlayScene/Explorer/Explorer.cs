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
    // classe naam
    public class Explorer : IAnimatedSprite
    {
        //Fields
        // game 
        private PyramidePanic game;
        // state
        private IEntityState state;
        //texture
        private Texture2D texture;
        //int 
        private int speed = 2;
        //position vector 2
        private Vector2 position;

        // Maak van iedere toestand (state) een field
        //private ExplorerWalkUp walkUp;
        private ExplorerWalkDown walkDown;
        //private ExplorerWalkUp walkUp;
        private ExplorerWalkUp walkUp;
        //private ExplorerWalkUp walkUp;
        private ExplorerWalkLeft walkLeft;
        //private ExplorerWalkUp walkUp;
        private ExplorerWalkRight walkRight;
        //private ExplorerWalkUp walkUp;
        private ExplorerIdle idle;
        //private ExplorerWalkUp walkUp;
        private ExplorerIdleWalk idlewalk;

        //Properties
        
        /*public ExplorerWalkUp WalkUp
        {
            get { return this.walkUp; }
        }
        */
        //public ExplorerWalkUp WalkUp
        public ExplorerWalkDown WalkDown
        {
            //get { return this.walkUp; }
            get { return this.walkDown; }
        }
        //public ExplorerWalkUp WalkUp
        public ExplorerWalkUp WalkUp
        {
            //get { return this.walkUp; }
            get { return this.walkUp; }
        }
        //public ExplorerWalkUp WalkUp
        public ExplorerWalkRight WalkRight
        {
            //get { return this.walkUp; }
            get { return this.walkRight; }
        }
        //public ExplorerWalkUp WalkUp
        public ExplorerIdle Idle
        {
            //get { return this.walkUp; }
            get { return this.idle; }
        }
        //public ExplorerWalkUp WalkUp
        public ExplorerIdleWalk IdleWalk
        {
            //get { return this.walkUp; }
            get { return this.idlewalk; }
        }
        //public ExplorerWalkUp WalkUp
        public ExplorerWalkLeft WalkLeft
        {
            //get { return this.walkUp; }
            get { return this.walkLeft; }
        }
        //public ExplorerWalkUp WalkUp
        public Vector2 Position
        {
            //get { return this.walkUp; }
            get { return this.position; }
            //get { return this.walkUp; }
            set { this.position = value;
                //initialize method
            this.state.Initialize();
            }
        }
        //public ExplorerWalkUp WalkUp
        public IEntityState State
        {
            //set
            set
            {
            this.state = value;
            this.state.Initialize();
            }
        }
        //public ExplorerWalkUp WalkUp
        public PyramidePanic Game
        {
            // rerturn this
            get { return this.game; }
        }
        //public ExplorerWalkUp WalkUp
        public int Speed
        {
            // rerturn this 
            get { return this.speed; }

        }
        //public ExplorerWalkUp WalkUp
        public Texture2D Texture
        {
            // rerturn this
            get { return this.texture; }
        }

        //Constructor
        public Explorer (PyramidePanic game, Vector2 position) 
        {
            //game
            this.game = game;
            // position
            this.position = position;
            //load explorer
            this.texture = game.Content.Load<Texture2D>(@"Explorer\Explorer");
            //this.walkUp = new ExplorerWalkUp(this);
            this.walkDown = new ExplorerWalkDown(this);
            //this.walkUp = new ExplorerWalkUp(this);
            this.walkUp = new ExplorerWalkUp(this);
            //this.walkUp = new ExplorerWalkUp(this);
            this.walkRight = new ExplorerWalkRight(this);
            //this.walkUp = new ExplorerWalkUp(this);
            this.walkLeft = new ExplorerWalkLeft(this);
            //this.walkUp = new ExplorerWalkUp(this);
            this.idle = new ExplorerIdle(this);
            //this.walkUp = new ExplorerWalkUp(this);
            this.idlewalk = new ExplorerIdleWalk(this);
            //this.walkUp = new ExplorerWalkUp(this);
            this.state = this.idle;

        }



        //Update
        public void Update(GameTime gameTime)
        {
            //this.walkUp = new ExplorerWalkUp(this);
            this.state.Update(gameTime);

        }



        //Draw
        public void Draw(GameTime gameTime)
        {
            // base . draw
            this.state.Draw(gameTime);
        }

    }
}
