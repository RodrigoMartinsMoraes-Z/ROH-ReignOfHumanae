﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ROH.Domain.Version;

namespace ROH.Context.TypeConfiguration.Version
{
    public class GameVersionFileTypeConfiguration : IEntityTypeConfiguration<GameVersionFile>
    {
        public void Configure(EntityTypeBuilder<GameVersionFile> builder)
        {
             builder.HasKey(f => f.Id);

             builder.Property(g => g.Guid).HasDefaultValueSql("gen_random_uuid()");

             builder.HasOne(f => f.GameVersion).WithMany(v => v.VersionFiles).HasForeignKey(f => f.IdVersion);
        }
    }
}