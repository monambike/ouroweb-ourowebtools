using System.Collections.Generic;

namespace Voting.Desktop.App.Models
{
    internal partial class Voting
    {
        public class Vote
        {
            public User User { get; set; }

            public int Value { get; set; }
        }

        public class Round
        {
            Pendencia Pendencia { get; set; }

            List<User> Users { get; set; }

            public int DecidedVote { get; set; }
        }

        public class User
        {
            public string Name { get; set; }

            public string Email { get; set; }

            public bool Voted = false;

            public bool Observer = false;
        }

        public class Pendencia
        {
            public int Id { get; set; }

            public string Descricao { get; set; }

            public Cliente Cliente { get; set; }
        }

        public class Cliente
        {
            public string Nome { get; set; }
        }

        private List<int?> VotingValue = new List<int?> { null, 0, 1, 2, 3, 5, 8, 13, 21, 34 };
    }
}
