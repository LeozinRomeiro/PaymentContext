using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Commands;

public class CreatePayPalSubscriptionCommand{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NumberDocument { get;   set; }
    public string AddressEmail {get;   set;}
    
    public string TransactionCode {get; set;}
    public string PaymentNumber { get;   set; }
    public DateTime PaidDate { get;   set; }
    public DateTime ExpireDate { get;   set; }
    public decimal Total { get;   set; }
    public decimal TotalPad { get;   set; }
    public string Payer { get;   set; }
    public string PayerDocument {get;   set;}
    public Address PayerAddress {get;   set;}
    public Email PayerEmail {get;   set;}

    public string Street { get;   set; }
    public string Number { get;   set; }
    public string Neighborhood { get;   set; }
    public string City { get;   set; }
    public string State { get;   set; }
    public string Country { get;   set; }
    public string ZipCode { get;   set; }
}