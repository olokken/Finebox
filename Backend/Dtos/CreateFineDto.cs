using System;
namespace Backend.Dtos
{
    public class CreateFineDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sum { get; set; }
        public string FineBoxId { get; set; }
    }
}
