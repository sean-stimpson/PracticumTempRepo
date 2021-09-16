namespace AAS.Data.DTOs
{
    public class ScheduleDto
    {
        public int BusId { get; set; }
        public int SunOpen { get; set; }
        public int SunClose { get; set; }
        public int MonOpen { get; set; }
        public int MonClose { get; set; }
        public int TueOpen { get; set; }
        public int TueClose { get; set; }
        public int WedOpen { get; set; }
        public int WedClose { get; set; }
        public int ThuOpen { get; set; }
        public int ThuClose { get; set; }
        public int FriOpen { get; set; }
        public int FriClose { get; set; }
        public int SatOpen { get; set; }
        public int SatClose { get; set; }
        public int MinuteIncrement { get; set; }
    }
}