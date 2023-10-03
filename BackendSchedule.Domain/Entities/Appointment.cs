using BackendSchedule.Domain.Validation;

namespace BackendSchedule.Domain.Entities
{
    public sealed class Appointment : Entity
    {
        public Appointment(int id, Scheduling scheduling, Work work, Customer customer, TimeSpan startTime)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;

            ValidateDomain(scheduling, work, customer, startTime);
        }

        public Appointment(Scheduling scheduling, Work work, Customer customer, TimeSpan startTime)
        {
            ValidateDomain(scheduling, work, customer, startTime);
        }

        public Scheduling Scheduling { get; private set; }
        public int SchedulingId { get; private set; }
        public Work Work { get; private set; }
        public int WorkId { get; private set; }
        public Customer Customer { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }

        private void ValidateDomain(Scheduling scheduling, Work work, Customer customer, TimeSpan startTime)
        {
            DomainExceptionValidation.When(scheduling == null, "Invalid Scheduling value");
            DomainExceptionValidation.When(work == null, "Invalid Work value");
            DomainExceptionValidation.When(customer == null, "Invalid Customer value");
            DomainExceptionValidation.When(startTime == TimeSpan.Zero, "Invalid StartTime value");

            Scheduling = scheduling!;
            Work = work!;
            Customer = customer!;
            StartTime = startTime;
            EndTime = startTime + Work.Duration;
        }

    }
}
