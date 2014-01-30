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
    public class ExplorerWalkLeft : AnimatedSprite, IEntityState
    {
        //Fields
        // explorer
        private Explorer explorer;
        // vector 2
        private Vector2 velocity;

        //Constructor
        public ExplorerWalkLeft (Explorer explorer) : base(explorer)
        {
            // explorer 
            this.explorer = explorer;
            // nieuwe rectangle
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X, (int)this.explorer.Position.Y, 32, 32);
            // new vector 2
            this.velocity = new Vector2(this.explorer.Speed, 0f);
            //fliphorizontally
            this.effect = SpriteEffects.FlipHorizontally;
            
        }
        // initialize methode
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
            // min position
             this.explorer.Position -= this.velocity;
            // kleiner dan 16 x
            if (this.explorer.Position.X < 16 )
            {
                // plus position
                this.explorer.Position += this.velocity;
                // idlewalk state
                this.explorer.State = this.explorer.IdleWalk;
                // flip hem
                this.explorer.IdleWalk.Effect = SpriteEffects.FlipHorizontally;
                // rotation is nul
                this.explorer.IdleWalk.Rotation = 0f;
                
            }
           
            //Als de right knop wordt losgelaten, dan moet de explorer weer in de toestand Idle
            if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                // idle state
                this.explorer.State = this.explorer.Idle;
                //flipeffect
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                // rotation is er niet
                this.explorer.Idle.Rotation = 0f;
                
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
