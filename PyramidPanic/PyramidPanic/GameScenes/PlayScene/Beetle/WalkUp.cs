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


namespace PyramidPanic
{
    // Dit is een toestands class (dus moet hij de interface implenteren
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)

   public class WalkUp : AnimatedSprite, IEntityState
    {
       //Fields
       private Beetle beetle;

       //Constructor
       public WalkUp(Beetle beetle) : base(beetle)
       {
           this.beetle = beetle;
           this.destinationRectangle = new Rectangle((int)this.beetle.Position.X,(int)this.beetle.Position.Y, 32, 32);
       }

       public void Initialize()
       {
           this.destinationRectangle.X = (int)this.beetle.Position.X;
           this.destinationRectangle.Y = (int)this.beetle.Position.Y;
       }
       

        public new void Update(GameTime gameTime)
        {
            if (this.beetle.Position.Y < 0)
            {
                this.beetle.State = this.beetle.WalkDown;
                this.beetle.WalkDown.Initialize();
            }
            this.beetle.Position -= new Vector2(0f, this.beetle.Speed);
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime); 
        }
    }
}
