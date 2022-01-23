using System;
namespace Backend.Entities
{
    public class Fine
    {
        public string FineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sum { get; set; }
        public string FineBoxId { get; set; }
    }
}
