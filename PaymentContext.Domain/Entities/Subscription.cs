using PaymentContext.Shared.Entities;
using Flunt.Validations;
using Flunt.Notifications;

namespace PaymentContext.Domain.Entities;

public class Subscription : Entity
{
    private IList<Payment> _payments;
    public Subscription(DateTime? expireDate, Address address)
    {
        CreateDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        ExpireDate = expireDate;
        Address = address;
        Active = true;
        _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; private set;}
    public DateTime LastUpdateDate { get; private set;}
    public DateTime? ExpireDate { get; private set;}
    public bool Active {get; private set;}
    public Address Address {get; private set;}
    public IReadOnlyCollection<Payment> Payments {get {return _payments.ToArray();}}

    public void AddPayment(Payment payment){
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento deve ser futura")
        );
        _payments.Add(payment);
    }

    public void Activate(){
        Active = true;
        LastUpdateDate = DateTime.Now;
    }

    public void Inactivate(){
        Active = false;
        LastUpdateDate = DateTime.Now;
    }
}