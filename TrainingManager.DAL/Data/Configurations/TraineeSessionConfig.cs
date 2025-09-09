using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingManager.DAL.Models;

namespace TrainingManager.DAL.Data.Configurations
{
    public class TraineeSessionConfig : IEntityTypeConfiguration<TraineeSession>
    {
        public void Configure(EntityTypeBuilder<TraineeSession> builder)
        {
            builder.HasKey(ts => new { ts.TraineeId, ts.SessionId });

            builder.HasOne(ts => ts.Trainee).WithMany(t => t.TraineeSessions).HasForeignKey(t => t.TraineeId);

            builder.HasOne(ts => ts.Session).WithMany(s => s.TraineeSessions).HasForeignKey(s => s.SessionId);
        }
    }
}
