using System;
using Akka.Actor;
using Learning.Akka.Messages;

namespace Learning.Akka.Actors
{
    class PricingActor : ReceiveActor
    {
        public PricingActor()
        {
            Receive<PricingRequest>(message => ProcessRequest(message));
            Receive<PricingResponse>(response =>
            {
                Console.WriteLine(response);
            });
        }

        private void ProcessRequest(PricingRequest request)
        {
            Console.WriteLine(@"Finding stock prices for {0}", request.CompanyCode);

            IActorRef pricingLookUpActorRef = Context.ActorOf(Props.Create<PricingLookupActor>(), "PriceLookup" + Guid.NewGuid());
            pricingLookUpActorRef.Tell(request);
        }
    }
}
