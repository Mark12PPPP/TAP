using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAP
{
    public partial class Gui : Form
    {
        private Print _print;
        private Dmm _dmm;

        public Gui()
        {
            InitializeComponent();
            InitializeHardware();
        }

        private void InitializeHardware()
        {
            _print = new Print();
            _dmm = new Dmm();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _print.ReadIoExpander();
            _print.Ausgabe7Segment(Print.Segment.Led3);

            bool buttonStateS1 = _print.GetButton(Print.Buttons.S1);
            if (buttonStateS1 == false)
            {
                Panel_S1.BackColor = Color.Black;
                // TODO public funktion zum led setzen in print klasse
                _print.WriteCommand(CommandByte.ConfigPort0, 0xF0);
            }
            else
            {
                Panel_S1.BackColor = Color.White;
            }

            bool buttonStateS2 = _print.GetButton(Print.Buttons.S2);
            if (buttonStateS2 == false)
            {
                Panel_S2.BackColor = Color.Black;
            }
            else
            {
                Panel_S2.BackColor = Color.White;
            }

            bool buttonStateS3 = _print.GetButton(Print.Buttons.S3);
            if (buttonStateS3 == false)
            {
                Panel_S3.BackColor = Color.Black;
            }
            else
            {
                Panel_S3.BackColor = Color.White;
            }

            bool buttonStateS4 = _print.GetButton(Print.Buttons.S4);
            if (buttonStateS4 == false)
            {
                Panel_S4.BackColor = Color.Black;
            }
            else
            {
                Panel_S4.BackColor = Color.White;
            }
        }
    }

}
