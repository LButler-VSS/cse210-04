using System;

namespace cse210_04.Game.Casting
{
    public class Mineral:Actor
    {
        private int value = 0;

        public Mineral()
        {
        }

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int value)
        {
            this.value = value;
        }
    }
}
