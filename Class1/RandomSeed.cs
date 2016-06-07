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
    public partial class RandomSeed : Form
    {
        int randomNumber;
        public RandomSeed()
        {
            InitializeComponent();
            numericUpDownrandomseed.Maximum = Int32.MaxValue;
        }

        private void buttonRandomize_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            randomNumber = rng.Next();
            numericUpDownrandomseed.Value = randomNumber;

        }
        public int numRandomnumberseed
        {
            get
            { return (int)numericUpDownrandomseed.Value; }
            set
            { numericUpDownrandomseed.Value = value; }
        }

    }
}
