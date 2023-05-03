﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ROH.Domain.Characters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROH.Context.TypeConfiguration.Characters
{
    public class DefenseStatusTypeConfiguration : IEntityTypeConfiguration<DefenseStatus>
    {
        public void Configure(EntityTypeBuilder<DefenseStatus> builder)
        {
            builder.HasKey(ds => ds.IdCharacter);

            builder.HasOne(a => a.Character).WithOne(c => c.DefenseStatus).HasForeignKey<DefenseStatus>(a => a.IdCharacter);
        }
    }
}