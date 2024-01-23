using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public abstract class Payment : Entity
{
    protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPad, string payer, Document document, Address address, Email email)
    {
        Number = Guid.NewGuid().ToString().Replace("-","").Substring(0, 10).ToUpper();
        PaidDate = paidDate;
        ExpireDate = expireDate;
        Total = total;
        TotalPad = totalPad;
        Payer = payer;
        Document = document;
        Address = address;
        Email = email;
    }

    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPad { get; private set; }
    public string Payer { get; private set; }
    public Document Document {get; private set;}
    public Address Address {get; private set;}
    public Email Email {get; private set;}
}