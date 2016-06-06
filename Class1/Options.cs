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
            ColorDialog dlg = new ColorDialog();

            dlg.Color = backgroundcolor.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                backgroundcolor.BackColor = dlg.Color;
            }
        }
    }
}
