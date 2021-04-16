using CalvinProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalvinProject.DatabaseServices
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }

}
