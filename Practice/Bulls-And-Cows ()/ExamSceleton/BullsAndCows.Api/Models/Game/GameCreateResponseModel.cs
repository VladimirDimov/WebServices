using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.Api.Models
{
    public class GameCreateResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}