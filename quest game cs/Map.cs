using System;
using System.Collections.Generic;
using System.Text;

namespace quest_game_cs
{
    class Map
    {
        private static int mapWidth = 170;
        private static int mapHeight = 12;
        private static StringBuilder outputInteraction = new StringBuilder(Player.VisibilityRange);
        private char[,] mapSurface = new char[mapHeight, mapWidth];
        public static int MapWidth
        {
            get
            {
                return mapWidth;
            }
        }
        public static int MapHeight
        {
            get
            {
                return mapHeight;
            }
        }
        public static StringBuilder OutputInteraction
        {
            get
            {
                return outputInteraction;
            }
            set
            {
                if (value.Length <= Player.VisibilityRange)
                {
                    outputInteraction = value;
                }
            }
        }
        public Map()
        {
            for (int i=0;i< mapHeight; i++)
            {
                for (int j=0;j< mapWidth; j++)
                {
                    mapSurface[i, j] = ' ';
                    if (i==0 || i== mapHeight-1 || j==0 || j== mapWidth - 1)
                    {
                        mapSurface[i, j] = '*';
                    }
                }
            }
        }
        public static int GetYFloor()
        {
            return mapHeight - 2;
        }
        public void Draw()
        {
            char[,] mapSurfaceCopy = new char[mapHeight, mapWidth];
            int beginOfVisibility = Player.BeginOfVisibility;
            int endOfVisibility = Player.EndOfVisibility;

            for (int i = 0; i < mapHeight; i++)
                for (int j = beginOfVisibility; j < endOfVisibility; j++)
                    mapSurfaceCopy[i, j] = mapSurface[i, j];

            int x = Player.X;
            int y = Player.Y - Player.Height + 1;
            int height = Player.Height;
            int width = Player.Width;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    mapSurface[y + i, x + j] = Player.Surface[i][j];
                }
            }

            Console.WriteLine("");
            for (int i = 0; i < mapHeight; i++)
            {
                string strOut = "";
                for (int j = beginOfVisibility; j < endOfVisibility; j++)
                {
                    strOut += mapSurface[i, j];
                }
                Console.WriteLine(strOut);
            }
            string hearts="";
            for (int i=0;i< Player.Health; i++)
            {
                hearts += "♥ ";
            }
            Console.WriteLine("ЗДОРОВЬЕ: " + hearts + " / ЭНЕРГИЯ: " + Player.Energy.ToString() + " / ДЕНЬГИ: " + Player.Money.ToString() + "$");
            Console.WriteLine(outputInteraction);
            outputInteraction.Clear();

            for (int i = 0; i < mapHeight; i++)
                for (int j = beginOfVisibility; j < endOfVisibility; j++)
                    mapSurface[i, j] = mapSurfaceCopy[i, j];
        }
        public void DrawToCreate()
        {
            char[,] mapSurfaceCopy = new char[mapHeight, mapWidth];
            int beginOfVisibility = 0;
            int endOfVisibility = mapWidth;

            for (int i = 0; i < mapHeight; i++)
                for (int j = beginOfVisibility; j < endOfVisibility; j++)
                    mapSurfaceCopy[i, j] = mapSurface[i, j];

            mapSurface[Map.GetYFloor() - 1, Player.X] = '#';

            Console.WriteLine("");
            for (int i = 0; i < mapHeight; i++)
            {
                string strOut = "";
                for (int j = beginOfVisibility; j < endOfVisibility; j++)
                {
                    strOut += mapSurface[i, j];
                }
                Console.WriteLine(strOut);
            }

            Console.WriteLine(outputInteraction);
            outputInteraction.Clear();

            for (int i = 0; i < mapHeight; i++)
                for (int j = beginOfVisibility; j < endOfVisibility; j++)
                    mapSurface[i, j] = mapSurfaceCopy[i, j];
        }
        public void Clear()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    mapSurface[i, j] = ' ';
                    if (i == 0 || i == mapHeight - 1 || j == 0 || j == mapWidth - 1)
                    {
                        mapSurface[i, j] = '*';
                    }
                }
            }
        }
        public void Add(Element element)
        {
            if (element != null)
            {
                int x = element.X;
                int y = element.Y - element.Height + 1;
                int height = element.Height;
                int width = element.Width;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        mapSurface[y + i, x + j] = element.Surface[i][j];
                    }
                }
            }
            
        }
        public void Add(List<Element> elements)
        {
            foreach (Element cElement in elements)
            {
                Add(cElement);
            }
        }
        public void ClearAdd(List<Element> elements)
        {
            Clear();
            foreach (Element cElement in elements)
            {
                Add(cElement);
            }
        }
    }
}
