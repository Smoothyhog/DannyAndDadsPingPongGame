using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Forms;
using DannyAndDadsPingPongGame.Properties;

namespace DannyAndDadsPingPongGame
{
    public partial class Form1 : Form
    {
        private Ball _ball;
        private Racket _racket;
        private Random _random;
        private Score _score;

        public Form1()
        {
            InitializeComponent();

            ResetGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _racket.CaptureMouse();
            _ball.Move();

            if (_racket.Hits(_ball))
            {
                _ball.IncreaseSpeedBy(1);
                _ball.BounceVerticallly();
                _score.Increment();
                this.ChangeColor(_random);
                _ball.Hit();
            }

            if (_ball.HitsWallsOf(this))
                _ball.BounceHorizontal();

            if (_ball.HitsCeilingOf(this))
                _ball.BounceVerticallly();

            if (_ball.MissesRacket(_racket))
            {
                _ball.Miss();
                EndGame();
            }

            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
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
            Bounds = Screen.PrimaryScreen.Bounds;

            timer1.Enabled = true;

            _ball = new Ball
            {
                X = 4,
                Y = 4
            };

            _racket = new Racket(racket, Bottom);
            _score = new Score(points);

            gameover.Left = Width / 2 - gameover.Width / 2;
            gameover.Top = Height / 2 - gameover.Height / 2;
            gameover.Visible = false;
        }

        private void EndGame()
        {
            timer1.Enabled = false;
            gameover.Visible = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawImage(_ball.Image, _ball.Area);
        }
    }

    internal class Racket
    {
        private readonly PictureBox _control;

        public Racket(PictureBox control, int screenHeight)
        {
            _control = control;
            _control.Top = screenHeight - screenHeight / 10;
        }

        public Rectangle Area => _control.Bounds;

        public void CaptureMouse()
        {
            _control.Left = Cursor.Position.X - _control.Width / 2;
        }

        public bool Hits(Ball ball)
        {
            return ball.Area.Bottom >= _control.Top
                   && ball.Area.Bottom <= _control.Bottom
                   && ball.Area.Left >= _control.Left
                   && ball.Area.Right <= _control.Right;
        }
    }

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

        public void BounceVerticallly()
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
        }

        public void Miss()
        {
            _audio.Peeeeeep();
        }

        public bool HitsWallsOf(Control playground)
        {
            return _bounds.Left <= playground.Left
                   || _bounds.Right >= playground.Right;
        }

        public bool HitsCeilingOf(Control playground)
        {
            return _bounds.Top <= playground.Top;
        }

        public bool MissesRacket(Racket racket)
        {
            return _bounds.Bottom >= racket.Area.Bottom;
        }
    }

    internal class Score
    {
        private readonly Label _control;
        private int _points;

        public Score(Label control)
        {
            _control = control;
            _points = 0;
        }


        public void Increment()
        {
            _points += 1;
            _control.Text = _points.ToString();
        }
    }

    internal static class ControlExtensions
    {
        public static void ChangeColor(this Control playground, Random r)
        {
            playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));
        }
    }

    internal class Audio
    {
        private readonly SoundPlayer _player;

        public Audio()
        {
            _player = new SoundPlayer();
        }

        public void Plop()
        {
            _player.Stream = Resources.plop;
            _player.Play();
        }

        public void Beeep()
        {
            _player.Stream = Resources.beeep;
            _player.Play();
        }

        public void Peeeeeep()
        {
            _player.Stream = Resources.peeeeeep;
            _player.Play();
        }
    }
}