using System.Collections.Generic;
using cse210_04.Game.Services;
using cse210_04.Game.Casting;


namespace cse210_04.Game
{
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;
        private int score = 0;


        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }


        public void StartGame(Cast cast)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            videoService.CloseWindow();
        }


        private void GetInputs(Cast cast)
        {
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = keyboardService.GetDirection();
            robot.SetVelocity(velocity);     
        }

        private void DoUpdates(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            List<Actor> minerals = cast.GetActors("minerals");

            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            foreach (Actor actor in minerals)
            {
                if (robot.GetPosition().Equals(actor.GetPosition()))
                {
                    Mineral mineral = (Mineral) actor;
                    int value = mineral.GetValue();
                    score += value;
                    banner.SetText($"Score: {score}");
                    mineral.NewPosition();
                }
                actor.MoveNext(maxX, maxY);
            } 
        }

        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}
