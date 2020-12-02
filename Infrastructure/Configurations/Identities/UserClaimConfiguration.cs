using Domain.Models.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.Identities
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder
                .HasKey(UserClaim => UserClaim.Id);
            builder
                .Property(UserClaim => UserClaim.Guid)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("(uuid())");
        }
    }
}
