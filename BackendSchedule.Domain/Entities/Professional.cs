using BackendSchedule.Domain.Validation;

namespace BackendSchedule.Domain.Entities
{
    public sealed class Professional : Entity
    {
        public Professional() { }
        public Professional(int id, string name, string email, string password, string phone)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, email, password, phone);
        }
        public Professional(string name, string email, string password, string phone)
        {
            ValidateDomain(name, email, password, phone);
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Phone { get; private set; }
        public List<Scheduling> SchedulingList { get; private set; } = new List<Scheduling>();
        public List<Work> WorkList { get; private set; } = new List<Work>();

        private void ValidateDomain(string name, string email, string password, string phone)
        {

            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }
    }
}
