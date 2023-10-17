using BackendSchedule.Domain.DataStructure;
using BackendSchedule.Domain.Validation;

namespace BackendSchedule.Domain.Entities
{
    public sealed class Appointment : Entity
    {
        public Appointment() { }
        public Appointment(int id, Scheduling scheduling, Work work, TimeSpan startTime, string NameC, string? EmailC, string PhoneC)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;

            ValidateDomain(scheduling, work, startTime, NameC, EmailC, PhoneC);
        }

        public Appointment(Scheduling scheduling, Work work, TimeSpan startTime, string NameC, string? EmailC, string PhoneC)
        {
            ValidateDomain(scheduling, work, startTime, NameC, EmailC, PhoneC);
        }

        public Scheduling Scheduling { get; private set; }
        public int SchedulingId { get; private set; }
        public Work Work { get; private set; }
        public int WorkId { get; private set; }
        public Customer Customer { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }

        private void ValidateDomain(Scheduling scheduling, Work work, TimeSpan startTime, string NameC, string? EmailC, string PhoneC)
        {
            DomainExceptionValidation.When(scheduling == null, "Invalid Scheduling value");
            DomainExceptionValidation.When(work == null, "Invalid Work value");
            DomainExceptionValidation.When(startTime == TimeSpan.Zero, "Invalid StartTime value");

            Customer customer = new Customer(NameC, EmailC, PhoneC);

            Scheduling = scheduling!;
            Work = work!;
            Customer = customer;
            StartTime = startTime;
            EndTime = startTime + Work.Duration;
        }

    }
}
