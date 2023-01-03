using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineWeb.Models;

public class FlightDetail
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string? FlightCode { get; set; }

    [Required]
    // colum type decimal with precision 6 and scale 2
    [Column(TypeName = "decimal(6,2)")]
    public decimal Price { get; set; }
}

