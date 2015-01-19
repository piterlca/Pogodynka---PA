using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pogodynka
{
    public abstract class Model
    {
        protected List<View> subscribers;

        protected List<Object> Parameters;

        public abstract void LoadConfiguration(string ConfigurationPath);

        public abstract void measure();

        public void addSubscriber(View Subscriber)
        {
            subscribers.Add(Subscriber);
        }
        public bool delSubscriber(View Subscriber)
        {
            foreach (View _subscriber in subscribers)
            {
                return this.subscribers.Remove(Subscriber);
            }
            return false;
        }

        public void PropertyChanged()
        {
            notifySubscribers(Parameters);
        }
        protected void notifySubscribers(List<Object> ParametersToPass)
        {
            foreach (View subToBeNotified in subscribers)
            {
                subToBeNotified.updateView(ParametersToPass);
            }
        }



    }
}
