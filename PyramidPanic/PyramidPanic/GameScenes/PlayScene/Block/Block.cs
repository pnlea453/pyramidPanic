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
    public class Block : Image
    {
        //Fields



        //Properties



        //constructor
        public Block(PyramidePanic game, string pathNameAsset, Vector2 postion) : base (game, pathNameAsset, postion )
       {

       }

        //Update
        


        //Draw 
        public void Draw(GameTime gameTime)
        {
            // base draw
            base.Draw(gameTime);
        }
    }
}
