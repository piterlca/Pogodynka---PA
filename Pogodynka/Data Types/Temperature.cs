using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pogodynka
{
    public class Temperature
    {
        public int temperature;
        public string dateOfMeasure;

        public Temperature(int temperature, string date)
        {
            this.temperature = temperature;
            this.dateOfMeasure = date;
        }
    }
}
