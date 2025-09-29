using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingManager.DAL.Models;

namespace TrainingManager.DAL.Data.Configurations
{
    public class EvaluationConfig : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasKey(e => new { e.TraineeId, e.SessionId, e.InstructorId });

            builder.HasOne(e => e.Trainee).WithMany(t => t.Evaluations).HasForeignKey(e => e.TraineeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Instructor).WithMany(i => i.Evaluations).HasForeignKey(e => e.InstructorId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Session).WithMany(s => s.Evaluations).HasForeignKey(e => e.SessionId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
