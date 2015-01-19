using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
namespace Pogodynka
{
    public partial class Form1 : Form
    {
        Controllers.StripListController ctrl;
        public Form1()
        {
            InitializeComponent();
            ctrl = new Controllers.StripListController(
                new TemperatureChart(chart1), 
                new RssTemp());
            ctrl.BindToMenuAndInit(chooseCityToolStripMenuItem);
        }
    }
}
