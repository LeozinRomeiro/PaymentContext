using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTests{
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists(){
        var handler =  new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        
        command.FirstName="Bruce";
        command.LastName="Wayne";
        command.NumberDocument="99999999999";
        command.AddressEmail="hello@balta.io";

        command.BarCode="123456";
        command.BoletoNumber="123456";

        command.PaymentNumber="123456";
        command.PaidDate=DateTime.Now;
        command.ExpireDate=DateTime.Now.AddMonths(1);
        command.Total=60;
        command.TotalPad=60;
        command.Payer="WAYNE CORP";
        command.PayerDocument="12345678911";
        command.PayerEmail="CORP@dc.com";
        command.PayerDocumentType = EDocumentType.CPF;

        command.Street="Rua";
        command.Number="41";
        command.Neighborhood="teste";
        command.City="Cidade";
        command.State="Estado";
        command.Country="conta";
        command.ZipCode="CEP";

        handler.Handle(command);
        Assert.AreEqual(false,handler.IsValid);
    }
}