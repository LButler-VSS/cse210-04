using System;
using Raylib_cs;
using cse210_04.Game.Casting;

namespace cse210_04.Game.Services
{
    public class KeyboardService
    {
        private int cellSize = 15;

        public KeyboardService(int cellSize)
        {
            this.cellSize = cellSize;
        }

        public Point GetDirection()
        {
            int dx = 0;
            int dy = 0;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                dx = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                dx = 1;
            }

            Point direction = new Point(dx, dy);
            direction = direction.Scale(cellSize);

            return direction;
        }
    }
}
