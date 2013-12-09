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

        // ActiveColor
        private Color activeColor = Color.Gold;

        // Maak een variabele van het type List <Image>
        private List<Image> buttonList;

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
            // Maak een instantie aan van de List<Image>
            this.buttonList = new List<Image>();
            this.buttonList.Add(this.start = new Image(this.game, @"StartScene\Button_start", new Vector2(20f, 420f)));
            this.buttonList.Add(this.load = new Image(this.game, @"StartScene\Button_load", new Vector2(140f, 420f)));
            this.buttonList.Add(this.help = new Image(this.game, @"StartScene\Button_help", new Vector2(260f, 420f)));
            this.buttonList.Add(this.scores = new Image(this.game, @"StartScene\Button_scores", new Vector2(380f, 420f)));
            this.buttonList.Add(this.quit = new Image(this.game, @"StartScene\Button_quit", new Vector2(500f, 420f)));
           
           
        }

        //Update
        public void Update(GameTime gameTime)
        {
            
            // Deze if - instructie checked of er op de rechterpijltoets wordt gedrukt.
            // De actie die daarop volgt is het ophogen van de variable buttonActive
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.buttonActive++;
            }

            // Deze if - instructie checked of er op de linkerpijltoets wordt gedrukt.
            // De actie die daarop volgt is het verlagen van de variable buttonActive
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.buttonActive--;
            }

            /* We doorlopen het this.buttonlist object (type list<image>) met een foreach instructie
             * en we roepen voor ieder image object de propertie Color op en geven deze 
             * de waarde Color.White.
             */
            foreach (Image image in this.buttonList)
            {
                image.Color = Color.White;
            }


            // Maak een switch case instructie voor de variabele buttonActive
            switch (this.buttonActive)
            {
                case Buttons.Start:
                    this.start.Color = this.activeColor;
                    break;
                case Buttons.Load:
                    this.load.Color = this.activeColor;
                    break;
                case Buttons.Help:
                    this.help.Color = this.activeColor;
                    break;
                case Buttons.Scores:
                    this.scores.Color = this.activeColor;
                    break;
                case Buttons.Quit:
                    this.quit.Color = this.activeColor;
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
