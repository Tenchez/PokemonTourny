namespace PokeTourney
{
    using System;

    public partial class Match_Records
    {

        public Match_Records(int round, int points, Guid tourny)
        {
            Id = Guid.NewGuid();
            Points = points;
            Round = round;
            Tourny_Id = tourny;
        }

        public Guid Id { get; set; }

        public Guid Trainer_Id { get; set; }

        public Guid Opp_Id { get; set; }

        public int Points { get; set; }

        public int Round { get; set; }

        public Guid Tourny_Id { get; set; }

        public virtual Trainer_Table Trainer_Table { get; set; }

        public virtual Tourny_Table Tourny_Table { get; set; }

        public virtual Trainer_Table Trainer_Table1 { get; set; }
    }
}
