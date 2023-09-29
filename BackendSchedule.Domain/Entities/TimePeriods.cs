namespace BackendSchedule.Domain.Entities
{
    public class TimePeriods
    {
        public TimeSpan? StartMorning { get; internal set; }
        public TimeSpan? EndMorning { get; internal set; }
        public TimeSpan? StartAfternoon { get; internal set; }
        public TimeSpan? EndAfternoon { get; internal set; }
        public TimeSpan? StartNight { get; internal set; }
        public TimeSpan? EndNight { get; internal set; }

        TimePeriods()
        {
            StartMorning = null;
            EndMorning = null;
            StartAfternoon = null;
            EndAfternoon = null;
            StartNight = null;
            EndNight = null;
        }
        public TimePeriods(TimeSpan? startMorning, TimeSpan? endMorning, TimeSpan? startAfternoon, TimeSpan? endAfternoon, TimeSpan? startNight, TimeSpan? endNight)
        {
            StartMorning = startMorning;
            EndMorning = endMorning;
            StartAfternoon = startAfternoon;
            EndAfternoon = endAfternoon;
            StartNight = startNight;
            EndNight = endNight;
        }
    }
}
