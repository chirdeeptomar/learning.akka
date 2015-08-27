using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Event;
using Learning.Akka.Messages;

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
            var response = new PricingResponse(request.CompanyCode, 110.2, "NASDAQ");
            Sender.Tell(response);
        }
    }
}
