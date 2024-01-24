using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class CreateBoletoSubscriptionCommandTests{
    [TestMethod]
    public void ShouldReturnErrorWhenNameIsInvalid(){
        var command = new CreateBoletoSubscriptionCommand();

        command.FirstName = "";
        command.LastName = "PararalepipedoPararalepipedoPararalepipedo";
        command.Validate();

        Assert.IsFalse(command.IsValid);
    }
}