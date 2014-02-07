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



        //Draw
        public void Draw(GameTime gameTime)
        {
            for (int row = 0; row < this.blocks.GetLength(1); row++)
            {
                for (int column = 0; column < this.blocks.GetLength(0); column++)
                {
                    this.blocks[column, row].Draw(gameTime);
                }
            }
        }


        private void LoadAssets()
        {
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
                case 'x':
                    return new Block(this.game, @"Block\Block", new Vector2(x, y));
                case '.':
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));
                default:
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));


            }
        }
    }
}
