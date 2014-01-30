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
    public class ExplorerWalkUp : AnimatedSprite, IEntityState
    {
        //Fields
        //explorer
        private Explorer explorer;
        //vector 2 positiie
        private Vector2 velocity;

        //Constructor
        public ExplorerWalkUp (Explorer explorer) : base(explorer)
        {
            // explorer
            this.explorer = explorer;
            // nieuwe rectangle
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X, (int)this.explorer.Position.Y, 32, 32);
            //speed 
            this.velocity = new Vector2(0f, this.explorer.Speed);
            // spriteeffect 
            this.effect = SpriteEffects.FlipHorizontally;
            //rotation
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
        // update
        public new void Update(GameTime gameTime)
        {
            // postion -
            this.explorer.Position -= this.velocity;
            // als het scherm kleiner wordt dan 16
            if (this.explorer.Position.Y < 0 + 16)
            {
                // plus position
                this.explorer.Position += this.velocity;
                // idlewalk state
                this.explorer.State = this.explorer.IdleWalk;
                // spriteeffect veranderd
                this.explorer.IdleWalk.Effect = SpriteEffects.FlipHorizontally;
                // rotation math pi /2
                this.explorer.IdleWalk.Rotation = (float)Math.PI / 2;
                
                
            }
           
            //Als de right knop wordt losgelaten, dan moet de explorer weer in de toestand Idle
            if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                // state idle
                this.explorer.State = this.explorer.Idle;
                // fliphorizontally
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                // rotation pi /2
                this.explorer.Idle.Rotation = (float)Math.PI / 2;
                
                
            }
            // base update
            base.Update(gameTime);
        }
        // draw method
        public new void Draw(GameTime gameTime)
        {
            // base draw
            base.Draw(gameTime);
        }
    }
}
