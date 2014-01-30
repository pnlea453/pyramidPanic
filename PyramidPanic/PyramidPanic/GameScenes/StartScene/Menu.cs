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
    //classe naam
    public class Menu
    {
        //Fields
        // Maak een enumeration voor de buttons die op het scherm te zien zijn
        private enum Buttons {Start, Load, Help, Scores, Quit }

        // Maak een variable van het type Buttons en geef hem de waarde Buttons.Start
        private Buttons buttonActive = Buttons.Start;


        // Maak een variable (reference) van het type image
        private Image start;
        // Maak een variable (reference) van het type image
        private Image load;
        // Maak een variable (reference) van het type image
        private Image help;
        // Maak een variable (reference) van het type image
        private Image scores;
        // Maak een variable (reference) van het type image
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
            //game instantie
            this.game = game;
            //initialize 
            this.Initialize();
        }


        // initialize methode
        public void Initialize()
        {
            //loadcontent
            this.LoadContent();
        }

        //loadcontent
        public void LoadContent()
        {
            // Maak een instantie aan van de List<Image>
            this.buttonList = new List<Image>();
            // Maak een instantie aan van de List<Image>
            this.buttonList.Add(this.start = new Image(this.game, @"StartScene\Button_start", new Vector2(20f, 420f)));
            // Maak een instantie aan van de List<Image>
            this.buttonList.Add(this.load = new Image(this.game, @"StartScene\Button_load", new Vector2(140f, 420f)));
            // Maak een instantie aan van de List<Image>
            this.buttonList.Add(this.help = new Image(this.game, @"StartScene\Button_help", new Vector2(260f, 420f)));
            // Maak een instantie aan van de List<Image>
            this.buttonList.Add(this.scores = new Image(this.game, @"StartScene\Button_scores", new Vector2(380f, 420f)));
            // Maak een instantie aan van de List<Image>
            this.buttonList.Add(this.quit = new Image(this.game, @"StartScene\Button_quit", new Vector2(500f, 420f)));
           
           
        }

        //Update
        public void Update(GameTime gameTime)
        {
            
            // Deze if - instructie checked of er op de rechterpijltoets wordt gedrukt.
            // De actie die daarop volgt is het ophogen van de variable buttonActive
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                //buttonactive color
                this.ChangeButtonColorToNormal();
                //active
                this.buttonActive++;
            }

            // Deze if - instructie checked of er op de linkerpijltoets wordt gedrukt.
            // De actie die daarop volgt is het verlagen van de variable buttonActive
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                //buttonactive color
                this.ChangeButtonColorToNormal();
                // niet actief
                this.buttonActive--;
            }
            // mouserect
            if (this.start.Rectangle.Intersects(Input.MouseRect()))
            {
                // mouserect
                if (Input.EdgeDetectMousePressLeft())
                {
                    // playscene state
                    this.game.IState = this.game.PlayScene;
                }
                // change to normal
                this.ChangeButtonColorToNormal();
                // active color
                this.start.Color = this.activeColor;
            }
            // mouserect
            else if (this.load.Rectangle.Intersects(Input.MouseRect()))
            {
                // mouserect
                if (Input.EdgeDetectMousePressLeft())
                {
                    // state veranderen
                    this.game.IState = this.game.LoadScene;
                }
                // change to normal
                this.ChangeButtonColorToNormal();
                // load color
                this.load.Color = this.activeColor;
            }
            // input mouserect
            else if (this.help.Rectangle.Intersects(Input.MouseRect()))
            {
                // mouserect
                if (Input.EdgeDetectMousePressLeft())
                {
                    // mouserect
                    this.game.IState = this.game.HelpScene;
                }
                // naar nornaal veranderen
                this.ChangeButtonColorToNormal();
                // active color veranderen
                this.help.Color = this.activeColor;
            }
            // mouserect
            else if (this.scores.Rectangle.Intersects(Input.MouseRect()))
            {
                // mouserect
                if (Input.EdgeDetectMousePressLeft())
                {
                    // state verander
                    this.game.IState = this.game.ScoresScene;
                }
                //change active color
                this.ChangeButtonColorToNormal();
                // color veranderen
                this.scores.Color = this.activeColor;
            }
                // insert into quit
            else if (this.quit.Rectangle.Intersects(Input.MouseRect()))
            {
                // edgedetectmouseleft
                if (Input.EdgeDetectMousePressLeft())
                {
                    // quitscene
                    this.game.IState = this.game.QuitScene;
                }
                // change to normal
                this.ChangeButtonColorToNormal();
                // active color
                this.quit.Color = this.activeColor;
            }
            // anders
            else
            {
                // change to normal
                this.ChangeButtonColorToNormal();

                // Maak een switch case instructie voor de variabele buttonActive
                switch (this.buttonActive)
                {
                    case Buttons.Start:

                        // De Ternary operator: variabele = () ? Waarde als waar : waarde als niet waar
                        this.game.IState = (Input.EdgeDetectKeyDown(Keys.Enter))
                            ? (IState)this.game.PlayScene : this.game.StartScene;
                        this.start.Color = this.activeColor;
                        break;
                        //case load
                    case Buttons.Load:
                        // press enter
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            //loadscene
                            this.game.IState = this.game.LoadScene;
                        }
                        //activeColor
                        this.load.Color = this.activeColor;
                        //stop
                        break;
                        // case help
                    case Buttons.Help:
                        // press enter
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            // helpscene scene
                            this.game.IState = this.game.HelpScene;
                        }
                        // change active color
                        this.help.Color = this.activeColor;
                        //stop
                        break;
                        //case quit
                    case Buttons.Scores:
                        // press enter
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            //scorescene
                            this.game.IState = this.game.ScoresScene;
                        }
                        // activ color
                        this.scores.Color = this.activeColor;
                        break;
                        // case quit
                    case Buttons.Quit:
                        // press enter
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            //quitscene
                            this.game.IState = this.game.QuitScene;
                        }
                        // quit color
                        this.quit.Color = this.activeColor;
                        break;

                }
            }
        }



        //Draw
        public void Draw(GameTime gameTime)
        {
            // voor elke image wordt de draw method aangeroepen
            foreach (Image image in this.buttonList)
            {
                // image draw
                image.Draw(gameTime);
            }

        }

        /* Helper method voor het met wit licht beschijnen van de buttons
         */
        private void ChangeButtonColorToNormal()
        {
            /* We doorlopen het this.buttonlist object (type list<image>) met een foreach instructie
            * en we roepen voor ieder image object de propertie Color op en geven deze 
            * de waarde Color.White.
            */
            foreach (Image image in this.buttonList)
            {
                //image color white
                image.Color = Color.White;
            }
        }

    }
}
