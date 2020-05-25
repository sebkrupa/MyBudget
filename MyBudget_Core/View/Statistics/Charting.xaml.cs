using LiveCharts;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyBudget_Core.View.Statistics
{
    /// <summary>
    /// Interaction logic for Charting.xaml
    /// </summary>
    public partial class Charting : UserControl
    {
        public SeriesCollection mySeries { get; set; } = new SeriesCollection();
        public Charting()
        {
            InitializeComponent();
            SetXLabels_Months();
            DataContext = this;
        }

        public void SetXLabels_Years(string[] years) => chart.AxisX[0].Labels = years.ToList();
        public void SetXLabels_Months() => chart.AxisX[0].Labels = new string[] { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" }.ToList();
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

        public void RemoveAllFromChart() => mySeries.Clear();

        private void MenuItem_ZoomIn(object sender, System.Windows.RoutedEventArgs e)
        {
            var mouseCoordinates = Mouse.GetPosition(this);
            LiveCharts.Dtos.CorePoint point = new LiveCharts.Dtos.CorePoint(mouseCoordinates.X, mouseCoordinates.Y);
            mySeries.Chart.ZoomIn(point);
        }

        private void MenuItem_ZoomOut(object sender, System.Windows.RoutedEventArgs e)
        {
            var mouseCoordinates = Mouse.GetPosition(this);
            LiveCharts.Dtos.CorePoint point = new LiveCharts.Dtos.CorePoint(mouseCoordinates.X, mouseCoordinates.Y);
            mySeries.Chart.ZoomOut(point);
        }

        private void MenuItem_ZoomReset(object sender, System.Windows.RoutedEventArgs e) => mySeries.Chart.ClearZoom();
    }
}
