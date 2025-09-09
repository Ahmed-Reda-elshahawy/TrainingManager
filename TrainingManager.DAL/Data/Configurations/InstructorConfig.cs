using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingManager.Models;

namespace TrainingManager.DAL.Data.Configurations
{
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(i => i.HourlyRate)
                .HasPrecision(18, 2);
        }
    }
}
