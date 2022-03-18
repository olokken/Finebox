using System;
namespace Backend.Web.Dtos
{
  public class CreateFineBoxDto
  {
    public string? Name { get; set; }
    public string? PaymentDescription { get; set; }
    public string? UserId { get; set; }
  }
}
