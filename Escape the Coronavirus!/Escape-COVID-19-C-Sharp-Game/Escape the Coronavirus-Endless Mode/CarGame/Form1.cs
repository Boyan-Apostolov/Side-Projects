using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.BackColor = System.Drawing.Color.Transparent;
            over.BringToFront();
            button1.BringToFront();
            over.Visible = false;
            //enemy1.BringToFront();
            //enemy2.BringToFront();
            //enemy3.BringToFront();
        }

        private bool isStarted = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isStarted)
            {
                if (isOver == false)
                {
                    moveCenterLine(gamespeed);
                    moveEnemies(gamespeed);
                    moveCoins(gamespeed);
                    checkIfGameOver();
                    collectingCoins();
                }
            }
        }

        Random r = new Random();
        private int x, y;
        private bool isActive = true;
        void moveEnemies(int speed)
        {
            if (enemy1.Top >= 500)
            {
                x = r.Next(0, 200);

                enemy1.Location = new Point(x, 40);
            }
            else { enemy1.Top += speed; }
            //
            if (enemy2.Top >= 500)
            {
                x = r.Next(0, 400);

                enemy2.Location = new Point(x, 40);
            }
            else { enemy2.Top += speed; }
            //
            if (enemy3.Top >= 500)
            {
                x = r.Next(2, 350);

                enemy3.Location = new Point(x, 40);
            }
            else { enemy3.Top += speed; }
        }

        void moveCenterLine(int speed)
        {
            if (pictureBox1.Top >= 500) { pictureBox1.Top = 0; }
            else { pictureBox1.Top += speed; }
            //
            if (pictureBox2.Top >= 500) { pictureBox2.Top = 0; }
            else { pictureBox2.Top += speed; }
            //
            if (pictureBox3.Top >= 500) { pictureBox3.Top = 0; }
            else { pictureBox3.Top += speed; }
            //
            if (pictureBox4.Top >= 500) { pictureBox4.Top = 0; }
            else { pictureBox4.Top += speed; }
        }

        private int gamespeed = 5;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isOver == false)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (car.Left > 0)
                        car.Left += -gamespeed;
                }
                //
                if (e.KeyCode == Keys.Right)
                {
                    if (car.Right < 380)
                        car.Left += gamespeed;
                }
                //
                if (e.KeyCode == Keys.Up)
                {
                    if (gamespeed < 21) gamespeed++;
                }
                //
                if (e.KeyCode == Keys.Down)
                {
                    if (gamespeed > 0) gamespeed--;
                }
            }

        }

        void checkIfGameOver()
        {
            if (car.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
                isOver = true;
                button1.Visible = true;
            }
            //
            if (car.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                isOver = true;
                over.Visible = true;
                button1.Visible = true;
            }
            //
            if (car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                isOver = true;
                over.Visible = true;
                button1.Visible = true;
            }
        }

        void moveCoins(int speed)
        {
            if (coin1.Top >= 500)
            {
                x = r.Next(0, 200);

                coin1.Location = new Point(x, 40);
            }
            else { coin1.Top += speed; }
            //
            if (coin2.Top >= 500)
            {
                x = r.Next(0, 400);

                coin2.Location = new Point(x, 40);
            }
            else { coin2.Top += speed; }
            //
            if (coin3.Top >= 500)
            {
                x = r.Next(2, 350);

                coin3.Location = new Point(x, 40);
            }
            else { coin3.Top += speed; }
            //
            if (coin4.Top >= 500)
            {
                x = r.Next(2, 350);

                coin4.Location = new Point(x, 40);
            }
            else { coin4.Top += speed; }
        }

        private int collectedCoins = 0;
        private bool isOver = false;

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isStarted = true;
            button2.Visible = false;
            button2.Enabled = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }
        void collectingCoins()
        {
            if (car.Bounds.IntersectsWith(coin1.Bounds))
            {
                collectedCoins++;

                x = r.Next(50, 300);
                coin1.Location = new Point(x, 40);

                label1.Text = "Pills=" + collectedCoins.ToString();
            }
            //
            if (car.Bounds.IntersectsWith(coin2.Bounds))
            {
                collectedCoins++;
                x = r.Next(50, 300);
                coin2.Location = new Point(x, 40);
                label1.Text = "Pills=" + collectedCoins.ToString();
            }
            //
            if (car.Bounds.IntersectsWith(coin3.Bounds))
            {
                collectedCoins++;
                x = r.Next(50, 300);
                coin3.Location = new Point(x, 40);
                label1.Text = "Pills=" + collectedCoins.ToString();
            }
            //
            if (car.Bounds.IntersectsWith(coin4.Bounds))
            {
                collectedCoins++;
                x = r.Next(50, 300);
                coin4.Location = new Point(x, 40);
                label1.Text = "Pills=" + collectedCoins.ToString();
            }

        }
    }
}
