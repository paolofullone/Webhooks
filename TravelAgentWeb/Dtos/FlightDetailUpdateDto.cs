namespace TravelAgentWeb.Dtos;

public class FlightDetailUpdateDto
{
    public string? Publisher { get; set; }
    public string? Secret { get; set; }
    public string? FlightCode { get; set; }
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public string? WebhookType { get; set; }
}