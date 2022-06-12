using System;
using System.Linq;

namespace cse210_04.Game.Casting
{
    public class Actor
    {
        private string text = "";
        private int fontSize = 15;
        private Color color = new Color(255, 255, 255);
        private Point position = new Point(0, 0);
        private Point velocity = new Point(0, 0);


        public Actor()
        {
        }

    
        public Color GetColor()
        {
            return color;
        }


        public int GetFontSize()
        {
            return fontSize;
        }


        public Point GetPosition()
        {
            return position;
        }

        public string GetText()
        {
            return text;
        }


        public Point GetVelocity()
        {
            return velocity;
        }


        public void MoveNext(int maxX, int maxY)
        {
            int x = ((position.GetX() + velocity.GetX()) + maxX) % maxX;
            int y = ((position.GetY() + velocity.GetY()) + maxY) % maxY;
            position = new Point(x, y);
        }


        public void SetColor(Color color)
        {
            if (color == null)
            {
                throw new ArgumentException("color can't be null");
            }
            this.color = color;
        }

        public void SetFontSize(int fontSize)
        {
            if (fontSize <= 0)
            {
                throw new ArgumentException("fontSize must be greater than zero");
            }
            this.fontSize = fontSize;
        }


        public void SetPosition(Point position)
        {
            if (position == null)
            {
                throw new ArgumentException("position can't be null");
            }
            this.position = position;
        }


        public void SetText(string text)
        {
            if (text == null)
            {
                throw new ArgumentException("text can't be null");
            }
            this.text = text;
        }


        public void SetVelocity(Point velocity)
        {
            if (velocity == null)
            {
                throw new ArgumentException("velocity can't be null");
            }
            this.velocity = velocity;
        }

        public void NewPosition()
        {
            Random random = new Random();
            int x = random.Next(1, 60);
            int y = random.Next(1, 40);
            position = new Point(x, y);
            position = position.Scale(15);
        }
    }
}
