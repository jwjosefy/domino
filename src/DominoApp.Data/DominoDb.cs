using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DominoApp.Data
{
    public partial class DominoDb : DbContext
    {
        static DominoDb()
        {
            // Precisa fazer isso para evitar que o database seja recriado ao reinicializar
            Database.SetInitializer<DominoDb>(null);
        }

        public DominoDb()
            : base("name=DominoDb")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Invitations> Invitations { get; set; }
        public virtual DbSet<Movements> Movements { get; set; }
        public virtual DbSet<Ranking> Ranking { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Invitations>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Movements>()
                .Property(e => e.move)
                .IsUnicode(false);

            modelBuilder.Entity<Session>()
                .HasMany(e => e.Movements)
                .WithRequired(e => e.Session)
                .HasForeignKey(e => e.Session_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Settings>()
                .Property(e => e.Setting)
                .IsUnicode(false);

            modelBuilder.Entity<Transactions>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.hash)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.perfil)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Invitations)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Movements)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Ranking)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Session)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Session1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.User_id1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_id)
                .WillCascadeOnDelete(false);
        }


    }
}
