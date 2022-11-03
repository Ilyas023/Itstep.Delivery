using System.ComponentModel.DataAnnotations;

namespace Itstep.Delivery.RestaurantService.Api.Entities;

public class Company
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
