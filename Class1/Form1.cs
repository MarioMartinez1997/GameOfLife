﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        bool[,] scratchpad;
        int timerInterval;
        bool neighborCount = true;
        bool gridlines = true;
        bool x10lines = true;
        bool menu = true;
        int rungen;
        int newRand;
        Color cellColor;
        Color x10CellColor;
        Color gridlineColor;
        Timer timer = new Timer();
        int generations = 0;

        public Form1()
        {
            InitializeComponent();

            Random rng = new Random();
            graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;           
            sizeArrX = 50;
            sizeArrY = 50;
            timerInterval = 20;
            sizeArrX = Properties.Settings.Default.SizeArrayX;
            sizeArrY = Properties.Settings.Default.SizeArrayY;
            timerInterval = Properties.Settings.Default.Timer;
            universe = new bool[sizeArrX, sizeArrY];
            timer.Interval = timerInterval;
            timer.Tick += Timer_Tick;
            RandNum = rng.Next();
            cellColor = Color.Black;
            x10CellColor = Color.Blue;
            gridlineColor = Color.Gray;
            toolStripStatusLabel1.Text = "Generations: " + generations.ToString() + "  Cells: " + cellsCount() + "  Seed: " + RandNum;
            gridlineColor = Properties.Settings.Default.GridLineColor;
            x10CellColor = Properties.Settings.Default.X10CellColor;
            cellColor = Properties.Settings.Default.CellColor;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.BackgroundColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.GridLineColor = gridlineColor;
            Properties.Settings.Default.X10CellColor = x10CellColor;
            Properties.Settings.Default.CellColor = cellColor;
            Properties.Settings.Default.SizeArrayX = sizeArrX;
            Properties.Settings.Default.SizeArrayY = sizeArrY;
            Properties.Settings.Default.Timer = timerInterval;
            Properties.Settings.Default.Save();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Cell Files|*.*|Cell|*.cells";
            fileDialog.FilterIndex = 2;
            if (DialogResult.OK == fileDialog.ShowDialog())
            {
                StreamReader reader = new StreamReader(fileDialog.FileName);
                int xLength = 0;
                int yLength = 0;
                int yPos = 0;
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    if (row[0] != 'O' && row[0] != '.')
                    { /* ignoring*/ }
                    else
                    {
                        yLength++;
                        xLength = row.Length;
                    }
                }
                newToolStripMenuItem_Click(sender, e);
                universe = new bool[xLength, yLength];
                scratchpad = new bool[xLength, yLength];
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    if (row[0] != 'O' && row[0] != '.')
                    {
                    }
                    else
                    {
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            if (row[xPos] == '.')
                            {
                                scratchpad[xPos, yPos] = false;
                            }
                            if (row[xPos] == 'O')
                            {
                                scratchpad[xPos, yPos] = true;
                            }
                        }
                        yPos++;
                    }
                }
                reader.Close();
                bool[,] temp = universe;
                universe = scratchpad;
                scratchpad = temp;
                scratchpad = new bool[xLength, yLength];
                sizeArrX = xLength;
                sizeArrY = yLength;
                graphicsPanel1.Invalidate();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.InitialDirectory = Application.StartupPath;
            saveFD.Filter = "Cells Files|*.*|Cell|*.cells";
            if (saveFD.ShowDialog() == DialogResult.OK)
            {

                StreamWriter str = new StreamWriter(saveFD.FileName);
                for (int i = 0; i < universe.GetLength(1); i++)
                {
                    StringBuilder String = new StringBuilder();
                    for (int j = 0; j < universe.GetLength(0); j++)
                    {
                        if (universe[j, i] == true)
                        { String.Append('O'); }
                        else
                        { String.Append('.'); }
                    }
                    str.WriteLine(String);
                }
                str.Close();
            }
        }
        private void fromNewSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomSeed fromNewSeed = new RandomSeed();

            fromNewSeed.numRandomnumberseed = newRand;

            if (DialogResult.OK == fromNewSeed.ShowDialog())
            {
                newRand = fromNewSeed.numRandomnumberseed;

                random(newRand);
                graphicsPanel1.Invalidate();

            }

        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options optionsMenu = new Options();

            optionsMenu.numHeight = sizeArrY;
            optionsMenu.numWidth = sizeArrX;
            optionsMenu.numTimer = timerInterval;
            optionsMenu.pBackGroundColor = graphicsPanel1.BackColor;
            optionsMenu.pLiveCellColor = cellColor;
            optionsMenu.pGridx10Color = x10CellColor;
            optionsMenu.pGridColor = gridlineColor;

            //fillrectangle = new Brushes(Color.Violet);
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

                //problems passing the colors
                graphicsPanel1.BackColor = optionsMenu.pBackGroundColor;
                cellColor = optionsMenu.pLiveCellColor;
                x10CellColor = optionsMenu.pGridx10Color;
                gridlineColor = optionsMenu.pGridColor;
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
            scratchpad = new bool[universe.GetLength(0), universe.GetLength(1)];
            //throw new NotImplementedException();
            //call next generations
            //Adding rules
            #region Rules
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    int count = countNeighbors(i, j);
                    if (universe[i, j])
                    {
                        if (count < 2 || count > 3)
                        {
                            scratchpad[i, j] = false;
                        }
                        if (count == 3 || count == 2)
                        {
                            scratchpad[i, j] = true;
                        }
                    }
                    else if (!universe[i, j])
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
            toolStripStatusLabel1.Text = "Generations: " + generations.ToString() + "  Cells: " + cellsCount() + "  Seed: " + RandNum;


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
            SolidBrush cellbrush = new SolidBrush(cellColor);
            Pen x10 = new Pen(x10CellColor, 3.0f);
            Pen colorgridlines = new Pen(gridlineColor, 0.5f);
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

                    if (x10lines == true)
                    {
                        if (x % 10 == 0 && y % 10 == 0)
                        {
                            e.Graphics.DrawRectangle(x10, r.X, r.Y, r.Width * 10, r.Height * 10);
                        }
                    }
                    

                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellbrush, r);
                    }
                    if (gridlines == true)
                    {
                        e.Graphics.DrawRectangle(colorgridlines, r.X, r.Y, r.Width, r.Height);

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
            if (menu == true)
            {
                e.Graphics.DrawString("Generations: " + generations.ToString() + "\nCells: " + cellsCount() + "\nSeed: " + RandNum + "\nUniverse Size: {Width: " + sizeArrX + ", Height: " + sizeArrY + "}",
               new Font(FontFamily.GenericSansSerif, (sizeArrY / 10) + 10, FontStyle.Italic), Brushes.Red, 2, graphicsPanel1.Height - sizeArrY - (height + 30));
            }
           

        }
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                float width = (float)graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                float height = (float)graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                float x = e.X / width;
                float y = e.Y / height;

                universe[(int)x, (int)y] = !universe[(int)x, (int)y];
            }
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(graphicsPanel1, e.Location);

            }
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

            if (x + 1 < universe.GetLength(0))
            {
                if ((universe[x + 1, y]))
                { count++; }
            }
            if (x - 1 >= 0)
            {
                if (universe[x - 1, y])
                { count++; }
            }
            if (y - 1 >= 0)
            {
                if (universe[x, y - 1])
                { count++; }
            }
            if (y + 1 < universe.GetLength(1))
            {
                if (universe[x, y + 1])
                { count++; }
            }
            if (x + 1 < universe.GetLength(0) && y + 1 < universe.GetLength(1))
            {
                if (universe[x + 1, y + 1])
                { count++; }
            }
            if (x + 1 < universe.GetLength(0) && y - 1 >= 0)
            {
                if (universe[x + 1, y - 1])
                { count++; }
            }
            if (x - 1 >= 0 && y + 1 < universe.GetLength(1))
            {
                if (universe[x - 1, y + 1])
                { count++; }
            }
            if (x - 1 >= 0 && y - 1 >= 0)
            {
                if (universe[x - 1, y - 1])
                { count++; }
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
        public int cellsCount()
        {
            int countCells = 0;

            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (universe[x, y] == true)
                    {
                        ++countCells;
                    }
                }
            } return countCells;
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
                neighborCount = false;
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
                x10lines = false;

            }
            else
            {
                gridVisibleToolStripMenuItem.Checked = true;
                gridlines = true;
            }
            graphicsPanel1.Invalidate();
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void headsUpVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (neighborToolStripMenuItem.Checked)
            {
                neighborToolStripMenuItem.Checked = false;
                menu = false;
            }
            else
            {
                newToolStripMenuItem.Checked = true;
                menu = true;
            }
            graphicsPanel1.Invalidate();
        }
    }    
}

