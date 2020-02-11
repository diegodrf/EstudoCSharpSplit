using System;
using System.Collections.Generic;
using System.Text;

namespace Split.Entities
{
    class CreditCard : Card
    {
        public CreditCard()
        {
        }

        public CreditCard(string cardNumber, string holder, string expirationDate, string securityCode, string brand, bool saveCard) 
            : base(cardNumber, holder, expirationDate, securityCode, brand, saveCard)
        {
        }
    }
}
