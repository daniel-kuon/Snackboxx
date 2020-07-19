using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Core.DatabaseModel
{
    public class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        /// <summary>
        ///     Initializes a new instance of <see cref="ApiAuthorizationDbContext{TUser}" />.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions" />.</param>
        /// <param name="operationalStoreOptions">The <see cref="IOptions{OperationalStoreOptions}" />.</param>
        public DataContext(
            DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<StockChange> StockChanges { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBarcode> ProductBarcodes { get; set; }
        public DbSet<UserBarcode> UserBarcodes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductVoting> ProductVotings { get; set; }
        public DbSet<UserVoting> UserVotings { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementGroup> AchievementGroups { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }


        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            SetDatesBeforeSaving();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetDatesBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void SetDatesBeforeSaving()
        {
            var entries = this.ChangeTracker.Entries<IEntity>();
            foreach (var entry in entries.Where(e => e.State == EntityState.Added))
            {
                entry.Property(nameof(IEntity.CreatedAt)).CurrentValue = DateTime.Now;
            }

            foreach (var entry in entries.Where(e => e.State == EntityState.Modified))
            {
                entry.Property(nameof(IEntity.CreatedAt)).IsModified = false;
                if (entry.Entity is IUpdateableEntity)
                    entry.Property(nameof(IUpdateableEntity.LastUpdatedAt)).CurrentValue = DateTime.Now;
            }
        }
    }
}