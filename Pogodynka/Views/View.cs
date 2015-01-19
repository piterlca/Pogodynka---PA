using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pogodynka
{
    public abstract class View
    {
       public abstract void updateView(List<Object> ParametersPassed);

       protected List<string> subbedCities = new List<string>();
       public void addCityToSub(string city)
       {
           subbedCities.Add(city);
       }
       public bool delCityFromSub(string city)
       {
           return subbedCities.Remove(city);
       }

       protected Boolean isSubscribed(string city)
       {
           foreach (string cityName in subbedCities)
               if (cityName == city)
               {
                   return true;
               }
           return false;
       }
    }
}
