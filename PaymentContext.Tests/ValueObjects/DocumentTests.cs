using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests{
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid(){
        var doc =  new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsValid(){
        var doc =  new Document("34110468000150", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid(){
        var doc =  new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
    }
    [TestMethod]
    [DataTestMethod]
    [DataRow("34110468001")]
    [DataRow("34110468895")]
    [DataRow("34110462536")]
    public void ShouldReturnErrorWhenCPFIsValid(string cpf){
        var doc =  new Document(cpf, EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}