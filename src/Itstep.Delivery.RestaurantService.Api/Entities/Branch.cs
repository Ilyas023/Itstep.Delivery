using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itstep.Delivery.RestaurantService.Api.Entities;

public class Branch
{
    [Key]
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Address { get; set; }
    public string CityName { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public virtual Company Company { get; set; }
}
