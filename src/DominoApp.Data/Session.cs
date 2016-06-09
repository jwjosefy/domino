namespace DominoApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("domino.Session")]
    public partial class Session
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Session()
        {
            Movements = new HashSet<Movements>();
        }

        public int id { get; set; }

        public int User_id { get; set; }

        public int User_id1 { get; set; }

        public int aposta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movements> Movements { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
