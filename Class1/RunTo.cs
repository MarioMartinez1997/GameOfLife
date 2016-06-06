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
    public partial class RunTo : Form
    {
        public RunTo()
        {
            InitializeComponent();
        }
        public int numRunToo
        {
            get
            { return (int)numericUpDownRunTo.Value; }
            set
            { numericUpDownRunTo.Value = value; }
        }
    }
}
