using BackendSchedule.Domain.Validation;

namespace BackendSchedule.Domain.Entities
{
    public sealed class Work : Entity
    {
        public Work(int id, string name, Professional professional, TimeSpan duration, double? price)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, professional, duration, price);
        }
        public Work(string name, Professional professional, TimeSpan duration, double? price)
        {
            ValidateDomain(name, professional, duration, price);
        }
        public string Name { get; private set; }
        public Professional Professional { get; private set; }
        public TimeSpan Duration { get; private set; }
        public double? Price { get; private set; }

        private void ValidateDomain(string name, Professional professional, TimeSpan duration, double? price)
        {
            DomainExceptionValidation.When(duration == TimeSpan.Zero, "Invalid Duration value");

            Name = name;
            Professional = professional;
            Duration = duration;
            Price = price;
        }
    }
}


