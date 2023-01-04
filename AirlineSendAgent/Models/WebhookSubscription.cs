using System.ComponentModel.DataAnnotations;

namespace AirlineSendAgent.Models
{
    public class WebhookSubscription
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string WebhookURI { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        public string WebhookType { get; set; }

        [Required]
        public string WebhookPublisher { get; set; }
    }
}