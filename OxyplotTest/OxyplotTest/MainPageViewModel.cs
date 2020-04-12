using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Threading.Tasks;

namespace OxyplotTest
{
    public class MainPageViewModel
    {
        public bool isPLaying = false;
        public PlotModel ScatterPlotModel { get; set; }
        public PlotModel LinePlotModel { get; set; }
        private LineSeries lineSeries;

        public MainPageViewModel()
        {
            ScatterPlotModel = new PlotModel { Title = "ScatterPlot", };

            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
            var r = new Random(314);
            for (int i = 0; i < 100; i++)
            {
                var x = r.NextDouble();
                var y = r.NextDouble();
                var size = r.Next(5, 15);
                var colorValue = r.Next(100, 1000);
                scatterSeries.Points.Add(new ScatterPoint(x, y, size, colorValue));
            }

            ScatterPlotModel.Series.Add(scatterSeries);
            ScatterPlotModel.Axes.Add(new LinearColorAxis { Position = AxisPosition.Right, Palette = OxyPalettes.Jet(200) });


            //now, LinePlot
            LinePlotModel = new PlotModel { Title = "Line Plot", };

            lineSeries = new ThreeColorLineSeries
            {
                MarkerType = MarkerType.Square,
                MarkerFill = OxyColor.FromRgb(100, 100, 100),
                MarkerSize = 4,
                LimitHi = 0.8,
                LimitLo = 0.2,
                ColorHi = OxyColor.FromRgb(0, 255, 0),
                ColorLo = OxyColor.FromRgb(0, 0, 255),
                Color = OxyColor.FromRgb(255,0,0),
                StrokeThickness = 2,
            };
            for (int i = 0; i < 40; i++)
            {
                //var x = r.NextDouble();
                var y = r.NextDouble();
                var size = r.Next(5, 15);
                var colorValue = r.Next(100, 1000);
                lineSeries.Points.Add(new DataPoint(i, y));
            }

            //lineSeries.Color = OxyColor.FromRgb(255, 0, 0);


            LinePlotModel.Series.Add(lineSeries);
            LinePlotModel.Axes.Add(new LinearAxis()
            {
                Key = "yAxis",
                Position = AxisPosition.Left,
                MajorGridlineColor = OxyColor.FromRgb(180, 180, 180),
                MajorGridlineStyle = LineStyle.Dot,
                MajorStep = 0.2,
                MinorGridlineColor = OxyColor.FromRgb(230, 230, 230),
                MinorGridlineStyle = LineStyle.LongDash,
                MinorGridlineThickness = 0.5,
                IsPanEnabled = false
            });
            LinePlotModel.Axes.Add(new LinearAxis()
            {
                Key = "xAxis",
                Position = AxisPosition.Bottom,
                IsPanEnabled = false
            });
            //LinePlotModel.Axes.Add(new LinearColorAxis { Position = AxisPosition.Left, Palette = OxyPalettes.Jet(200) });

        }

        public async Task generateData()
        {
            while (isPLaying)
            {
                lineSeries.Points.RemoveAt(0);
                var r = new Random();
                var y = r.NextDouble();
                double i = lineSeries.Points[lineSeries.Points.Count - 1].X + 1;
                lineSeries.Points.Add(new DataPoint(i, y));
                LinePlotModel.InvalidatePlot(true);
                await Task.Delay(100);
            }
        }
    }
}
