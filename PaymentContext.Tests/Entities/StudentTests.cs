using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests{
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Payment _payment;
        private readonly Address _address;
        public StudentTests()
        {
            _name = new Name("Leonardo","romeiro");
            _document = new Document("34110468895", EDocumentType.CPF);
            _email = new Email("leozin@gmail.com");
            _address = new Address("Rua conde","47","Bairro Do Castelo","Castelo Branco","SC","Brassil","CEP");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            _payment = new PayPalPayment("123",DateTime.Now, DateTime.Now.AddDays(5), 10,10,"ATAK",_document,_address,_email);
            _student.AddSubscription(_subscription);
        }
        [TestMethod]
        public void ShoulReturnErrorWhenHadActiveSubscription(){
            
            _subscription.AddPayment(_payment);
            _student.AddSubscription(_subscription);
            
            Assert.IsFalse(_student.IsValid);
        }
        [TestMethod]
        public void ShoulReturnErrorWhenSubscriptionHasNoPayment(){
            
            var _subscriptionNoPayment = new Subscription(null);
            _student.AddSubscription(_subscriptionNoPayment);

            Assert.IsFalse(_student.IsValid);
        }
        
        [TestMethod]
        public void ShoulReturnSuccessWhenNoActiveSubscription(){

            _subscription.AddPayment(_payment);
            
            Assert.IsTrue(_student.IsValid);
        }
    }
}

