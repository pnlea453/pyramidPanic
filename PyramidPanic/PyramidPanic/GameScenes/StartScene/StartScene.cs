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
   public class StartScene : IState // De class StartScene implementeert de interface IState
    {
       //Fields van de class StartScene
       private PyramidePanic game;

       // Maak een variavle (reference) aan van de Image Class genaamd Background
       private Image background;
       private Image title;

       // Maak een variable (reference) aan voor de Menu class
       private Menu menu;

       // Constructor van de StartScene-class krijgt een object game mee van he type PyramidPanic
       public StartScene(PyramidePanic game)
       {
           this.game = game;

           // Roep de Initialize method aan
           this.Intialize();

       }
       // Intialize methode. Deze methode initialiseert (geeft startwaarden aan variabelen)
       // Void wil zeggen dat er niets teruggegeven wordt.
       public void Intialize()
       {
           // Roep de LoadContent method aan
           this.LoadContent();
       }

       // LoadConctent methode. Deze methode maakt nieuwe objecten aan van de verschillende
       // classes.
       public void LoadContent()
       {
           // Nu maken we een object (instantie) van de class Image
           this.background = new Image(this.game, @"StartScene\Background", Vector2.Zero);
           this.title = new Image(this.game, @"StartScene\Title", new Vector2(100f, 30f));
           this.menu = new Menu(this.game);
       }

       //Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
       // en update alle variabelen, methods enz........
       public void Update(GameTime gameTime)
       {
           // Hier wordt de Update Method van het menu object aangeroepen.
           this.menu.Update(gameTime);
       }
       // Draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en
       // tekent de tectures op het canvas.
       public void Draw(GameTime gameTime)
       {

           this.game.GraphicsDevice.Clear(Color.Aquamarine);

           // Roep de Draw methode aan van het background object
           this.background.Draw(gameTime);

           // Roep de Draw methode aan van het title object
           this.title.Draw(gameTime);

           // Roep de Draw methode aan van het neby object
           this.menu.Draw(gameTime);

       }
    }
}
