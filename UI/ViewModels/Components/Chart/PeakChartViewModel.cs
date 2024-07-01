using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ReactiveUI;
using SkiaSharp;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace UI.ViewModels.Components.Chart
{
    public class PeakChartViewModel : ViewModelBase
    {
        private ObservableCollection<ISeries> series;

        public PeakChartViewModel()
        {
            Series = new ObservableCollection<ISeries>
            {
                new LineSeries<int>
                {
                    Values = new int[] {  },
                    Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 1 },
                    Fill = null
                }
            };
            Console.WriteLine("PeakChartViewModel initialized.");
        }

        public ObservableCollection<ISeries> Series
        {
            get => series;
            set => this.RaiseAndSetIfChanged(ref series, value);
        }

        public void UpdateSeries(ObservableCollection<Tuple<int, int>> peakPositions)
        {
            var values = peakPositions.Select(p => p.Item2).ToArray();
            Series[0].Values = values;
            this.RaisePropertyChanged(nameof(Series));
            Console.WriteLine("Series updated with values: " + string.Join(", ", values));
        }
    }
}
