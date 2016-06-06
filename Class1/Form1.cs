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
        int RandNum;
        int timerInterval;
        bool neighborCount = true;
        bool gridlines = true;
        int rungen;


    Timer timer = new Timer();
        int generations = 0;

        public Form1()
        {
            InitializeComponent();

            Random rng = new Random();
            sizeArrX = 10;
            sizeArrY = 10;
            timerInterval = 20;
            universe = new bool[sizeArrX, sizeArrY];
            timer.Interval = timerInterval;
            timer.Tick += Timer_Tick;
            RandNum = rng.Next();
            //scratchpad = new bool[sizeArrX, sizeArrY];
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options optionsMenu = new Options();

            optionsMenu.numHeight = sizeArrY;
            optionsMenu.numWidth = sizeArrX;
            optionsMenu.numTimer = timerInterval;
            optionsMenu.BackColor = graphicsPanel1.BackColor;


            if (DialogResult.OK == optionsMenu.ShowDialog())
            {
                #region Resize
                if (sizeArrY != optionsMenu.numHeight || sizeArrX != optionsMenu.numWidth)
                {
                    sizeArrX = optionsMenu.numWidth;
                    sizeArrY = optionsMenu.numHeight;
                    universe = new bool[sizeArrX, sizeArrY];
                }
                #endregion
                #region Timer
                timerInterval = optionsMenu.numTimer;
                timer.Interval = timerInterval;
                #endregion

                graphicsPanel1.BackColor = optionsMenu.BackColor;

            }


            graphicsPanel1.Invalidate();

        }
        private void runToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunTo toRun = new RunTo();

            toRun.numRunToo = rungen;

            if (DialogResult.OK == toRun.ShowDialog())
            {

                rungen = toRun.numRunToo;

            }
            timer.Start();
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
            if (generations >= rungen)
            {
                if (stopTimer == true)
                {
                    timer.Stop();
                }
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
                    if (gridlines == true)
                    {
                        e.Graphics.DrawRectangle(Pens.Gray, r.X, r.Y, r.Width, r.Height);

                    }
                    if (neighborCount == true)
                    {
                        if (count != 0)
                        {
                            e.Graphics.DrawString(count.ToString(), new Font(FontFamily.GenericSerif, height / 2, FontStyle.Bold), Brushes.Red, r.X, r.Y);
                        }
                    }

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
            generations = -1;
            timer.Enabled = true;
            stopTimer = true;
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

        public void random(int s)
        {
            Random number = new Random(s);
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    if (number.Next() % 2 == 1)
                    {
                        universe[i, j] = true; 
                    }
                    else
                    {
                        universe[i, j] = false;
                    }
                }
            }
            graphicsPanel1.Invalidate();
        }

        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            random(RandNum);
        }
        private void neighborToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (neighborToolStripMenuItem.Checked)
            {
                neighborToolStripMenuItem.Checked = false;
                neighborCount= false;
            }
            else
            {
                newToolStripMenuItem.Checked = true;
                neighborCount = true;
            }
            graphicsPanel1.Invalidate();
        }
        private void gridVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridVisibleToolStripMenuItem.Checked)
            {
                gridVisibleToolStripMenuItem.Checked = false;
                gridlines = false;
            }
            else
            {
                gridVisibleToolStripMenuItem.Checked = true;
                gridlines = true;
            }
            graphicsPanel1.Invalidate();
        }
    }
}

