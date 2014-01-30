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
    public class ExplorerIdleWalk : AnimatedSprite, IEntityState
    {
        //Fields

        // explorer 
        private Explorer explorer;
        // vector 2 
        private Vector2 velocity;
        // imageNumber 
        private int imageNumber = 1;
        

        //properties
        public SpriteEffects Effect
        {
            //setter voor effect
            set { this.effect = value; }
        }
        //float rotation
        public float Rotation
        {
            //setter voor rotation
            set { this.rotation = value; }
        }

        //Constructor
        public ExplorerIdleWalk (Explorer explorer) : base(explorer)
        {
            // this explorer
            this.explorer = explorer;
            //nieuwe rectangle
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X, (int)this.explorer.Position.Y, 32, 32);
            //sourcerectangle aangemaakt
            this.sourceRectangle = new Rectangle(this.imageNumber * 32, 0, 32, 32);
            // this.velocity
            this.velocity = new Vector2(this.explorer.Speed, 0f);
            
        }
        //public initialize
        public void Initialize()
        {
            // x as
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            // y as
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }
        //update methode
        public new void Update(GameTime gameTime)
        {
           //Bij het indrukken van de Right knop moet decimal toestand van de explorer veranderen in 
            if (Input.EdgeDetectKeyUp(Keys.Right))
            {
                // state veranderd
                this.explorer.State = this.explorer.Idle;
                // spriteeffect veranderd
                this.explorer.Idle.Effect = SpriteEffects.None;
                //rotation null
                this.explorer.Idle.Rotation = 0f;


            }
            // anders toets left
            else if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                //state
                this.explorer.State = this.explorer.Idle;
                //effect
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                //rotation
                this.explorer.Idle.Rotation = 0f;
                
            }
            // anders toets down
            else if (Input.EdgeDetectKeyUp(Keys.Down))
            {
                //state
                this.explorer.State = this.explorer.Idle;
                //effect
                this.explorer.Idle.Effect = SpriteEffects.None;
                // rotation
                this.explorer.Idle.Rotation = (float)Math.PI / 2;
            }
                //anders toets up
            else if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                //state
                this.explorer.State = this.explorer.Idle;
                //effect
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                //rotation
                this.explorer.Idle.Rotation = (float)Math.PI / 2;
            }
            // Zorgt voor de animatie. Roept de Update(gameTime gameTime method aan van de AnimatedSprite class
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
