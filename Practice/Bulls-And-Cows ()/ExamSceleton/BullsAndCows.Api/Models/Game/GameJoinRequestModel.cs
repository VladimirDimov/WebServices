namespace BullsAndCows.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GameJoinRequestModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string Number { get; set; }
    }
}