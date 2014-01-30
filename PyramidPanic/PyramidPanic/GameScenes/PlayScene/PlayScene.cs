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

// namespace
namespace PyramidPanic
{
    public class PlayScene : IState // De class PlayScene implementeert de interface IState
    {
        //Fields van de class PlayScene

        // game instantie
        private PyramidePanic game;
        //scorpion
        private Scorpion scorpion, scorpion1;
        //beetle
        private Beetle beetle, beetle1;
        //explorer
        private Explorer explorer;
        //block
        private Block block1 , blockhor, blockvert, door, wall1, wall2;
        
        

        // Constructor van de StartScene-class krijgt een object game mee van he type PyramidPanic
        public PlayScene(PyramidePanic game)
        {
            //game instantie 
            this.game = game;
            //initialize
            this.Intialize();
        }
        // Intialize methode. Deze methode initialiseert (geeft startwaarden aan variabelen)
        // Void wil zeggen dat er niets teruggegeven wordt.
        public void Intialize()
        {
            //loadcontent
            this.LoadContent();
        }
        // LoadConctent methode. Deze methode maakt nieuwe objecten aan van de verschillende
        // classes.
        public void LoadContent()
        {
            //nieuwe scorpion
            this.scorpion = new Scorpion(this.game, new Vector2(300f,188f));
            //nieuwe scorpion
            this.scorpion1 = new Scorpion(this.game, new Vector2(350f, 238f));
            //nieuwe beetle
            this.beetle = new Beetle(this.game, new Vector2(100f, 300f));
            //nieuwe beetle
            this.beetle1 = new Beetle(this.game, new Vector2(150f, 350f));
            //nieuwe explorer
            this.explorer = new Explorer(this.game, new Vector2(304f, 240f));
            //nieuwe block
            this.block1 = new Block(this.game, @"Block\Block", new Vector2(0f, 0f));
            //nieuwe block
            this.blockhor = new Block(this.game, @"Block\Block_hor", new Vector2(32f, 0f));
            //nieuwe block
            this.blockvert = new Block(this.game, @"Block\Block_vert", new Vector2(64f, 0f));
            //nieuwe block
            this.door = new Block(this.game, @"Block\Door", new Vector2(96f, 0f));
            //nieuwe block
            this.wall1 = new Block(this.game, @"Block\Wall1", new Vector2(128, 0f));
            //nieuwe block
            this.wall2 = new Block(this.game, @"Block\Wall2", new Vector2(160, 0f));



            
        }
        //Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        // en update alle variabelen, methods enz........
        public void Update(GameTime gameTime)
        {
            //toets knop b
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                //gaat naar startscene
                this.game.IState = this.game.StartScene;
            }
            //update scorpion
            this.scorpion1.Update(gameTime);
            //update scorpion
            this.scorpion.Update(gameTime);
            //update beetle
            this.beetle.Update(gameTime);
            //update beetle
            this.beetle1.Update(gameTime);
            //update explorer
            this.explorer.Update(gameTime);
            
           
        }
        // Draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en
        // tekent de tectures op het canvas.
        public void Draw(GameTime gameTime)
        {
            //achtergrondkleur
            this.game.GraphicsDevice.Clear(Color.Pink);
            //draw scorpion
            this.scorpion.Draw(gameTime);
            //draw scorpion
            this.scorpion1.Draw(gameTime);
            //draw beetle
            this.beetle.Draw(gameTime);
            //draw beetle
            this.beetle1.Draw(gameTime);
            //draw explorer
            this.explorer.Draw(gameTime);
            //draw block
            this.blockhor.Draw(gameTime);
            //draw block
            this.blockvert.Draw(gameTime);
            //draw block
            this.block1.Draw(gameTime);
            //draw block
            this.door.Draw(gameTime);
            //draw block
            this.wall1.Draw(gameTime);
            //draw block
            this.wall2.Draw(gameTime);

           

        }
    }
}
