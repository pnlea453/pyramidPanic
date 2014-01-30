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
    // Dit is een toestands class (dus moet hij de interface implenteren
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)
    public class WalkDown : AnimatedSprite, IEntityState
    {
        //Fields

        //beelte
        private Beetle beetle;
        //vector 2
        private Vector2 velocity;

        //Constructor
        public WalkDown (Beetle beetle) : base(beetle)
        {
            // beetle
            this.beetle = beetle;
            //effect
            this.effect = SpriteEffects.FlipVertically;
            // de positie van de beetle
            this.destinationRectangle = new Rectangle((int)this.beetle.Position.X, (int)this.beetle.Position.Y, 32, 32);
            // nieuwe vector wordt gemaakt
            this.velocity = new Vector2(0f, this.beetle.Speed);
        }
       //initialize method
        public void Initialize()
        {
            //de positie van de beetle op de x as
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            //de positie van de beetle op de y as
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
        }

        //update method
        public new void Update(GameTime gameTime)
        {
            // als de positie van de veetle groter wordt dan 480
            if (this.beetle.Position.Y > 480 - 32  )
            {
                // wordt de toestand veranderd
                this.beetle.State = this.beetle.WalkUp;
                //initialize methode aangeroepen
                this.beetle.WalkUp.Initialize();
            }
            // de vector 2 wordt veranderd
            this.beetle.Position += this.velocity;
            // de positie x
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            // de positie y
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
            // base update
            base.Update(gameTime);
        }
        // draw methode
        public new void Draw(GameTime gameTime)
        {
            //base draw
            base.Draw(gameTime);
        }
    }
}