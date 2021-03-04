using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.EntityFrameworkCore.Configs;
using TaTava.Sliders;

namespace TaTava.EntityFrameworkCore.EntityFrameworkCore.Configs
{
    public class SliderConfiguration:EntityConfiguration<Slider,Guid>
    {
        public override void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(slider => slider.Title)
                .HasColumnType("nvarchar(300)")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(slider => slider.Url)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150);

            base.Configure(builder);
        }
    }
}
