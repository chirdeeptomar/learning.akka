using System;
using Akka.Actor;
using Akka.Util.Internal;
using Learning.Akka.Messages;
using Learning.Akka.Model;

namespace Learning.Akka.Actors
{
    class PricingActor : ReceiveActor
    {
        public PricingActor()
        {
            Receive<PricingRequest>(message => ProcessRequest(message));
        }

        private void ProcessRequest(PricingRequest request)
        {
            Console.WriteLine(@"Finding stock prices for {0}", request.CompanyCode);

            IActorRef pricingLookUpActorRef = Context.ActorOf(Props.Create<PricingLookupActor>(), "PriceLookup");
            var data = pricingLookUpActorRef.Ask(request).Result;
            var json = data.AsInstanceOf<RootObject>();
            var price = json.data[0].sellPrice1 == "-" ? Decimal.Zero : Decimal.Parse(json.data[0].sellPrice1);
            var response = new PricingResponse(request.CompanyCode, price  , "NSE");
            Sender.Tell(response);
        }
    }
}
