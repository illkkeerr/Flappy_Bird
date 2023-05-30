using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int boruHizi = 8;
        int gravity = 10;
        int score = 15;
        int scoreArtis = 0;
        bool basla = false;
        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (basla == true)
            {
                flappyBird.Top += gravity;
                boruAlt.Left -= boruHizi;
                boruUst.Left -= boruHizi;
                scoreText.Text = "Score: " + score;
                if (boruAlt.Left < -150)
                {
                    boruAlt.Left = 800;
                    score++;
                    scoreArtis++;
                }
                if (boruUst.Left < -180)
                {
                    boruUst.Left = 950;
                    score++;
                    scoreArtis++;
                }
                if (flappyBird.Bounds.IntersectsWith(boruAlt.Bounds) || flappyBird.Bounds.IntersectsWith(boruUst.Bounds) ||
                    flappyBird.Bounds.IntersectsWith(Zemin.Bounds))
                {
                    endGame();
                }
                if (scoreArtis > 15)
                {
                    boruHizi += 4;
                    scoreArtis = 0;
                }
                if (flappyBird.Top < -25)
                {
                    endGame();
                }
            }

        }


        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;

            }

        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = +10;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "Game Over!!!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Visible = false;
            basla = true;
            button1.Enabled = true;
            this.Focus();
        }
    }
}
