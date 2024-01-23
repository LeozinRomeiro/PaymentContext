using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class Student
{
    private IList<Subscription> _subscriptions;
    public Student(Name name, string document, string email)
    {
        Name = name;
        Document = document;
        Email = email;
        _subscriptions=new List<Subscription>();
    }
    public Name Name { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public IReadOnlyCollection<Subscription> Subscriptions { get{ return _subscriptions.ToArray(); } }

    public void AddSubscription(Subscription subscription){
        foreach(var sub in Subscriptions){
            sub.Activate();
        }

        _subscriptions.Add(subscription);
    }
}