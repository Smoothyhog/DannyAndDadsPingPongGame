using System.Drawing;
using System.Windows.Forms;

namespace DannyAndDadsPingPongGame
{
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
}