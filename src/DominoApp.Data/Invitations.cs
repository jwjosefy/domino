namespace DominoApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("domino.Invitations")]
    public partial class Invitations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(512)]
        public string email { get; set; }

        public int User_id { get; set; }

        public virtual User User { get; set; }
    }
}
