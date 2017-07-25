using Database.Clients;
using Database.Contacts;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class EfFileCoreContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ImportedContact> ImportedContacts { get; set; }

        public EfFileCoreContext(DbContextOptions<EfFileCoreContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
            .HasOne(p => p.Client)
            .WithMany(b => b.Contacts)
            .HasForeignKey(p => p.ClientId)
            .HasConstraintName("ForeignKey_Contact_Client");

            modelBuilder.Entity<ImportedContact>()
            .HasOne(p => p.Client)
            .WithMany(b => b.ImportedContacts)
            .HasForeignKey(p => p.ClientId)
            .HasConstraintName("ForeignKey_ImportedContact_Client");
        }
    }
}
