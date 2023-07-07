using System;
using PokeTourney.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeTourney.classes;

namespace PokeTourney
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceLayer();
            string choice = "";
            MatchLogic matchLogic = new MatchLogic();

            while (!choice.Equals("q"))
            {
                Console.WriteLine("Please enter the command you wish to do: (1 - list all existing tourneys, 2 - Start Tourny)");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var tournys = service.GetAllTournaments();
                        foreach (var tournament in tournys)
                            Console.WriteLine(tournament.Name);
                        Console.WriteLine();
                        break;
                    case "2":
                        var tourny = StartTourny(matchLogic, service);
                        ListMatches(matchLogic, service, tourny.Tournament_Id);
                        EndTourny(service, tourny);
                        break;
                    default:
                        break;
                }
            }
        }

        private static Tourny_Table StartTourny(MatchLogic matchLogic, ServiceLayer service)
        {
            var enteredInt = false;
            short playerCount = 0;

            Console.WriteLine("Please enter the season number: ");
            short season = Int16.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter the name of this tournament: ");
            var tourny = new Tourny_Table(Console.ReadLine(), DateTime.Today, 0, season);
            service.AddTournament(tourny);

            while (!enteredInt) {
                Console.WriteLine("Please enter how many players are participating:");
                enteredInt = Int16.TryParse(Console.ReadLine(), out playerCount);
            }

            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine("Please enter the name of player " + (i + 1) + ":");
                matchLogic.AddPlayer(Console.ReadLine());
            }

            matchLogic.StartTourny();
            return tourny;
        }

        private static void ListMatches(MatchLogic matchLogic, ServiceLayer service, Guid tournyId)
        {
            double rounds = Math.Ceiling((double)matchLogic.GetMatchOptions().Count - 1);

            for (int i = 0; i < rounds; i++)
            {
                var match = matchLogic.GenerateMatches();
                foreach (var pair in match)
                {
                    Console.WriteLine(pair.Key + ":" + pair.Value);
                }

                Console.WriteLine();

                foreach (var pair in match)
                {
                    ReportMatches(pair, i + 1, service, tournyId);
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        private static void ReportMatches(KeyValuePair<string, string> match, int round, ServiceLayer service, Guid tourny)
        {
            string answer = "";
            Match_Records result1;
            Match_Records result2;
            int points = 0;
            while (!answer.ToUpper().Equals("Y") && !answer.ToUpper().Equals("N"))
            {
                Console.WriteLine("Did " + match.Key + " win? y/n or d for draw");
                answer = Console.ReadLine().ToUpper();
            }

            if (answer.Equals("Y"))
                points = 3;
            else if (answer.Equals("D"))
                points = 1;
            else
                points = 0;

            result1 = new Match_Records(round, points, tourny);
            result2 = new Match_Records(round, (answer.Equals("D") ? 1 : 3 - points), tourny);

            service.AddMatchResultFindIds(result1, match.Key, match.Value);
            service.AddMatchResultFindIds(result2, match.Value, match.Key);
        }

        private static void EndTourny(ServiceLayer service, Tourny_Table tourny)
        {
            Console.WriteLine("The tournament has concluded your rankings are as follows");
            service.CompleteTournament(tourny);
        }
    }
}
