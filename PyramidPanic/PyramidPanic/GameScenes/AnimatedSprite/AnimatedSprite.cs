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
   public abstract class AnimatedSprite
    {
       //Fields

       //iAnimatedsprite toegevoegd voor de interface classe
       private IAnimatedSprite iAnimatedSprite;

       // privot meegegeven aan vector 2
       private Vector2 pivot;
       
       // protected gemaakt zodat ze ook te benaderen zijn in de andere classe
       protected Rectangle destinationRectangle, sourceRectangle;
       private float timer = 0f;

       // protected gemaakt zodat ze ook te benaderen zijn in de andere classe
       protected SpriteEffects effect;

       // protected gemaakt zodat ze ook te benaderen zijn in de andere classe
       protected int imageNumber = 2; // Loopt vam 0 t/m 3

       // protected gemaakt zodat ze ook te benaderen zijn in de andere classe
       protected float rotation = 0f;

       //De constructor
       public AnimatedSprite(IAnimatedSprite iAnimatedSprite)
       {
           //nieuwe vector 2 meegegeven in de constructor
           this.pivot = new Vector2(16f, 16);

           // Interface classe toegevoegd in de constructor van animatedsprite classe
           this.iAnimatedSprite = iAnimatedSprite;
           this.sourceRectangle = new Rectangle(this.imageNumber * 32, 0, 32, 32);
           
           //spriteeffect staat op None
           this.effect = SpriteEffects.None;
       }

       //Update 
       public void Update(GameTime gameTime)
       {
           // 60 keer per minuut wordt de update method aangeroepen
           if (this.timer > 5 / 60f)
           {
               //als de x as kleiner is dan 96
               if (this.sourceRectangle.X < 96)
               {
                   // plus 32 voor de sprite
                   this.sourceRectangle.X += 32;

               }
               // anders 
               else
               {
                  // geeft 0 terug
                   this.sourceRectangle.X = 0;
               }
               // de timer op 0f gezet
               this.timer = 0f;
           }
           // plus 1 per minuut
           this.timer += 1 / 60f;




       }

       //Draw method van de animatedsprite class
       public void Draw(GameTime gameTime)
       {
          // door de draw methode aanteroepen teken je de opbjecten op het scherm
           this.iAnimatedSprite.Game.SpriteBatch.Draw(this.iAnimatedSprite.Texture,
               // destinationrect en sourcerect aangeven met this
                                      this.destinationRectangle,
                                      this.sourceRectangle,
                                      // er schijnt wit licht
                                      Color.White,
                                      // de rotation is er niet
                                      this.rotation,
                                      this.pivot,
                                      // this. effect voor het effect
                                      this.effect,
                                      0f);
       }
    }
}
