using BackendSchedule.Domain.Validation;
namespace BackendSchedule.Domain.Entities
{
    public sealed class Customer
    {
        public Customer(string name, string phone, string? email)
        {
            ValidateDomain(name, email, phone);
        }

        public string Name { get; private set; }
        public string? Email { get; private set; }
        public string Phone { get; private set; }

        private void ValidateDomain(string name, string phone, string? email)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name value");
            DomainExceptionValidation.When(string.IsNullOrEmpty(phone), "Invalid Phone value");

            Name = name;
            Email = email;
            Phone = phone;

        }

    }

}


