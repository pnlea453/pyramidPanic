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
   public class Image
    {
       //Fields
       private Texture2D texture;

       // Maak een rectangle voor het detecteren van collisions
       private Rectangle rectangle;

       // Maak een variable aan om de game instantie in op te slaan.
       private PyramidePanic game;


       //Constructor
       public Image(PyramidePanic game, string pathNameAsset, Vector2 postion)
       {
           this.game = game;
           this.texture = game.Content.Load<Texture2D>(pathNameAsset);
           this.rectangle = new Rectangle((int)postion.X,
                                          (int)postion.Y,
                                          this.texture.Width,
                                          this.texture.Height);
       }



       //Update




       //Draw
       public void Draw(GameTime gameTime)
       {

           this.game.SpriteBatch.Draw(this.texture, this.rectangle, Color.White);
        
       }



       //Helper Methods
    }
}
