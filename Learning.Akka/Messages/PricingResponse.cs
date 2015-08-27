using System.Collections.Generic;

namespace Learning.Akka.Messages
{
    public class PricingResponse   
    {
        public string CompanyCode { get; private set; }
        public double StockPrice { get; private set; }
        public string StockExchange { get; private set; }

        public PricingResponse(string companyCode, double stockPrice, string stockExchange)
        {
            CompanyCode = companyCode;
            StockExchange = stockExchange;
            StockPrice = stockPrice;
        }

        public override string ToString()
        {
            return string.Format("CompanyCode: {0}, StockExchange: {1}, StockPrice: {2}", CompanyCode, StockExchange, StockPrice);
        }
    }
}
