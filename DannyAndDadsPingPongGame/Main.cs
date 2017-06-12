using System;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DannyAndDadsPingPongGame
{
    public partial class Main : Form
    {
        private Ball _ball;
        private Gameover _gameover;
        private Playground _playground;
        private Racket _racket;
        private Random _random;
        private Score _score;

        public Main()
        {
            InitializeComponent();

            ResetGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _racket.CaptureMouse();
            _ball.Move();

            if (_ball.HitsRacket(_racket))
            {
                var speed = _racket.CalculateDeflection(_ball);
                _ball.IncreaseSpeedBy(speed);
                _score.Increment();
                _playground.ChangeColor(_random);
                _ball.Hit();
            }

            if (_ball.HitsWallsOf(_playground))
                _ball.BounceHorizontal();

            if (_ball.HitsCeilingOf(_playground))
                _ball.BounceVertically();

            if (_ball.MissesRacket(_racket))
            {
                _ball.Miss();
                EndGame();
            }

            _playground.Redraw();
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawImage(_ball.Image, _ball.Area);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();

            if (e.KeyCode == Keys.F1)
                ResetGame();
        }

        private void ResetGame()
        {
            _random = new Random();
            Cursor.Hide();
            _playground = new Playground(this);
            _playground.FullScreen();

            _ball = new Ball
            {
                X = 4,
                Y = 4
            };

            _racket = new Racket(racket, Bottom);
            _score = new Score(points);

            _gameover = new Gameover(gameover);
            _gameover.Hide();
            _gameover.Center(_playground);

            timer1.Enabled = true;
        }

        private void EndGame()
        {
            timer1.Enabled = false;
            _gameover.Show();
        }
    }
}