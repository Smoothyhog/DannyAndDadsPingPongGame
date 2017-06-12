using System.Drawing;
using DannyAndDadsPingPongGame.Properties;

namespace DannyAndDadsPingPongGame
{
    internal class Ball
    {
        private readonly Audio _audio;
        private Rectangle _bounds;

        public Ball()
        {
            _bounds = new Rectangle
            {
                X = 900,
                Y = 50,
                Width = 30,
                Height = 30
            };
            Image = Resources.ball;
            _audio = new Audio();
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Rectangle Area => _bounds;

        public Bitmap Image { get; }

        public void Move()
        {
            _bounds.X += X;
            _bounds.Y += Y;
        }

        public void IncreaseSpeedBy(int amount)
        {
            Y += amount;
            X += amount;
        }

        public void BounceVertically()
        {
            _audio.Plop();
            Y = -Y;
        }

        public void BounceHorizontal()
        {
            _audio.Plop();
            X = -X;
        }

        public void Hit()
        {
            _audio.Beeep();
            Y = -Y;
        }

        public void Miss()
        {
            _audio.Peeeeeep();
        }

        public bool HitsWallsOf(Playground playground)
        {
            return _bounds.Left <= playground.Bounds.Left
                   || _bounds.Right >= playground.Bounds.Right;
        }

        public bool HitsCeilingOf(Playground playground)
        {
            return _bounds.Top <= playground.Bounds.Top;
        }

        public bool MissesRacket(Racket racket)
        {
            return _bounds.Bottom >= racket.Area.Bottom;
        }

        public bool HitsRacket(Racket racket)
        {
            return _bounds.Bottom >= racket.Area.Top
                   && _bounds.Bottom <= racket.Area.Bottom
                   && _bounds.Left >= racket.Area.Left
                   && _bounds.Right <= racket.Area.Right;

        }
    }
}