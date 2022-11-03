using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itstep.Delivery.GlobalDictionary.Api.Entities;

public class City
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }

    [ForeignKey(nameof(CountryId))]
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Country Country { get; set; }
}
