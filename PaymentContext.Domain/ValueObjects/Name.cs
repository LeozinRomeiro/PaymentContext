using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject {
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        if(string.IsNullOrEmpty(FirstName))
            AddNotification("FirstName","Nome invalido");
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}

