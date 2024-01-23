
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    public CreditCardPayment(string cardHolderName, string cardNumber, string lastTransactionNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPad,
     string payer, Document document, Address address, Email email)
     : base(paidDate, expireDate, total, totalPad, payer, document, address, email)
    {
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }

    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string LastTransactionNumber { get; set; }
}