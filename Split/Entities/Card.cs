using System;
using System.Collections.Generic;
using System.Text;

namespace Split.Entities
{
    abstract class Card
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Brand { get; set; }
        public bool SaveCard { get; set; }

        public Card()
        {
        }

        public Card(string cardNumber, string holder, string expirationDate, string securityCode, string brand, bool saveCard)
        {
            CardNumber = cardNumber;
            Holder = holder;
            ExpirationDate = expirationDate;
            SecurityCode = securityCode;
            Brand = brand;
            SaveCard = saveCard;
        }
    }
}
