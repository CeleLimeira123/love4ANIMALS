using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace love4animalss.Models;

/// <summary>
/// Representa una transacción económica de apoyo a una campaña específica.
/// </summary>
public class Donation
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required]
    public DateTime DonationDate { get; set; } = DateTime.UtcNow;

    [MaxLength(500)]
    public string? Comment { get; set; }

   [Required]
    public int CampaignId { get; set; }
    
    [ForeignKey("CampaignId")]
    public virtual Campaign Campaign { get; set; } = null!;

    [Required]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;

    public Donation() { }

    public Donation(decimal amount, int campaignId, int userId, string? comment = null)
    {
        Amount = amount;
        CampaignId = campaignId;
        UserId = userId;
        Comment = comment;
        DonationDate = DateTime.UtcNow;
    }
}