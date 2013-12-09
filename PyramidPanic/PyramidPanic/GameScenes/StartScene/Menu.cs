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
    public class Menu
    {
        //Fields
        // Maak een enumeration voor de buttons die op het scherm te zien zijn
        private enum Buttons {Start, Load, Help, Scores, Quit }

        // Maak een variable van het type Buttons en geef hem de waarde Buttons.Start
        private Buttons buttonActive = Buttons.Start;


        // Maak een variable (reference) van het type image
        private Image start;
        private Image load;
        private Image help;
        private Image scores;
        private Image quit;


        //Maak een variable (reference) van het type PyramidPanic
        private PyramidePanic game;

        //Constructor
        public Menu(PyramidePanic game)
        {
            this.game = game;
            this.Initialize();
        }



        public void Initialize()
        {
            this.LoadContent();
        }

        public void LoadContent()
        {
            this.start = new Image(this.game, @"StartScene\Button_start", new Vector2(20f, 420f));
            this.load = new Image(this.game, @"StartScene\Button_load", new Vector2(140f, 420f));
            this.help = new Image(this.game, @"StartScene\Button_help", new Vector2(260f, 420f));
            this.scores = new Image(this.game, @"StartScene\Button_scores", new Vector2(380f, 420f));
            this.quit = new Image(this.game, @"StartScene\Button_quit", new Vector2(500f, 420f));
            this.start.Color = Color.Gold;
        }

        //Update
        public void Update(GameTime gameTime)
        {
            // Maak een switch case instructie voor de variabele buttonActive
            switch (this.buttonActive)
            {
                case Buttons.Start:

                    break;
                case Buttons.Load:

                    break;
                case Buttons.Help:

                    break;
                case Buttons.Scores:

                    break;
                case Buttons.Quit:

                    break;

            }
        }



        //Draw
        public void Draw(GameTime gameTime)
        {
            this.start.Draw(gameTime);
            this.load.Draw(gameTime);
            this.help.Draw(gameTime);
            this.scores.Draw(gameTime);
            this.quit.Draw(gameTime);


        }



    }
}
