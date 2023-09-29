using BackendSchedule.Domain.Validation;

namespace BackendSchedule.Domain.Entities
{
    public sealed class Scheduling : Entity
    {

        public Scheduling(int id, Professional professional, TimeSpan? startMorning, TimeSpan? endMorning, TimeSpan? startAfternoon, TimeSpan? endAfternoon, TimeSpan? startNight, TimeSpan? endNight, bool workDay)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(professional, startMorning, endMorning, startAfternoon, endAfternoon, startNight, endNight);
        }
        public Scheduling(Professional professional, TimeSpan? startMorning, TimeSpan? endMorning, TimeSpan? startAfternoon, TimeSpan? endAfternoon, TimeSpan? startNight, TimeSpan? endNight, bool workDay)
        {
            ValidateDomain(professional, startMorning, endMorning, startAfternoon, endAfternoon, startNight, endNight);
        }


        public Professional Professional { get; private set; }
        public TimePeriods TimePeriods { get; private set; }
        public bool WorkDay { get; private set; }
        public List<Appointment> AppointmentList { get; private set; } = new List<Appointment>();

        private void ValidateDomain(Professional professional, TimeSpan? startMorning, TimeSpan? endMorning, TimeSpan? startAfternoon, TimeSpan? endAfternoon, TimeSpan? startNight, TimeSpan? endNight)
        {

            DomainExceptionValidation.When((startMorning == null && endMorning != null) || (startMorning != null && endMorning == null), "Start and End must have valid or null values");
            DomainExceptionValidation.When((startAfternoon == null && endAfternoon != null) || (startAfternoon != null && endAfternoon == null), "Start and End must have valid or null values");
            DomainExceptionValidation.When((startNight == null && endNight != null) || (startNight != null && endNight == null), "Start and End must have valid or null values");

            DomainExceptionValidation.When(startMorning.HasValue && endMorning.HasValue && startMorning >= endMorning, "StartMorning must be less than EndMorning");
            DomainExceptionValidation.When(startAfternoon.HasValue && endAfternoon.HasValue && startAfternoon >= endAfternoon, "StartAfternoon must be less than EndAfternoon!");
            DomainExceptionValidation.When(startNight.HasValue && endNight.HasValue && startNight >= endNight, "StartNight must be less than EndNight!");

            Professional = professional;

            TimePeriods = new TimePeriods(startMorning, endMorning, startAfternoon, endAfternoon, startNight, endNight);
        }

        public void AddAppointment(Appointment appointment)
        {
            int morning = 0;
            int afternoon = 0;
            int night = 0;

            if (TimePeriods.StartMorning != null)
            {
                if (!(appointment.StartTime < TimePeriods.StartMorning || appointment.StartTime.Add(appointment.Work.Duration) > TimePeriods.EndMorning))
                    morning++;
            }
            if (TimePeriods.StartAfternoon != null)
            {
                if (!(appointment.StartTime < TimePeriods.StartAfternoon || appointment.StartTime.Add(appointment.Work.Duration) > TimePeriods.EndAfternoon))
                    afternoon++;
            }
            if (TimePeriods.StartNight != null)
            {
                if (!(appointment.StartTime < TimePeriods.StartNight || appointment.StartTime.Add(appointment.Work.Duration) > TimePeriods.EndNight))
                    night++;
            }

            DomainExceptionValidation.When(night == 0 && afternoon == 0 && morning == 0, "Time outside the permitted range!");

            foreach (Appointment appointmentItem in AppointmentList)
            {
                TimeSpan appointmentItemEnd = appointmentItem.StartTime.Add(appointmentItem.Work.Duration);
                TimeSpan appointmentAddEnd = appointment.StartTime.Add(appointment.Work.Duration);


                DomainExceptionValidation.When(appointment.StartTime >= appointmentItem.StartTime && appointment.StartTime < appointmentItemEnd ||
                appointmentAddEnd > appointmentItem.StartTime && appointmentAddEnd <= appointmentItemEnd, "Schedule overlaps with other existing schedule!");

            }

            AppointmentList.Add(appointment);
        }

        public void RemoveAppointment(Appointment appointment)
        {
            AppointmentList.Remove(appointment);
        }
    }
}
