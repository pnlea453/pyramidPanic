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
    public class ExplorerWalkRight : AnimatedSprite, IEntityState
    {
        //Fields
        //explorer
        private Explorer explorer;
        // vector 2
        private Vector2 velocity;

        //Constructor
        public ExplorerWalkRight (Explorer explorer) : base(explorer)
        {
            // explorer
            this.explorer = explorer;
            // destionrectangle
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X, (int)this.explorer.Position.Y, 32, 32);
            // nieuwe vector 2
            this.velocity = new Vector2(this.explorer.Speed, 0f);

            
        }
        // initialize methode
        public void Initialize()
        {
            // x as
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            // y as
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }
        // nieuwe update
        public new void Update(GameTime gameTime)
        {
            // plus position
            this.explorer.Position += this.velocity;
            // als de x groter wordt dan 640
            if (this.explorer.Position.X > 640 - 16)
            {
                // this. explorer
                this.explorer.Position -= this.velocity;
                // state idlewalk
                this.explorer.State = this.explorer.IdleWalk;
                // spriteeffect veranderd in none
                this.explorer.IdleWalk.Effect = SpriteEffects.None;
                // rotation 0f
                this.explorer.IdleWalk.Rotation = 0f;
                
            }
           
            //Als de right knop wordt losgelaten, dan moet de explorer weer in de toestand Idle
            if (Input.EdgeDetectKeyUp(Keys.Right))
            {
                // state idle
                this.explorer.State = this.explorer.Idle;
                // spriteeffect none
                this.explorer.Idle.Effect = SpriteEffects.None;
                // geen rotation
                this.explorer.Idle.Rotation = 0f;
            }
            // base update
            base.Update(gameTime);
        }
        // draw methode
        public new void Draw(GameTime gameTime)
        {
            // base draw
            base.Draw(gameTime);
        }
    }
}
