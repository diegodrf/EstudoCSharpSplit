using System;
using System.Collections.Generic;
using System.Text;
using Split.Entities.Enums;

namespace Split.Entities
{
    class Payment
    {
        public string Type { get; set; }
        public int Amount { get; set; }
        public Dictionary<string, string> SplitTransaction { get; set; } = new Dictionary<string, string>();
        public bool Capture { get; set; }
        public Card CreditCard { get; set; }
        public Card DebitCard { get; set; }
        public int Installments { get; set; }
        public string Softdescriptor { get; set; }
        public FraudAnalysis FraudAnalysis { get; set; }
        public List<Participant> SplitPayments { get; set; } = new List<Participant>();
        public Uri ReturnUrl { get; set; }

        public Payment()
        {
        }

        public Payment(string type, int amount, string discountType, bool capture, int installments, string softdescriptor, Card cardData)
        {
            Type = type;
            Amount = amount;
            SplitTransaction.Add("MasterRateDiscountType", discountType);
            Capture = capture;
            Installments = installments;
            Softdescriptor = softdescriptor;
            if (Type == PaymentTypes.CreditCard)
            {
                CreditCard = cardData;
            }
            else
            {
                DebitCard = cardData;
            }
        }

        public Payment(string type, int amount, string discountType, bool capture, int installments, string softdescriptor, Card cardData, FraudAnalysis fraudAnalysis) 
            : this(type, amount, discountType, capture, installments, softdescriptor, cardData)
        {
            FraudAnalysis = fraudAnalysis;
        }
        public Payment(string type, int amount, string discountType, bool capture, int installments, string softdescriptor, Card cardData, Uri returnUrl)
            : this(type, amount, discountType, capture, installments, softdescriptor, cardData)
        {
            ReturnUrl = returnUrl;
        }

        public void AddParticipant(Participant participant)
        {
            SplitPayments.Add(participant);
        }
        public void AddParticipant(string subordinateMerchantId, int amount, double mdr, int fee)
        {
            Participant participant = new Participant(subordinateMerchantId, amount, mdr, fee);
            AddParticipant(participant);
        }
        public void AddParticipant(params Participant[] participants)
        {
            foreach (Participant participant in participants)
            {
                AddParticipant(participant);
            }
        }
    }
}
