using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Akka.Messages
{
    public class PricingRequest
    {
        public string CompanyCode { get; private set; }

        public PricingRequest(string companyCode)
        {
            this.CompanyCode = companyCode;
        }
    }
}
