
namespace PaymentContext.Domain.Entities;

public class BoletoPayment : Payment
{
    public BoletoPayment(string barCode, string boletoNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPad,
        string payer, string document, string address, string email)
        : base(paidDate, expireDate, total, totalPad, payer, document, address, email)
    {
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }

    public string BarCode { get; set; }
    public string BoletoNumber { get; set; }
}