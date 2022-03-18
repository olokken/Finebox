using System;
namespace Backend.Web.Dtos
{
  public class CreateAllocationDto
  {
    public string? RecieverId { get; set; }
    public string? FineId { get; set; }
    public string? Date { get; set; }
  }
}
