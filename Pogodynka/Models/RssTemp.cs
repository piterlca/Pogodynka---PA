using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading;
namespace Pogodynka
{
    public class RssTemp: Model
    {
        private List<City> availableCities;

        public RssTemp()
        {
            availableCities = new List<City>();
            Parameters = new List<Object>();
            subscribers = new List<View>();
            LoadConfiguration("AvailableCitiesConf.xml");

            Thread t = new Thread(new ThreadStart(RssMeasuring));
            t.Start();
        }
        public List<City> getAvailableCities()
        {
            return availableCities;
        }

        public override void measure()
        {
            foreach (City cityToGetTemp in availableCities)    
            {
                Parameters.Add(new City(
                    cityToGetTemp.cityName,
                    getTemperatureFromRss(cityToGetTemp)));
            }
        }
        private List<Temperature> getTemperatureFromRss(City cityForTemperature)
        {
            WebResponse response;
            if ((response = RequestConnection(cityForTemperature.PathToReport)) == null)    //TODO obsluzyc to lepiej
            {
                return null;
            }
            Stream stream = response.GetResponseStream();
            XmlNodeList nodes = XmlTools.getXmlNodes(stream);
            List<Temperature> temperaturesInCities = new List<Temperature>();

            foreach (XmlNode node in nodes)
            {
                temperaturesInCities.Add(new Temperature(int.Parse(this.readTemperatureFromString(node["description"].InnerText)),
                node["title"].InnerText)); 
            }
            return temperaturesInCities;
        }
        private WebResponse RequestConnection(string path)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            request.Timeout = 5000;
            WebResponse response = null;
            try
            {
                return response = request.GetResponse();
            }
            catch (System.Net.WebException)
            {
                System.Windows.Forms.MessageBox.Show("Server does not respond for"+path+".\nPlease try again later.");
                return null;
            }
        }

        private enum States { TEMPERATURE, WHITE, MARK, Deg, dEg, STORE, MINUS };
        private string readTemperatureFromString(string text)
        {
            States state = States.WHITE;

            string temperatura = null;

            foreach (char sign in text)
            {
                switch (state) //***przejscia***//
                {
                    case States.WHITE:
                        if (sign <= '9' && sign >= '0')
                            state = States.TEMPERATURE;
                        else if (sign == '&')
                            state = States.MARK;
                        else if (sign == '-')
                            state = States.MINUS;
                        break;

                    case States.MINUS:
                        if (sign <= '9' && sign >= '0' || sign == '-')
                        {
                            temperatura += '-';
                            state = States.TEMPERATURE;
                        }
                        else
                        {
                            state = States.WHITE;
                        }

                        break;

                    case States.TEMPERATURE:
                        if (sign <= '9' && sign >= '0') state = States.TEMPERATURE;
                        else if (sign == '&')
                            state = States.MARK;
                        else if (sign == '-')
                            state = States.MINUS;
                        else
                            state = States.WHITE;
                        break;

                    case States.MARK:
                        if (sign <= '9' && sign >= '0')
                        {
                            temperatura = null;
                            state = States.TEMPERATURE;
                        }
                        if (sign == 'd')
                            state = States.Deg;
                        else if (sign == '-')
                            state = States.MINUS;
                        else
                            state = States.WHITE;
                        break;

                    case States.Deg:
                        if (sign <= '9' && sign >= '0')
                        {
                            temperatura = null;
                            state = States.TEMPERATURE;
                        }
                        if (sign == 'e')
                            state = States.dEg;
                        else if (sign == '-')
                            state = States.MINUS;
                        else
                            state = States.WHITE;
                        break;

                    case States.dEg:
                        if (sign <= '9' && sign >= '0')
                        {
                            temperatura = null;
                            state = States.TEMPERATURE;
                        }
                        if (sign == 'g')
                            state = States.STORE;
                        else if (sign == '-')
                            state = States.MINUS;
                        else
                            state = States.WHITE;
                        break;

                }
                switch (state) //***akcje dla stanow***//
                {
                    case States.TEMPERATURE:
                        temperatura += sign;
                        break;

                    case States.STORE:
                        return temperatura;
                }
            }
            return null;
        }

        public override void LoadConfiguration(string ConfigurationPath)
        {
            XmlNodeList nodes = XmlTools.getXmlNodes(ConfigurationPath);
            foreach(XmlNode node in nodes)
            {
                this.availableCities.Add(new City(node["City"].InnerText, node["PathToReport"].InnerText));
            }
        }

        public void RssMeasuring()
        {
            while (true)
            {
                List<Object> LastParameters = new List<object>(Parameters);
                Parameters.Clear();
                measure();

                Thread.Sleep(60000);
            }

        }


    }
}
