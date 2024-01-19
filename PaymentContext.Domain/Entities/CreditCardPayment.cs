namespace PaymentContext.Domain.Entities;

public class CreditCardPayment
{
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string LastTransactionNumber { get; set; }
}