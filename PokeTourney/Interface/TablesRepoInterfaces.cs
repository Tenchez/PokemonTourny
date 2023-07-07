namespace PokeTourney.Interface
{
    public interface IMatchRecordsRepository : IGenericDataRepository<Match_Records> { }
    public interface ITeamsRepository: IGenericDataRepository<Teams_Table> { }
    public interface ITournyRepository : IGenericDataRepository<Tourny_Table> { }
    public interface ITrainerRepository : IGenericDataRepository<Trainer_Table> { }
}
