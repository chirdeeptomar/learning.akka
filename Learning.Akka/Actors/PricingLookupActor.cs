using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Akka.Actor;
using Learning.Akka.Messages;
using Learning.Akka.Model;
using Newtonsoft.Json;

namespace Learning.Akka.Actors
{
    /// <summary>
    /// Actor to talk to third party stock data provider
    /// </summary>
    public class PricingLookupActor : ReceiveActor
    {
        private string api = "http://live-nse.herokuapp.com/?symbol={0}";

        public PricingLookupActor()
        {
            Receive<PricingRequest>(request => LookupPrice(request));
            
            Receive<PricingResponse>(response =>
            {
                Context.Parent.Tell(response);
            });
        }
        
        private void LookupPrice(PricingRequest request)
        {
            WebClient client = new WebClient();
            var address = new Uri(String.Format(api, request.CompanyCode));
            client.DownloadStringTaskAsync(address).ContinueWith(

                httpRequest =>
                {
                    var response = httpRequest.Result;
                    var json = JsonConvert.DeserializeObject<RootObject>(response);
                    decimal price = json.data[0].sellPrice1 == "-"
                        ? Decimal.Zero
                        : Decimal.Parse(json.data[0].sellPrice1);
                    return new PricingResponse (request.CompanyCode, price, "NSE");
                }, TaskContinuationOptions.AttachedToParent & TaskContinuationOptions.ExecuteSynchronously).PipeTo(Self);
        }
    }
}