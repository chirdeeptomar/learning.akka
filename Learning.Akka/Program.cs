using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Learning.Akka.Actors;
using Learning.Akka.Messages;

namespace Learning.Akka
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("PricingActorSystem");

            Props pricingActorProps = Props.Create<PricingActor>();

            IActorRef pricingActorRef = system.ActorOf(pricingActorProps, "PricingActor");
           
            var result = pricingActorRef.Ask(new PricingRequest("Goog"));
            Console.WriteLine(result.Result);
            Console.ReadLine();
        }
    }
}
