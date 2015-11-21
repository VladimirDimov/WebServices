namespace BullsAndCows.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }

        public string RedUserId { get; set; }

        [ForeignKey("RedUserId")]
        public virtual User RedUser { get; set; }

        public string BlueUserId { get; set; }

        [ForeignKey("BlueUserId")]
        public virtual User BlueUser { get; set; }

        public GameState GameState { get; set; }

        public GameResultType GameResult { get; set; }

        public DateTime DateCreated { get; set; }

        public string RedPlayerNumber { get; set; }

        public string BluePlayerNumber { get; set; }
    }
}
