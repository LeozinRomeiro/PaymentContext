using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject{
    public Email(string address)
    {
        AddNotifications(new Contract<Notification>().Requires().IsEmail(address, "address", "Email invalido"));
        Address = address;
    }

    public string Address {get; private set;}
}

