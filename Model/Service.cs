using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnLapTrinhWeb.Model
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? ServiceId { get; set; }
        [StringLength(100)]

        public required string Name { get; set; }
        [StringLength(10000)]

        public required string Description { get; set; }
        public int DeliveryCount { get; set; } = 0;

        public int TotalDeliveryTime { get; set; } = 0;
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public int Like { get; set; } = 0;

        [ForeignKey("Category")]
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? ThumbnailUrl { get; set; }
        [NotMapped]
        public IFormFile? Thumbnail { get; set; }

    }
}
