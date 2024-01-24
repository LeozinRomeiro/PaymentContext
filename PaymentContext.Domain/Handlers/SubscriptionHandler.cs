using PaymentContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Shared.Commands;
using PaymentContext.Domain.Repositories;
using Microsoft.VisualBasic;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Services;

namespace PaymentContext.Domain.Handlers{
    public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>, IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;
        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if(!command.IsValid){
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            if(_repository.DocumentExists(command.NumberDocument)){
                AddNotification("Document", "Este CPF já está em uso");
            }

                
            if(_repository.DocumentExists(command.AddressEmail)){
                AddNotification("Email", "Este Email já está em uso");
            }

            var name = new Name(command.FirstName,command.LastName);
            var document = new Document(command.NumberDocument, EDocumentType.CPF);
            var payerDocument = new Document(command.PayerDocument, EDocumentType.CPF);
            var email = new Email(command.AddressEmail);
            var payerEmail = new Email(command.PayerEmail);
            var address = new Address(command.Street,command.Number,command.Neighborhood,command.City,command.State,command.Country,command.ZipCode);

            var student = new Student(name, document, email);
            var subscription = new Subscription(null);
            var payment = new BoletoPayment(command.BarCode,command.BoletoNumber,command.PaidDate,command.ExpireDate,command.Total,command.TotalPad,
            command.Payer, payerDocument, address , payerEmail );

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payerDocument, payerEmail, email);

            _repository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo!","Sua assinatura foi confirmada");

            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            if(_repository.DocumentExists(command.NumberDocument)){
                AddNotification("Document", "Este CPF já está em uso");
            }

                
            if(_repository.DocumentExists(command.AddressEmail)){
                AddNotification("Email", "Este Email já está em uso");
            }

            var name = new Name(command.FirstName,command.LastName);
            var document = new Document(command.NumberDocument, EDocumentType.CPF);
            var payerDocument = new Document(command.PayerDocument, EDocumentType.CPF);
            var email = new Email(command.AddressEmail);
            var payerEmail = new Email(command.PayerEmail);
            var address = new Address(command.Street,command.Number,command.Neighborhood,command.City,command.State,command.Country,command.ZipCode);

            var student = new Student(name, document, email);
            var subscription = new Subscription(null);
            var payment = new PayPalPayment(command.TransactionCode,command.PaidDate,command.ExpireDate,command.Total,command.TotalPad,
            command.Payer, payerDocument, address , payerEmail );

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payerDocument, payerEmail, email);

            _repository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo!","Sua assinatura foi confirmada");

            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }
    }
}