using System;
using cse210_04.Game;
using cse210_04.Game.Services;
using cse210_04.Game.Casting;
using System.Collections.Generic;
using System.Linq;

namespace cse210_04
{
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Greed";
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_MINERALS = 40;

        static void Main(string[] args)
        {
            Cast cast = new Cast();

            Actor banner = new Actor();
            banner.SetText("Score: ");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            Actor robot = new Actor();
            robot.SetText("#");
            robot.SetFontSize(FONT_SIZE);
            robot.SetColor(WHITE);
            robot.SetPosition(new Point(MAX_X / 2, MAX_Y - 50));
            cast.AddActor("robot", robot);

            Random random = new Random();
            for (int i = 0; i < DEFAULT_MINERALS; i++)
            {
                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);
                string text = "*";
                int value = 100;

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                if (i > DEFAULT_MINERALS/2)
                {
                    text = "O";
                    value = -100;
                }

                Mineral mineral = new Mineral();
                mineral.SetText(text);
                mineral.SetFontSize(FONT_SIZE);
                mineral.SetColor(color);
                mineral.SetPosition(position);
                mineral.SetValue(value);
                mineral.SetVelocity(new Point(0, 1));
                cast.AddActor("minerals", mineral);
            }

            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);
        }
    }
}
