using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand 
{ 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NumberDocument { get;   set; }
    public string AddressEmail {get;   set;}
    
    public string BarCode { get; set; }
    public string BoletoNumber { get; set; }

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

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
            .IsGreaterThan(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
            .IsLowerThan(FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
        );
    }
}