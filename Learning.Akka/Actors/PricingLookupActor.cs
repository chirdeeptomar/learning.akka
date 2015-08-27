using System;
using System.IO;
using System.Net;
using Akka.Actor;
using Learning.Akka.Messages;
using Learning.Akka.Model;
using Newtonsoft.Json;

namespace Learning.Akka.Actors
{
    /// <summary>
    /// Actor to do talk to third party stock data provider
    /// </summary>
    public class PricingLookupActor : ReceiveActor
    {
        private string api = "http://live-nse.herokuapp.com/?symbol={0}";

        public PricingLookupActor()
        {
            Receive<PricingRequest>(request => LookupPrice(request));
        }

        private void LookupPrice(PricingRequest request)
        {
            WebClient client = new WebClient();
            var data = client.OpenRead(new Uri(String.Format(api, request.CompanyCode)));
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            var json = JsonConvert.DeserializeObject<RootObject>(s);
            Sender.Tell(json);
        }
    }
}