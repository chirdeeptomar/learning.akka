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


            var result1 = pricingActorRef1.Ask(new PricingRequest("BAJAJ-AUTO"));
            var result2 = pricingActorRef2.Ask(new PricingRequest("BEL"));
            var result3 = pricingActorRef3.Ask(new PricingRequest("ARVIND"));
            var result4 = pricingActorRef4.Ask(new PricingRequest("HDFC"));

            Console.WriteLine(result1.Result);
            Console.WriteLine(result2.Result);
            Console.WriteLine(result3.Result);
            Console.WriteLine(result4.Result);
            Console.ReadLine();
        }
    }
}
