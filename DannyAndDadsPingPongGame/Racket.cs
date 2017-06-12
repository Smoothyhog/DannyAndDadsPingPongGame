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

        public int CalculateDeflection(Ball ball)
        {
            var x = _control.Width / 3;
            var a = _control.Left + x;
            var b = _control.Left + (2 * x);

            if (ball.Area.Left >= _control.Left
                && ball.Area.Right <= a)
                return 2;
            if (ball.Area.Left >= a
                && ball.Area.Right <= b)
                return 4;
            if (ball.Area.Left >= b)
                return 1;

            return 0;
        }
    }
}