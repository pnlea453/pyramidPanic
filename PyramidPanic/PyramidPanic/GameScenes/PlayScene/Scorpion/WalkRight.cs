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

    public class WalkRight : AnimatedSprite, IEntityState
    {
        //Fields

        //scorpion
        private Scorpion scorpion;
        //vector 2
        private Vector2 velocity;

        //Constructor
        public WalkRight (Scorpion scorpion) : base(scorpion)
        {
            //scorpion
            this.scorpion = scorpion;
            //nieuwe rectangle
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X, (int)this.scorpion.Position.Y, 32, 32);
            //nieuwe vector 2
            this.velocity = new Vector2(this.scorpion.Speed, 0f);
        }
        // initialize methode 
        public void Initialize()
        {
            // x positie
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            // y positie
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
        }
        // update methode
        public new void Update(GameTime gameTime)
        {
            // als de x groter wordt dan 640
            if (this.scorpion.Position.X > 640 - 16)
            {
                // walkleft state
                this.scorpion.State = new WalkLeft(this.scorpion);
                //initialize methode
                this.scorpion.WalkLeft.Initialize();
            }
            // vector 2 komt erbij
            this.scorpion.Position += this.velocity;
            // positie x
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            //positie y
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
            //base update
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
