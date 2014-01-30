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

// namespace 
namespace PyramidPanic
{
    // Dit is een toestands class (dus moet hij de interface implenteren
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)
    public class ExplorerWalkDown : AnimatedSprite, IEntityState
    {
        //Fields
        //explorer
        private Explorer explorer;
        // vector 2
        private Vector2 velocity;

        //Constructor
        public ExplorerWalkDown (Explorer explorer) : base(explorer)
        {
            //explorer
            this.explorer = explorer;
            //nieuwe rectangle
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X, (int)this.explorer.Position.Y, 32, 32);
            // nieuwe vector 2
            this.velocity = new Vector2(0f, this.explorer.Speed);
            // rotation
            this.rotation = (float)Math.PI / 2;

            
        }
        // initialize
        public void Initialize()
        {
            // x as
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            // y as
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }
        // update method
        public new void Update(GameTime gameTime)
        {
            // + postion
            this.explorer.Position += this.velocity;
            // groter dan 480 y as
            if (this.explorer.Position.Y > 480 - 16)
            {
                // - postion
                this.explorer.Position -= this.velocity;
                // idle walk
                this.explorer.State = this.explorer.IdleWalk;
                // spriteeffect none
                this.explorer.IdleWalk.Effect = SpriteEffects.None;
                // math pi /2
                this.explorer.IdleWalk.Rotation = (float)Math.PI / 2;
                
            }
           
            //Als de right knop wordt losgelaten, dan moet de explorer weer in de toestand Idle
            if (Input.EdgeDetectKeyUp(Keys.Down))
            {
                // state idle
                this.explorer.State = this.explorer.Idle;
                // spriteeffect none
                this.explorer.Idle.Effect = SpriteEffects.None;
                // math p1 /2
                this.explorer.Idle.Rotation = (float)Math.PI / 2;
                
                
            }
            // base update
            base.Update(gameTime);
        }
        // draw methode
        public new void Draw(GameTime gameTime)
        {
            // draw base
            base.Draw(gameTime);
        }
    }
}
