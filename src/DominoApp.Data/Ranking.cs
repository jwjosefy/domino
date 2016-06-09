namespace DominoApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("domino.Ranking")]
    public partial class Ranking
    {
        public int id { get; set; }

        public int? num_games { get; set; }

        public int? num_victories { get; set; }

        public int? num_streaks { get; set; }

        public int? best_streak { get; set; }

        public int? num_login { get; set; }

        public virtual User User { get; set; }
    }
}
