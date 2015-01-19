using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
namespace Pogodynka
{
    public class TemperatureChart :  View
    {
        Chart temperatureChart;

        public TemperatureChart(Chart chart)
        {
            this.temperatureChart = chart;
        }

        public override void updateView(List<Object> ParametersPassed)
        {
            List<Series> ActiveSeries = new List<Series>();
            foreach (Series series in temperatureChart.Series)
            {
                ActiveSeries.Add(series);
            }
            foreach (Series series in ActiveSeries)
            {
                try  
                {
                    temperatureChart.Series.Remove(series);
                }
                catch (InvalidOperationException)// to na pewno mozna zrobic lepiej...
                {
                }
            }

            foreach (City city in ParametersPassed)
            {
                ifSubbedUpdateChart(city);
            }
        }

        private bool ifSubbedUpdateChart(City city)
        {
            if (isSubscribed(city.cityName))
            {
                if (city.temperaturesRecorded == null)
                {
                    return false;
                }
                addSeriesToChart(city.cityName);
                foreach (Temperature temperatureRecord in city.temperaturesRecorded)
                {
                    temperatureChart.Series[city.cityName].Points.AddXY(temperatureRecord.dateOfMeasure,
                        temperatureRecord.temperature);
                }
                return true;
            }
            return false;
        }

        private void addSeriesToChart(string seriesName)
        {
            temperatureChart.Series.Add(seriesName);
            temperatureChart.Series[seriesName].ChartArea = "ChartArea1";
            temperatureChart.Series[seriesName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            temperatureChart.Series[seriesName].BorderWidth = 5;
        }

        private void delSeriesFromChart(string seriesName)
        {
            temperatureChart.Series.Remove(temperatureChart.Series[seriesName]);
        }

        public bool isSeriesDisplayed(string seriesName)
        {
            foreach(Series series in this.temperatureChart.Series)
            {
                if (series.Name == seriesName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
