namespace BullsAndCows.Api.Controllers
{
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    using Microsoft.AspNet.Identity;
    using BullsAndCows.Models;

    [Authorize]
    public class GamesController : ApiController
    {
        private GamesServices games;

        public GamesController(GamesServices games)
        {
            this.games = games;
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var games = this.games
                .GetByPage(0, 10)
                .ToList();

            return this.Ok(games);
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int page)
        {
            var games = this.games
                .GetByPage(page, 10)
                .ToList();

            return this.Ok(games);
        }

        public IHttpActionResult Post(GameCreateModel game)
        {
            if (game == null || !ModelState.IsValid)
            {
                return this.BadRequest("Invalid game format!");
            }

            Game gameResult = this.games.Create(
                this.User.Identity.GetUserId(),
                game.Name,
                game.Number);

            var responseResult = new GameCreateResponseModel
            {
                Blue = "No blue player yet",
                DateCreated = gameResult.DateCreated,
                GameState = gameResult.GameState.ToString(),
                Id = gameResult.GameId,
                Name = gameResult.Name,
                Red = gameResult.RedUser.UserName
            };

            return this.Ok();
        }
        [HttpPut]
        public IHttpActionResult JoinGame(int id, GameJoinRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid game!");
            }

            var gameToJoin = this.games.GetById(id);

            if (this.User.Identity.GetUserId() == gameToJoin.RedUserId)
            {
                return this.BadRequest("The game is yours!");
            }

            var joinedGame = this.games.JoinGame(
                this.User.Identity.GetUserId(),
                model.Number,
                id);

            return this.Ok(new { result = string.Format("You joined game \"{0}\"", joinedGame) });
        }
    }
}
