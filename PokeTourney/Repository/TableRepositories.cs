using PokeTourney.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTourney.Repository
{
    public class MatchRecordsRepository : GenericDataRepository<Match_Records>, IMatchRecordsRepository { }
    public class TeamsRepository : GenericDataRepository<Teams_Table>, ITeamsRepository { }
    public class TournyRepository : GenericDataRepository<Tourny_Table>, ITournyRepository { }
    public class TrainerRepository : GenericDataRepository<Trainer_Table>, ITrainerRepository { }
}
