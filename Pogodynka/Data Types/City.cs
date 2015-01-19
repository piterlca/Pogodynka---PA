using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pogodynka
{
    public class City : Object
    {
        public string cityName;
        public string PathToReport;
        public List<Temperature> temperaturesRecorded;

        public City(string Name, List<Temperature> temperatureRecord)
        {
            this.cityName = Name;
            this.temperaturesRecorded = temperatureRecord;
        }
        public City(string Name, string Path)
        {
            this.cityName = Name;
            this.PathToReport = Path;
        }

        public City()
        {
        }
    }
}
