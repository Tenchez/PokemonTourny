using PokeTourney.Interface;
using PokeTourney.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTourney.Service
{
    public class ServiceLayer
    {
        private readonly IMatchRecordsRepository _matchRepo;
        private readonly ITeamsRepository _teamsRepository;
        private readonly ITournyRepository _tournyRepository;
        private readonly ITrainerRepository _trainerRepository;

        public ServiceLayer()
        {
            _matchRepo = new MatchRecordsRepository();
            _teamsRepository = new TeamsRepository();
            _tournyRepository = new TournyRepository();
            _trainerRepository = new TrainerRepository();
        }

        public List<Tourny_Table> GetAllTournaments()
        {
            return _tournyRepository.GetAll().ToList();
        }

        public void AddMatchResultFindIds(Match_Records match, string player, string opponent)
        {
            string[] playerNames = player.Split(' ');
            string[] oppNames = opponent.Split(' ');

            match.Trainer_Id = _trainerRepository.GetSingle(p => p.FirstName.Trim().Equals(playerNames[0]) && p.LastName.Trim().Equals(playerNames[1])).Id;
            match.Opp_Id = _trainerRepository.GetSingle(o => o.FirstName.Trim().Equals(oppNames[0]) && o.LastName.Trim().Equals(oppNames[1])).Id;
            _matchRepo.Add(match);
        }

        public void AddTournament(Tourny_Table tourny)
        {
            _tournyRepository.Add(tourny);
        }

        public void CompleteTournament(Tourny_Table tourny)
        {
            tourny.Completed = 1;
            _tournyRepository.Update(tourny);
        }
    }
}
