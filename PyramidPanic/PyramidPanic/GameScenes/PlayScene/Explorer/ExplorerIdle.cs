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
    public class ExplorerIdle : AnimatedSprite, IEntityState
    {
        //Fields
        //explorer
        private Explorer explorer;
        // vector 2
        private Vector2 velocity;
        // imagenumber
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
            // setter voor rotation
            set { this.rotation = value; }
        }

        //Constructor
        public ExplorerIdle (Explorer explorer) : base(explorer)
        {
            // explorer
            this.explorer = explorer;
            // nieuwe rectangle aangemaakt
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X, (int)this.explorer.Position.Y, 32, 32);
            this.sourceRectangle = new Rectangle(this.imageNumber * 32, 0, 32, 32);
            this.velocity = new Vector2(this.explorer.Speed, 0f);
            
        }
        //initialize method
        public void Initialize()
        {
            // x as
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            // y as
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }
        // update methode
        public new void Update(GameTime gameTime)
        {
           //Bij het indrukken van de Right knop moet decimal toestand van de explorer veranderen in 
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                // walkright state
                this.explorer.State = this.explorer.WalkRight;
                //initialize opgeroepen
                this.explorer.WalkRight.Initialize();
            }
            else if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                // walkright state
                this.explorer.State = this.explorer.WalkLeft;
                //initialize opgeroepen
                this.explorer.WalkLeft.Initialize();
            }
            else if (Input.EdgeDetectKeyDown(Keys.Down))
            {
                // walkright state
                this.explorer.State = this.explorer.WalkDown;
                //initialize opgeroepen
                this.explorer.WalkDown.Initialize();
            }
            else if (Input.EdgeDetectKeyDown(Keys.Up))
            {
                // walkright state
                this.explorer.State = this.explorer.WalkUp;
                //initialize opgeroepen
                this.explorer.WalkUp.Initialize();
            }
            
        }
        // draw methode
        public new void Draw(GameTime gameTime)
        {
            // base draw
            base.Draw(gameTime);
        }
    }
}
