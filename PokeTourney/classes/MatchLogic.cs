using System.Collections.Generic;

namespace PokeTourney.classes
{
    public class MatchLogic
    {
        private List<string> players = new List<string>();
        private List<string> matchOptions;

        public void AddPlayer(string player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string player)
        {
            players.Remove(player);
        }

        public List<string> GetPlayers()
        {
            return players;
        }

        public List<string> GetMatchOptions()
        {
            return matchOptions;
        }

        public void StartTourny()
        {
            matchOptions = new List<string>(players);
            if (matchOptions.Count % 2 != 0)
                matchOptions.Add("*BYE*");
        }

        public List<KeyValuePair<string, string>> GenerateMatches()
        {
        

            int sideLength = matchOptions.Count / 2;

            List<KeyValuePair<string, string>> matches = new List<KeyValuePair<string, string>>();

            for (int i = 0; i < sideLength; i++)
                matches.Add(new KeyValuePair<string, string>(matchOptions[i], matchOptions[i + sideLength]));

            PrepareNextRound();

            return matches;
        }

        private void PrepareNextRound()
        {
            var lastTopChair = matchOptions[(matchOptions.Count / 2) - 1];
            var firstBottomChair = matchOptions[matchOptions.Count / 2];
            matchOptions.Remove(lastTopChair);
            matchOptions.Remove(firstBottomChair);
            matchOptions.Insert(1, firstBottomChair);
            matchOptions.Add(lastTopChair);
        }
    }
}
