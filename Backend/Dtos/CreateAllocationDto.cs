using System;
namespace Backend.Dtos
{
    public class CreateAllocationDto
    {
        public string RecieverId { get; set; }
        public string FineId { get; set; }
        public string Date { get; set; }
    }
}
