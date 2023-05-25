using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class TestColor : Form
    {
        public TestColor()
        {
            InitializeComponent();
        }

        private void TestColor_Load(object sender, EventArgs e)
        {
            Color color1, color2, color3, color4;
            color1 = Color.FromArgb(150, 35, 88);
            color2 = Color.FromArgb(238, 150, 215);
            color3 = Color.FromArgb(250, 139, 241);
            color4 = Color.FromArgb(107, 67, 97);
            button1.BackColor = color1;
            button2.BackColor = color2;
            button3.BackColor = color3;

            button5.BackColor = Color.FromArgb(35, 64, 107); 
            button6.BackColor = Color.FromArgb(150, 185, 238); 
            button7.BackColor = Color.FromArgb(77, 140, 235); 

            button9.BackColor = Color.FromArgb(33, 107, 48);
            button10.BackColor = Color.FromArgb(145, 238, 164);
            button11.BackColor = Color.FromArgb(73, 235, 105);

            button13.BackColor = Color.FromArgb(107, 98, 39);
            button14.BackColor = Color.FromArgb(238, 227, 157);
            button15.BackColor = Color.FromArgb(235, 215, 84);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = MyDialog.Color;
            }
        }
    }
}
