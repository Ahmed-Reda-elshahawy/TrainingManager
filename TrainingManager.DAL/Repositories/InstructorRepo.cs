using Microsoft.EntityFrameworkCore;
using TrainingManager.DAL.Repositories.Interfaces;
using TrainingManager.Data;
using TrainingManager.Models;

namespace TrainingManager.DAL.Repositories
{
    public class InstructorRepo : IInstructorRepo
    {
        private readonly AppDbContext context;
        public InstructorRepo(AppDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<Instructor> GetAll()
        {
            return context.Instructors.Include(i => i.User).ToList();
        }

        public void Add(Instructor instructor)
        {
            context.Instructors.Add(instructor);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
