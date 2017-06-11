using System.Media;
using DannyAndDadsPingPongGame.Properties;

namespace DannyAndDadsPingPongGame
{
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