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
       // Maak een variable (reference) aam vam het type Texture2D met de naam texture
       private Texture2D texture;

       // maak een variable (reference) aan van het type Color met de naam color
       private Color color = Color.White;

       // Maak een rectangle voor het detecteren van collisions
       private Rectangle rectangle;

       // Maak een variable aan om de game instantie in op te slaan.
       private PyramidePanic game;


      //Properties
      // Maak een property voor het color field
       public Color Color
       {
           get { return this.color; }
           set { this.color = value; }

       }
       


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

           this.game.SpriteBatch.Draw(this.texture, this.rectangle, this.color);
        
       }



       //Helper Methods
    }
}
