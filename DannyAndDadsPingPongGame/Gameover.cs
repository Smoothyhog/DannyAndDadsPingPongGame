using System.Windows.Forms;

namespace DannyAndDadsPingPongGame
{
    internal class Gameover
    {
        private readonly Control _control;

        public Gameover(Control control)
        {
            _control = control;
        }

        public void Center(Playground playground)
        {
            _control.Left = playground.Bounds.Width / 2 - _control.Width / 2;
            _control.Top = playground.Bounds.Height / 2 - _control.Height / 2;
            _control.Visible = false;
        }

        public void Show()
        {
            _control.Visible = true;
        }

        public void Hide()
        {
            _control.Visible = false;
        }
    }
}