using PaymentContext.Domain.Handlers;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTests{
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists(){
        var handler =  new SubscriptionHandler();
    }
}