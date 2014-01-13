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
   public abstract class AnimatedSprite
    {
       //Fields
       private Beetle beetle;
       private Scorpion scorpion;
       protected Rectangle destinationRectangle, sourceRectangle;
       private float timer = 0f;
       protected SpriteEffects effect;

       //De constructor
       public AnimatedSprite(Beetle beetle, Scorpion scorpion)
       {

           this.beetle = beetle;
           this.scorpion = scorpion;
           this.sourceRectangle = new Rectangle(0, 0, 32, 32);
           
           this.effect = SpriteEffects.None;
       }

       //Update 
       public void Update(GameTime gameTime)
       {
           if (this.timer > 5 / 60f)
           {
               if (this.sourceRectangle.X < 96)
               {
                   this.sourceRectangle.X += 32;

               }
               else
               {
                   this.sourceRectangle.X = 0;
               }
               this.timer = 0f;
           }

           this.timer += 1 / 60f;




       }

       //Draw method van de animatedsprite class
       public void Draw(GameTime gameTime)
       {
          
           this.beetle.Game.SpriteBatch.Draw(this.beetle.Texture,
                                      this.destinationRectangle,
                                      this.sourceRectangle,
                                      Color.White,
                                      0f,
                                      Vector2.Zero,
                                      this.effect,
                                      0f);
       }
    }
}
