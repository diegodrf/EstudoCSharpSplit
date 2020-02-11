using System;
using System.Collections.Generic;
using System.Text;

namespace Split.Entities
{
    class Participant
    {
        public string SubordinateMerchantId { get; set; }
        public int Amount { get; set; }
        public Dictionary<string, double> Fares = new Dictionary<string, double>();

        public Participant()
        {
        }

        public Participant(string subordinateMerchantId, int amount, double mdr, int fee)
        {
            SubordinateMerchantId = subordinateMerchantId;
            Amount = amount;
            Fares.Add("Mdr", mdr);
            Fares.Add("Fee", fee);
        }
    }
}
