using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAiFYa_kursovaya
{
    public partial class TimeChart : Form
    {
        public TimeChart()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message message)
        {
            //этот код предотвратит возможность перемещения формы на экране
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }

        CancellationTokenSource cts1;
        CancellationTokenSource cts2;
        private async Task buildChart()
        {
            if (cts1 != null && cts2 != null)
            {
                try
                {
                    while (checkstart.Checked)
                    {
                    
                        int count1 = chart.Series[0].Points.Count;
                        int res1 = await Task.Run(() => STTuringMachine.Evaluate(count1), cts1.Token);
                        chart.Series[0].Points.AddXY(count1, res1);

                        int count2 = chart.Series[1].Points.Count;
                        int res2 = await Task.Run(() => MTTuringMachine.Evaluate(count1), cts2.Token);
                        chart.Series[1].Points.AddXY(count2, res2);
                    }                    
                }
                catch (NullReferenceException) { }
                finally { cts1 = null; cts2 = null; }
            }
        }
        
        private async void checkstart_CheckedChanged(object sender, EventArgs e)
        {
            if (checkstart.Checked)
            {
                checkstart.Text = "Стоп";
                checkstart.BackColor = Color.Tomato;

                clearchart.Enabled = false;

                cts1 = new CancellationTokenSource();
                cts2 = new CancellationTokenSource();
                await buildChart();
            }
            else
            {
                checkstart.Text = "Старт";
                checkstart.BackColor = Form.DefaultBackColor;
                clearchart.Enabled = true;

                cts1.Cancel();
                cts1 = null;
                cts2.Cancel();
                cts2 = null;
            }
        }

        private void clearchart_Click(object sender, EventArgs e)
        {
            if (!checkstart.Checked)
            {
                chart.Series[0].Points.Clear();
                chart.Series[1].Points.Clear();
            }
        }
        private void TimeChart_Load(object sender, EventArgs e)
        {
            chart.Legends.Add("Машины Тьюринга");

            chart.Series.Add("STT");
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series[0].LegendText = "Однолеточная";
            chart.Series[0].Color = Color.Blue;
            chart.Series[0].BorderWidth = 2;

            chart.Series.Add("MTT");
            chart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series[1].LegendText = "Многоленточная";
            chart.Series[1].Color = Color.Red;
            chart.Series[1].BorderWidth = 2;
        }

        private int height;
        private void TimeChart_ResizeEnd(object sender, EventArgs e)
        {
            chart.Height += this.Height - height;             
        }

        private void TimeChart_ResizeBegin(object sender, EventArgs e)
        {
            height = this.Height;
        }
    }
}
