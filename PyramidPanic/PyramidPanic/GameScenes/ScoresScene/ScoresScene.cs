﻿// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
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
    public class ScoresScene : IState
    {
         //Fields van de class PlayScene
        private PyramidePanic game;

        // Constructor van de StartScene-class krijgt een object game mee van he type PyramidPanic
        public ScoresScene(PyramidePanic game)
        {
            //game instantie
            this.game = game;

        }
        // Intialize methode. Deze methode initialiseert (geeft startwaarden aan variabelen)
        // Void wil zeggen dat er niets teruggegeven wordt.
        public void Intialize()
        {

        }
        // LoadConctent methode. Deze methode maakt nieuwe objecten aan van de verschillende
        // classes.
        public void LoadContent()
        {

        }
        //Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        // en update alle variabelen, methods enz........
        public void Update(GameTime GameTime)
        {
            // toets knop b
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                //scene
                this.game.IState = this.game.StartScene;
            }

        }
        // Draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en
        // tekent de tectures op het canvas.
        public void Draw(GameTime GameTime)
        {
            //achtergrondkleur
            this.game.GraphicsDevice.Clear(Color.Black);

        }
    }
}
