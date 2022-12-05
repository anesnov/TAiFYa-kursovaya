using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAiFYa_kursovaya
{
    public partial class MainForm : Form
    {
        private STTuringMachine stt = null;
        private MTTuringMachine mtt = null;
        private List<bool> changed = new List<bool>() { true, true };
        private TimeChart chart = new TimeChart();
        TextWriter STTlog = null;
        TextWriter MTTlog = null;

        public MainForm()
        {
            InitializeComponent();

            stt = new STTuringMachine();
            mtt = new MTTuringMachine();

        }

        private void Change(int m)
        {

            if (m == 0 && changed[m])
            {
                if(STTlog != null)
                    STTlog.Close();
                STTlog = new StreamWriter(input.Text.ToString() + ".stt.log");
                stt.Tape = new TMTape(input.Text.ToString());
                STTOut.Clear();
                changed[m] = false;
            }
            else if (m == 1 && changed[m])
            {
                if (MTTlog != null)
                    MTTlog.Close();
                MTTlog = new StreamWriter(input.Text.ToString() + ".mtt.log");
                mtt.Tapes = new TMTape(input.Text.ToString());
                MTTOut.Clear();
                changed[m] = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Change(0);

            while (stt.Step != -1)
            {
                button2_Click(sender, e);
            }
            STTlog.Close();
            STTOut.ScrollToCaret();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Change(0);
            var res = stt.Next();
            STTlog.WriteLine(res);
            STTOut.AppendText(res + '\n');
            if (stt.Step == -1) STTlog.Close();
        }


        private void input_TextChanged(object sender, EventArgs e)
        {
            changed[0] = changed[1] = true;
        }

        private void MTTstart_Click(object sender, EventArgs e)
        {
            Change(1);
            while (mtt.Step != -1)
            {
                Mttstep_Click(sender, e);
            }
            MTTOut.ScrollToCaret();
        }

        private void Mttstep_Click(object sender, EventArgs e)
        {
            Change(1);
            var res = mtt.Next();
            foreach (var str in res)
            {
                MTTlog.WriteLine(str);
                MTTOut.AppendText(str + '\n');
            }

            if(mtt.Step == -1) MTTlog.Close();
            MTTOut.ScrollToCaret();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showchart.Checked)
            {
                if (chart.IsDisposed)
                    chart = new TimeChart();
                chart.Show();
                chart.Location = new Point(this.Location.X + this.Size.Width - 14, this.Location.Y);
            }
            else chart.Hide();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            chart.Location = new Point(this.Location.X + this.Size.Width - 14, this.Location.Y);
            
        }

        private bool wronginput = false;
        private void input_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            wronginput = false;
            if (e.KeyCode != Keys.D0 && e.KeyCode != Keys.D1 && e.KeyCode != Keys.Back)
                wronginput = true;
            if (Control.ModifierKeys == Keys.Shift) wronginput = true;
        }

        private void input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (wronginput)
            {
                e.Handled = true;
                ToolTip tt = new ToolTip();
                tt.Show("Только 0 и 1", this, this.input.Location, 1000);
            }
        }

        private int height;
        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            height = this.Height;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.STTOut.Height += this.Height - height;
            this.MTTOut.Height += this.Height - height;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (STTlog != null) STTlog.Close();
            if (MTTlog != null) MTTlog.Close();
        }
    }        
}
