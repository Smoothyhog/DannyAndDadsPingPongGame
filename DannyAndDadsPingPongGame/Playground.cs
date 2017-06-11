using System;
using System.Drawing;
using System.Windows.Forms;

namespace DannyAndDadsPingPongGame
{
    internal class Playground
    {
        private readonly Control _control;

        public Playground(Control control)
        {
            _control = control;
        }

        public Rectangle Bounds => _control.Bounds;

        public void FullScreen()
        {
            _control.Bounds = Screen.PrimaryScreen.Bounds;
        }

        public void Redraw()
        {
            _control.Invalidate();
        }

        public void ChangeColor(Random r)
        {
            _control.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));
        }
    }
}