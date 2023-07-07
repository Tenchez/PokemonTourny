namespace PokeTourney
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teams_Table
    {
        public Guid Id { get; set; }

        public Guid Trainer_Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Mon_1 { get; set; }

        [Required]
        [StringLength(20)]
        public string Mon_2 { get; set; }

        [Required]
        [StringLength(20)]
        public string Mon_3 { get; set; }

        [Required]
        [StringLength(20)]
        public string Mon_4 { get; set; }

        [Required]
        [StringLength(20)]
        public string Mon_5 { get; set; }

        [Required]
        [StringLength(20)]
        public string Mon_6 { get; set; }

        public int Place { get; set; }

        public Guid? TournamentId { get; set; }

        public virtual Teams_Table Teams_Table1 { get; set; }

        public virtual Teams_Table Teams_Table2 { get; set; }
    }
}
