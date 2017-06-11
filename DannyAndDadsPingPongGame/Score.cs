using System.Windows.Forms;

namespace DannyAndDadsPingPongGame
{
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
}