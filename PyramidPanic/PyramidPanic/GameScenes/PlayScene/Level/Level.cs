// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class Level
    {
        //Fields
        private PyramidePanic game;
        private int levelIndex;
        private Stream stream;
        private List<String> lines;
        private Block[,] blocks;
        private Image background;
        private Explorer explorer;
        private List<Scorpion> scorpions;
        private List<Beetle> beetles;
        private List<Image> treasures;
        //Properties
        public PyramidePanic Game
        {
            get { return this.game; }
        }
        public int LevelIndex
        {
            get { return this.levelIndex; }
        }

        //Constructor
        public Level(PyramidePanic game, int levelIndex)
        {
            this.game = game;
            this.levelIndex = levelIndex;

            // ladd het textbestand
            this.stream = TitleContainer.OpenStream(@"Content\Level\0.txt");
            this.LoadAssets();

        }



        //Update
        public void Update(GameTime gameTime)
        {
            foreach (Scorpion scorpion in this.scorpions)
            {
                scorpion.Update(gameTime);
            }
            foreach (Beetle beetle in this.beetles)
            {
                beetle.Update(gameTime);
            }
            this.explorer.Update(gameTime);
        }


        //Draw
        public void Draw(GameTime gameTime)
        {
            this.background.Draw(gameTime);
            for (int row = 0; row < this.blocks.GetLength(1); row++)
            {
                for (int column = 0; column < this.blocks.GetLength(0); column++)
                {
                    this.blocks[column, row].Draw(gameTime);
                }
            }
            
            foreach (Image treasures in this.treasures)
            {
                treasures.Draw(gameTime);

            }
            foreach (Scorpion scorpion in this.scorpions)
            {
                scorpion.Draw(gameTime);

            }
            foreach (Beetle beetle in this.beetles)
            {
                beetle.Draw(gameTime);

            }
            this.explorer.Draw(gameTime);
        }


        private void LoadAssets()
        {
            this.treasures = new List<Image>();
            this.beetles = new List<Beetle>();
            this.scorpions = new List<Scorpion>();
            // slaat string op van elke regel van de textbestand
            this.lines = new List<string>();

            // het readerobject kan lezen wat er in het textbestand zit
            StreamReader reader = new StreamReader(this.stream);
            string line = reader.ReadLine();
            int lineWidth = line.Length;
            //Console.WriteLine(line);
            //Console.WriteLine(lineWidth);
            while (line != null)
            {
                this.lines.Add(line);
                line = reader.ReadLine();
                //Console.WriteLine(line);


            }
            int amountOfLines = this.lines.Count;
            reader.Close();
            this.stream.Close();
            this.blocks = new Block[lineWidth, amountOfLines];
            for (int row = 0; row < amountOfLines; row++)
            {
                for (int column = 0; column < lineWidth; column++)
                {
                    char blockElement = this.lines[row][column];
                    this.blocks[column, row] = this.LoadBlock(blockElement, column * 32, row * 32);

                }

            }
               
        }
        public Block LoadBlock(char blockElement, int x, int y)
        {
            switch (blockElement)
            {
                
                case 's':
                    this.scorpions.Add(new Scorpion(this.game, new Vector2(x + 16f, y + 16f)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));
                case 'b':
                    this.beetles.Add(new Beetle(this.game, new Vector2(x + 16f, y + 16f)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));
                case 'c':
                    this.treasures.Add(new Image(this.game,@"Items\Treasure2" ,new Vector2(x , y )));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));
                case 'a':
                    this.treasures.Add(new Image(this.game, @"Items\Treasure1", new Vector2(x, y)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));
                case 'p':
                    this.treasures.Add(new Image(this.game, @"Items\Potion", new Vector2(x, y)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));
                case 'r':
                    this.treasures.Add(new Image(this.game, @"Items\Scarab", new Vector2(x, y)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));
                case 'E':
                    this.explorer = new Explorer(this.game, new Vector2(x + 16f, y + 16f));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));
                case 'x':
                    return new Block(this.game, @"Block\Block", new Vector2(x, y));
                case 'y':
                    return new Block(this.game, @"Block\Wall1", new Vector2(x, y));
                case 'z':
                    return new Block(this.game, @"Block\Wall2", new Vector2(x, y));
                case 'v':
                    return new Block(this.game, @"Block\Block_hor", new Vector2(x, y));
                case 'w':
                    return new Block(this.game, @"Block\Block_vert", new Vector2(x, y));
                case 'u':
                    return new Block(this.game, @"Block\Door", new Vector2(x, y));
                case '@':
                    this.background = new Image(this.game, @"Background\Background2", new Vector2(x, y));
                    return new Block(this.game, @"Block\Block", new Vector2(x, y));
                case '.':
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));
                default:
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));
            }
        }
    }
}
