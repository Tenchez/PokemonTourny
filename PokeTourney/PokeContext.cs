namespace PokeTourney
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PokeContext : DbContext
    {
        public PokeContext()
            : base("name=PokeContext")
        {
        }

        public virtual DbSet<Match_Records> Match_Records { get; set; }
        public virtual DbSet<Teams_Table> Teams_Table { get; set; }
        public virtual DbSet<Tourny_Table> Tourny_Table { get; set; }
        public virtual DbSet<Trainer_Table> Trainer_Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teams_Table>()
                .Property(e => e.Mon_1)
                .IsFixedLength();

            modelBuilder.Entity<Teams_Table>()
                .Property(e => e.Mon_2)
                .IsFixedLength();

            modelBuilder.Entity<Teams_Table>()
                .Property(e => e.Mon_3)
                .IsFixedLength();

            modelBuilder.Entity<Teams_Table>()
                .Property(e => e.Mon_4)
                .IsFixedLength();

            modelBuilder.Entity<Teams_Table>()
                .Property(e => e.Mon_5)
                .IsFixedLength();

            modelBuilder.Entity<Teams_Table>()
                .Property(e => e.Mon_6)
                .IsFixedLength();

            modelBuilder.Entity<Teams_Table>()
                .HasOptional(e => e.Teams_Table1)
                .WithRequired(e => e.Teams_Table2);

            modelBuilder.Entity<Tourny_Table>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Tourny_Table>()
                .HasMany(e => e.Match_Records)
                .WithRequired(e => e.Tourny_Table)
                .HasForeignKey(e => e.Tourny_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainer_Table>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<Trainer_Table>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Trainer_Table>()
                .HasMany(e => e.Match_Records)
                .WithRequired(e => e.Trainer_Table)
                .HasForeignKey(e => e.Opp_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainer_Table>()
                .HasMany(e => e.Match_Records1)
                .WithRequired(e => e.Trainer_Table1)
                .HasForeignKey(e => e.Trainer_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
