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
   public class WalkUp : AnimatedSprite, IEntityState
    {
       //Fields

       //beetle
       private Beetle beetle;
       //vector 2
       private Vector2 velocity;

       //Constructor
       public WalkUp(Beetle beetle) : base(beetle)
       {
           // beetle
           this.beetle = beetle;
           // nieuwe rectangle 
           this.destinationRectangle = new Rectangle((int)this.beetle.Position.X,(int)this.beetle.Position.Y, 32, 32);
           // de positie veranderd
           this.velocity = new Vector2(0f, this.beetle.Speed);
       }
       // initialze methode
       public void Initialize()
       {
           //positie x as
           this.destinationRectangle.X = (int)this.beetle.Position.X;
           // positie y as
           this.destinationRectangle.Y = (int)this.beetle.Position.Y;
       }
       
       //update method
        public new void Update(GameTime gameTime)
        {
            // als de positie kleiner wordt dan 0
            if (this.beetle.Position.Y <0 + 16)
            {
                // state veranderd dan
                this.beetle.State = this.beetle.WalkDown;
                // initialize methode veranderd
                this.beetle.WalkDown.Initialize();
            }
            // positie gaat eraf
            this.beetle.Position -= this.velocity;
            // x positie
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            // y positie
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
            //base update
            base.Update(gameTime);
        }
       //draw methode
        public new void Draw(GameTime gameTime)
        {
            //base draw
            base.Draw(gameTime); 
        }
    }
}
