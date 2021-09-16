namespace AAS.Data.DTOs
{
    public class BusinessDto
    {
        public int BusId { get; set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string BusinessName { get; set; }
        
        public int ScheduleId { get; set; }
        
        public string Field { get; set; } 

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

    }
}