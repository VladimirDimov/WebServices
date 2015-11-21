namespace BullsAndCows.Services
{
    using Data.Repositories;
    using BullsAndCows.Models;
    using System;
    using System.Linq;

    public class GamesServices
    {
        private IRepository<Game> gamesRepo;
        private IRepository<User> usersRepo;

        public GamesServices(IRepository<Game> gamesRepo, IRepository<User> usersRepo)
        {
            this.gamesRepo = gamesRepo;
            this.usersRepo = usersRepo;
        }

        public IQueryable<Game> GetByPage(int page, int pageSize)
        {
            var result = this.gamesRepo.All()
                 .OrderBy(g => g.GameState)
                 .ThenBy(g => g.Name)
                 .ThenBy(g => g.DateCreated)
                 .ThenBy(g => g.RedUser.Email)
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize);

            return result;
        }

        public Game Create(string userId, string gameName, string playerNumber)
        {
            Game gameToCreate = new Game
            {
                RedUser = this.usersRepo.All().FirstOrDefault(u => u.Id == userId),
                Name = gameName,
                RedPlayerNumber = playerNumber,
                GameState = GameState.WaitingForOpponent,
                DateCreated = DateTime.Now
            };

            this.gamesRepo.Add(gameToCreate);
            this.gamesRepo.SaveChanges();

            var newGameId = gameToCreate.GameId;
            var response = this.GetById(newGameId);

            return response;
        }

        public Game GetById(int id)
        {
            var game = this.gamesRepo.All()
                .FirstOrDefault(g => g.GameId == id);

            return game;
        }

        public string JoinGame(string userId, string number, int gameId)
        {
            var gameToJoin = this.GetById(gameId);            
            gameToJoin.BlueUserId = userId;
            gameToJoin.GameState = GameState.RedInTurn;
            this.gamesRepo.SaveChanges();

            return gameToJoin.Name;
        }
    }
}
