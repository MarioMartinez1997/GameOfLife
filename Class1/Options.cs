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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            numericUpDownTimerInterval.Maximum = Int32.MaxValue;
            livecellcolor.BackColor = Color.Black;
        }
        public int numWidth
        {
            get
            {return (int)numericUpDownWidthUniverseCells.Value;}
            set
            {numericUpDownWidthUniverseCells.Value = value;}
        }
        public int numHeight
        {
            get
            { return (int)numericUpDownHeightUniverseCells.Value; }
            set
            { numericUpDownHeightUniverseCells.Value = value; }
        }
        public int numTimer
        {
            get
            { return (int)numericUpDownTimerInterval.Value; }
            set
            { numericUpDownTimerInterval.Value = value; }
        }

        private void backgroundcolor_Click(object sender, EventArgs e)
        {
            ColorDialog backgroundColor = new ColorDialog();

            backgroundColor.Color = backgroundcolor.BackColor;

            if (DialogResult.OK == backgroundColor.ShowDialog())
            {
                backgroundcolor.BackColor = backgroundColor.Color;
            }
        }   
        public Color pBackGroundColor
        {
            get
            { return backgroundcolor.BackColor; }
            set
            { backgroundcolor.BackColor = value; }
        }

        private void livecellcolor_Click(object sender, EventArgs e)
        {
            ColorDialog cellcolor = new ColorDialog();

            cellcolor.Color = livecellcolor.BackColor;
            

            if (DialogResult.OK == cellcolor.ShowDialog())
            {
                livecellcolor.BackColor = cellcolor.Color;
            }
        }
        public Color pLiveCellColor
        {
            get
            { return livecellcolor.BackColor; }
            set
            { livecellcolor.BackColor = value; }
        }

        private void gridx10_Click(object sender, EventArgs e)
        {
            ColorDialog gridx10 = new ColorDialog();
            gridx10.Color = gridx10Color.BackColor;

            if (DialogResult.OK == gridx10.ShowDialog())
            {
                gridx10Color.BackColor = gridx10.Color;
            }
        }
        public Color pGridx10Color
        {
            get
            { return gridx10Color.BackColor; }
            set
            { gridx10Color.BackColor = value; }
        }

        private void GridColor_Click(object sender, EventArgs e)
        {
            ColorDialog gColor = new ColorDialog();
            gColor.Color = GridColor.BackColor;

            if (DialogResult.OK == gColor.ShowDialog())
            {
                GridColor.BackColor = gColor.Color;
            }
        }
        public Color pGridColor
        {
            get
            { return GridColor.BackColor; }
            set
            { GridColor.BackColor = value; }
        }
        private void relod_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            pBackGroundColor = Properties.Settings.Default.BackgroundColor;
            pGridColor = Properties.Settings.Default.GridLineColor;
            pGridx10Color = Properties.Settings.Default.X10CellColor;
            pLiveCellColor = Properties.Settings.Default.CellColor;
        }
        private void buttonResetColorOption_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            pBackGroundColor = Properties.Settings.Default.BackgroundColor;
            pGridColor = Properties.Settings.Default.GridLineColor;
            pGridx10Color = Properties.Settings.Default.X10CellColor;
            pLiveCellColor = Properties.Settings.Default.CellColor;
        }


    }
}
