using System;
namespace Backend.Entities
{
    public class Payment
    {
        public string PaymentId { get; set; }
        public string PayerId { get; set; }
        public string FineBoxId { get; set; }
        public string Sum { get; set; }
        public DateTime Date { get; set; }
        public virtual User Payer { get; set; }
        public virtual FineBox FineBox { get; set; }
    }
}
