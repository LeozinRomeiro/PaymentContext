using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests{
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid(){
        var doc =  new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsValid(){
        var doc =  new Document("34110468000150", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid(){
        var doc =  new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsValid(){
        var doc =  new Document("3411046800", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }
}