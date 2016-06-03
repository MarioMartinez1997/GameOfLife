using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class1
{
    public partial class Form1 : Form
    {
        int sizeArrX;
        int sizeArrY;
        bool[,] universe;
        bool stopTimer = false; // bool to be able to step
        //bool[,] scratchpad;

        Timer timer = new Timer();
        int generations = 0;

        public Form1()
        {
            InitializeComponent();

            sizeArrX = 10;
            sizeArrY = 10;
            universe = new bool[sizeArrX, sizeArrY];
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            //scratchpad = new bool[sizeArrX, sizeArrY];


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            bool[,] scratchpad = new bool[universe.GetLength(0), universe.GetLength(1)];
            //throw new NotImplementedException();
            //call next generations

            //Adding rules
            #region Rules
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    int count = countNeighbors(i, j);
                    if (universe [ i , j ])
                    {
                        if (count < 2 ||  count > 3)
                        {
                            scratchpad[i, j] = false;
                        }
                        if(count == 3 || count == 2)
                        {
                            scratchpad[i, j] = true;
                        }
                   }
                    else if(!universe[i,j])
                    {
                        if (count == 3)
                        {
                            scratchpad[i, j] = true;
                        }
                    }
                }

                //condition to be able to step always = false unless stepping
                
            }
            #endregion
            generations++;

            universe = scratchpad;
            toolStripStatusLabel1.Text = "Generations: " + generations.ToString();


            graphicsPanel1.Invalidate();
            if (stopTimer == true)
            {
                timer.Stop();
            }

        }
        private void play_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            stopTimer = false;
        }
        private void pause_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }
        private void next_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            stopTimer = true; //pause timer after each generation setting bool = true
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            float width = (float)graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            float height = (float)graphicsPanel1.ClientSize.Height / universe.GetLength(1);
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int count = countNeighbors(x, y);

                    RectangleF r = RectangleF.Empty;
                    r.X = x * width;
                    r.Y = y * height;
                    r.Width = width;
                    r.Height = height;

                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(Brushes.Black, r);
                    }

                    e.Graphics.DrawRectangle(Pens.Gray, r.X, r.Y, r.Width, r.Height);
                    /* put number of neighbors
                    if (count != 0)
                    {
                        e.Graphics.DrawString(count.ToString(), new Font(FontFamily.GenericSerif, height / 2, FontStyle.Bold), Brushes.Red, r.X,r.Y);

                    }*/
                }
            }

        }
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            float width = (float)graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            float height = (float)graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            float x = e.X / width;
            float y = e.Y / height;

            universe[(int)x, (int)y] = !universe[(int)x, (int)y];
            graphicsPanel1.Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
            }
            timer.Stop();
            generations = 0;
            graphicsPanel1.Invalidate();
        }

        private int countNeighbors(int x, int y)
        {
            int count = 0;

            if (x + 1 < universe.GetLength(0) )
            {
                if ((universe[x + 1, y]))
                { count++; }
            }
            if (x - 1 >= 0)
            { 
                if (universe[x - 1, y])
                {count++;}
            }
            if (y - 1 >= 0 )
            {
                if (universe[x, y - 1])
                {count++;}
            }
            if (y + 1 < universe.GetLength(1))
            {           
                if (universe[x, y+1])
                {count++;}
            }
            if (x + 1 < universe.GetLength(0) && y + 1 < universe.GetLength(1))
            {
                if (universe[x + 1, y + 1])
                {count++;}
            }
            if (x+1 < universe.GetLength(0) && y-1 >= 0)
            {
                if (universe[ x+1 , y-1])
                {count++;}
            }
            if (x - 1 >= 0 && y + 1 < universe.GetLength(1))
            {
                if (universe[x - 1, y + 1])
                {count++;}
            }
            if (x - 1 >= 0 && y - 1 >= 0)
            {
                if (universe[x - 1, y -1])
                {count++;}
            }
            return count;
        }


    }
}

