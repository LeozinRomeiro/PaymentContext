
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PayPalPayment : Payment
{
    public PayPalPayment(string transactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPad, string payer, Document document, Address address, Email email)
     : base(paidDate, expireDate, total, totalPad, payer, document, address, email)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode {get; set;}
}