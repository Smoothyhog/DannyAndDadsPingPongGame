using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DannyAndDadsPingPongGame
{
    public partial class Form1 : Form
    {

        public int speed_horizontal = 4;
        public int speed_vertical = 4;
        public int score = 0;
        public Random r;

        public Form1()
        {
            this.r = new Random();
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();
            this.Bounds = Screen.PrimaryScreen.Bounds;

            racket.Top = playground.Bottom - (playground.Bottom / 10);

            gameover.Left = (playground.Width / 2) - (gameover.Width / 2);
            gameover.Top = (playground.Height / 2) - (gameover.Height / 2);
            gameover.Visible = false;

        }

        private void racket_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            racket.Left = Cursor.Position.X - (racket.Width / 2);

            ball.Left += speed_horizontal;
            ball.Top += speed_vertical;

            if ((ball.Bottom >= racket.Top)
                && (ball.Bottom <= racket.Bottom)
                && (ball.Left >= racket.Left)
                &&(ball.Right <= racket.Right))
            {
                speed_vertical += 2;
                speed_horizontal += 2;
                speed_vertical = -speed_vertical;
                score += 1;
                playground.BackColor = Color.FromArgb(this.r.Next(150, 255), this.r.Next(150, 255), this.r.Next(150, 255));
            }
            points.Text = score.ToString();

            if ((ball.Left <= playground.Left)
                || (ball.Right >= playground.Right))
            {
                speed_horizontal = -speed_horizontal;
            }
            if (ball.Top <= playground.Top)
            {
                speed_vertical = -speed_vertical;
            }
            if (ball.Bottom >= racket.Bottom )
            {
                timer1.Enabled = false;
                gameover.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_horizontal = 4;
                speed_vertical = 4;
                score = 0;
                gameover.Visible = false;
                timer1.Enabled = true;
            }
        }
    }
}
