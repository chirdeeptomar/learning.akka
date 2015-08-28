using System;
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

            IActorRef pricingActorRef1 = system.ActorOf(pricingActorProps, "PricingActor1");
            IActorRef pricingActorRef2 = system.ActorOf(pricingActorProps, "PricingActor2");
            IActorRef pricingActorRef3 = system.ActorOf(pricingActorProps, "PricingActor3");
            IActorRef pricingActorRef4 = system.ActorOf(pricingActorProps, "PricingActor4");
            
            pricingActorRef3.Tell(new PricingRequest("ARVIND")); 
            pricingActorRef1.Tell(new PricingRequest("BAJAJ-AUTO"));
            pricingActorRef2.Tell(new PricingRequest("BEL"));
            pricingActorRef4.Tell(new PricingRequest("HDFC"));
            Console.ReadLine();
        }
    }
}
