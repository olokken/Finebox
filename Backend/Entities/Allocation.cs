using System;
namespace Backend.Entities
{
    public class Allocation
    {
        public string AllocationId { get; set; }
        public string RevieverId { get; set; }
        public string FineId { get; set; }
        public DateTime Date { get; set; }
        public virtual User Reciever { get; set; }
        public virtual Fine Fine { get; set; }
    }
}
