using LiveCharts;
using LiveCharts.Wpf;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;

namespace MyBudget_Core.View.Statistics
{
    /// <summary>
    /// Interaction logic for Charting.xaml
    /// </summary>
    public partial class Charting : UserControl
    {
        public SeriesCollection mySeries { get; set; } = new SeriesCollection();
        public List<string> labelsX { get; set; } = new string[] { "sty", "lut", "mar", "kwi", "maj", "cze", "lip", "sie", "wrz", "paz", "lis", "gru" }.ToList();
        public Charting()
        {
            InitializeComponent();
            DataContext = this;
        }
            
        public void SetXLabels(string[] labels) => chart.AxisX[0].Labels = labels.ToList();
        public void AddToChart(string title, double[] values)
        {
            var series = new LiveCharts.Wpf.LineSeries();
            series.Title = title;
            ChartValues<double> chartValues = new ChartValues<double>();
            foreach (var c in values)
                chartValues.Add(c);
            series.Values = chartValues;
            mySeries.Add(series);
        }

        public void RemoveFromChart(string title)
        {
            var toRemove = mySeries.Where(x => x.Title == title).FirstOrDefault();
            mySeries.Remove(toRemove);
        }
    }
}
