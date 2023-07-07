namespace PokeTourney
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tourny_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tourny_Table()
        {
            Match_Records = new HashSet<Match_Records>();
        }

        public Tourny_Table(string name, DateTime date, int completed, int season)
        {
            Tournament_Id = Guid.NewGuid();
            Name = name;
            Date = date;
            Completed = completed;
            Season = season;
        }

        [Key]
        public Guid Tournament_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int? Completed { get; set; }

        public int? Season { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match_Records> Match_Records { get; set; }
    }
}
