namespace PaymentContext.Domain.Entities;

public class BoletoPayment : Payment
{
    public string BarCode { get; set; }
    public string BoletoNumber { get; set; }
}