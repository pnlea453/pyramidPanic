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

//Namespace
namespace PyramidPanic
{
    // Dit is een toestands class (dus moet hij de interface implenteren
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)

    public class WalkLeft : AnimatedSprite, IEntityState
    {
        //Fields

        //scorpion variable
        private Scorpion scorpion;
        //vector 2 variable
        private Vector2 velocity;
             

        //Constructor
        public WalkLeft(Scorpion scorpion) : base(scorpion)
        {
            // scorpion
            this.scorpion = scorpion;
            // effect veranderd flipt
            this.effect = SpriteEffects.FlipHorizontally;
            // nieuwe rectangle 
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X, (int)this.scorpion.Position.Y, 32, 32);
            //nieuwew postion vector 2
            this.velocity = new Vector2(this.scorpion.Speed, 0f);
        }
        //initialize method
        public void Initialize()
        {
            //x positie
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            //y positie
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
        }
        //update method
        public new void Update(GameTime gameTime)
        {
            // als de x kleiner is dan 0
            if (this.scorpion.Position.X < this.scorpion.LeftBorder )
            {
                // nieuwe state wordt aangeroepen
                this.scorpion.State = new WalkRight(this.scorpion);
                //initialize
                this.scorpion.WalkRight.Initialize();
            }
            // vector 2 gaat ervanaf
            this.scorpion.Position -= this.velocity;
            // x positie
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            // y positie
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
            //base update
            base.Update(gameTime);
        }
        //draw method
        public new void Draw(GameTime gameTime)
        {
            //base draw
            base.Draw(gameTime);
        }
    }
}
