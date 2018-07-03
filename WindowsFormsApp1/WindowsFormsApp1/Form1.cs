using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool goup;
        bool godown;
        bool goleft;
        bool goright;


        int speed = 5;
        int ghost1 = 8; //hacer que se mueva para cualquier lado VERRRRR
        int ghost2 = 8;

        int puntos = 0;

        Main todo = new Main();
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("../../Serialize.txt"))
            {
                BinaryFormatter bin = new BinaryFormatter();
                Stream stream = new FileStream("../../Serialize.txt", FileMode.Open, FileAccess.Read);
                todo = new Main();
                todo = (Main)bin.Deserialize(stream);
                stream.Close();
            }
            else
            {
                todo = new Main();
            }
                
            
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.BringToFront();
            label3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {}

        private void label1_Click(object sender, EventArgs e)
        {        }

        private void button2_Click(object sender, EventArgs e)  //juego
        {
            
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.BringToFront();
            timer1.Start();

        }

        private void button1_Click(object sender, EventArgs e) // tabla de posiciones
        {
            listBox1.Items.Clear();
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.BringToFront();
            foreach(Usuario u in todo.Listaordenada())
            {
                listBox1.Items.Add("nombre: " + u.getnombre() + "puntos: " + u.getpuntos());
            }
        }

        private void button3_Click(object sender, EventArgs e) // Salir 
        {
            if (File.Exists("../../Serialize.txt"))
            {
                BinaryFormatter bin = new BinaryFormatter();
                Stream stream = new FileStream("../../Serialize.txt", FileMode.Open, FileAccess.Write);
                bin.Serialize(stream, todo);
                stream.Close();
            }
            else
            {
                BinaryFormatter bin = new BinaryFormatter();
                Stream stream = new FileStream("../../Serialize.txt", FileMode.Create, FileAccess.Write);
                bin.Serialize(stream, todo);
                stream.Close();
            }
            Application.Exit();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Left)
            {
                goleft = true;
                PacmanR.Image = Properties.Resources.pacman_left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                PacmanR.Image = Properties.Resources.pacman_right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                PacmanR.Image = Properties.Resources.pacman_up;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                PacmanR.Image = Properties.Resources.pacman_down;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //timer
        {
            if (goleft)
            {
                PacmanR.Left -= speed;
            }
            if (goright)
            {
                PacmanR.Left += speed;
            }
            if (goup)
            {
                PacmanR.Top -= speed;
            }
            if (godown )
            {
                PacmanR.Top += speed;
            }

            redghost.Left += ghost1;
            pinkghost.Top += ghost2;


            if (redghost.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                ghost1 = -ghost1;
            }
            else if (redghost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                ghost1 = -ghost1;
            }



            if (pinkghost.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                ghost2 = -ghost2;
            }
            else if (pinkghost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                ghost2 = -ghost2;
            }


            foreach (Control p in this.Controls)
            {
                if(p is PictureBox &&  p.Tag == "ghost")
                {
                    if(((PictureBox)p).Bounds.IntersectsWith(PacmanR.Bounds))
                    {
                        PacmanR.Left = 0;
                        PacmanR.Top = 25;
                        label3.Text = "GAME OVER";
                        String nombre = textBox1.Text;
                        Usuario jugador = new Usuario(nombre, puntos);

                        timer1.Stop();
                    }
                }
            }

        }

        private void keyisdown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.BringToFront();
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.BringToFront();
            timer1.Stop();
        }
    }
}
