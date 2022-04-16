using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using LiJiT.Model;
using Microsoft.EntityFrameworkCore;

namespace LiJiT.EntityFramework
{



    public class LiJiTDbContext : DbContext
    {

        public LiJiTDbContext(DbContextOptions<LiJiTDbContext> options) : base(options)

        {

        }


        public LiJiTDbContext()
            : base(SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), "DefaultConnection")
                .Options)
        {
        }

        public DbSet<ListingType> listingTypes { get; set; }
        public DbSet<IncomingMessages> incomingMessages { get; set; }
        public DbSet<ListingDetailSocialProfiles> listingDetailSocialProfiles { get; set; }
        public DbSet<ListingDetails> listingDetails { get; set; }
        public DbSet<ObjectType> objectTypes { get; set; }
        public DbSet<Partners> partners { get; set; }
        public DbSet<Photos> photos { get; set; }
        public DbSet<Reviews> reviews { get; set; }
        public DbSet<SocialMediaType> socialMediaTypes { get; set; }
        public DbSet<StatusType> statusTypes { get; set; }
        public DbSet<SupportPrograms> supportPrograms { get; set; }
        public DbSet<AboutContent> aboutContents { get; set; }
        public DbSet<Events> events { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var modifiedEntries = this.ChangeTracker.Entries();

                foreach (var entry in modifiedEntries)
                {
                    IAuditableEntity entity = entry.Entity as IAuditableEntity;
                    if (entity != null)
                    {
                        DateTime now = DateTime.Now;
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedBy =LiJiT.Utility.Constants.LoginUserId;
                            entity.CreatedDate = now;
                        }
                        else
                        {
                            base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                        }

                        entity.UpdatedBy = LiJiT.Utility.Constants.LoginUserId;
                        entity.UpdatedDate = now;
                        var validationContext = new ValidationContext(entity);
                        Validator.ValidateObject(entity, validationContext);
                    }
                }

                return await base.SaveChangesAsync();
            }

            catch (ValidationException e)
            {
                throw;
            }
        }
    }


}
