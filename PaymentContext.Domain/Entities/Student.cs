namespace PaymentContext.Domain.Entities;

public class Student
{
    private List<Subscription> _subscriptions;
    public Student(string firstName, string lastName, string document, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        Email = email;
        _subscriptions=new();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string Address {get; set;}
    public IReadOnlyCollection<Subscription> Subscriptions { get{ return _subscriptions.ToArray(); } }

    public void AddSubscription(Subscription subscription){
        foreach(var sub in Subscriptions){
            sub.Active = false;
        }

        _subscriptions.Add(subscription);
    }
}