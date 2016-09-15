using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();

            publisher.Event1 += subscriber.EventHandler;
            publisher.FireEvent();
        }
    }

    class Event1Arg : EventArgs
    {
        public string EventDescription { get; private set; }

        public Event1Arg(string eventDescription)
        {
            EventDescription = eventDescription;
        }
    }

    class EventPublisher
    {
        public event EventHandler<Event1Arg> Event1;

        public void FireEvent()
        {
            if (Event1 != null)
            {
                Event1(this, new Event1Arg("Event sent from EventPublisher"));
            }
        }
    }

    class EventSubscriber
    {
        public void EventHandler(object obj, Event1Arg args)
        {
            Console.WriteLine("Event received: {0}", args.EventDescription);
        }
    }
}
