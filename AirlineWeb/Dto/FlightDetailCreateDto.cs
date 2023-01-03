using System.ComponentModel.DataAnnotations;

namespace AirlineWeb.Dtos;

public class FlightDetailCreateDto
{
    [Required]
    public string? FlightCode { get; set; }
    
    [Required]
    public decimal Price { get; set; }
}