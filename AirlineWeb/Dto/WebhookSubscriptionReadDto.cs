namespace AirlineWeb.Dtos;

public class WebhookSubscriptionReadDto
{
    public int Id { get; set; }
    public string? WebhookURI { get; set; }
    public string? Secret { get; set; }
    public string? WebhookType { get; set; }
    public string? WebhookPublisher { get; set; }
}

