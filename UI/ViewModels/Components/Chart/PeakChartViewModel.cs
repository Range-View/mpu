using Entities.Frame;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ReactiveUI;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace UI.ViewModels.Components.Chart
{
    public class PeakChartViewModel : ViewModelBase
    {
        private ObservableCollection<ISeries> series;
        private Axis[] yAxes;
        private Axis[] xAxes;

        public PeakChartViewModel()
        {
            Series = new ObservableCollection<ISeries>();
            YAxes = new Axis[]
            {
                new Axis
                {
                    MinLimit = 0,
                    MaxLimit = 300
                }
            };
            XAxes = new Axis[]
            {
                new Axis
                {
                    MinLimit = 0,
                    MaxLimit = 300
                }
            };
        }

        public ObservableCollection<ISeries> Series
        {
            get => series;
            set => this.RaiseAndSetIfChanged(ref series, value);
        }

        public Axis[] YAxes
        {
            get => yAxes;
            set => this.RaiseAndSetIfChanged(ref yAxes, value);
        }

        public Axis[] XAxes
        {
            get => xAxes;
            set => this.RaiseAndSetIfChanged(ref xAxes, value);
        }

        public void UpdateSeries(CurrentFrame currentFrame)
        {
            Series.Clear();

            XAxes[0].MaxLimit = currentFrame.Range.Cols;
            YAxes[0].MaxLimit = currentFrame.Insights.MaxValue * 1.2;

            var colorPalette = new[]
                {
                    SKColor.Parse("#FF6F61"), // Coral
                    SKColor.Parse("#FFD700"), // Gold
                    SKColor.Parse("#32CD32"), // Lime Green
                    SKColor.Parse("#FF69B4"), // Hot Pink
                    SKColor.Parse("#800080"), // Purple
                    SKColor.Parse("#FFA500"), // Orange
                    SKColor.Parse("#00CED1"), // Dark Turquoise
                    SKColor.Parse("#FF4500"), // Orange Red
                };
            int colorIndex = 0;

            foreach (var obj in currentFrame.Insights.DetectedObjects)
            {
                var series = new LineSeries<LiveChartsCore.Kernel.Coordinate>
                {
                    Values = obj.NormalizedPoints
                        .Select(p => new LiveChartsCore.Kernel.Coordinate(p.Y, p.X))
                        .ToList(),
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 0.65, 
                    TooltipLabelFormatter = (chartPoint) => $"X: {chartPoint.SecondaryValue:F2}, Y: {chartPoint.PrimaryValue:F2}",
                    AnimationsSpeed = TimeSpan.FromMilliseconds(300),
                    EasingFunction = EasingFunctions.CubicOut,
                    Stroke = null,
                    GeometryStroke = new SolidColorPaint(colorPalette[colorIndex % colorPalette.Length]) { StrokeThickness = 5 }

                };


                Series.Add(series);
                colorIndex++;
            }


            this.RaisePropertyChanged(nameof(Series));
            this.RaisePropertyChanged(nameof(XAxes));
            this.RaisePropertyChanged(nameof(YAxes));
        }




    }
}
