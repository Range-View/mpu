using Avalonia.Threading;
using Entities.Frame;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ReactiveUI;
using SkiaSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

            var colorPalette = new[] { SKColors.Red, SKColors.Blue, SKColors.Green, SKColors.Purple };
            int colorIndex = 0;

            foreach (var obj in currentFrame.Insights.DetectedObjects)
            {

                var series = new LineSeries<LiveChartsCore.Kernel.Coordinate>
                {
                    Values = obj.NormalizedPoints
                        .Select(p => new LiveChartsCore.Kernel.Coordinate(p.Y, p.X))
                        .ToList(),
                    Stroke = new SolidColorPaint(colorPalette[colorIndex % colorPalette.Length], 3),
                    Fill = null,
                    GeometryFill = new SolidColorPaint(SKColors.Transparent),
                    GeometryStroke = new SolidColorPaint(SKColors.Transparent),
                    TooltipLabelFormatter = null
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
