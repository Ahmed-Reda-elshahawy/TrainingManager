using Microsoft.EntityFrameworkCore;
using TrainingManager.DAL.Repositories.Interfaces;
using TrainingManager.Data;
using TrainingManager.Models;

namespace TrainingManager.DAL.Repositories
{
    public class CourseRepo(AppDbContext context) : GenericRepo<Course>(context), ICourseRepo
    {
        private readonly AppDbContext context = context;

        public async Task<Course?> GetCourseWithInstructorAsync(Guid id)
        {
            return await context.Courses.Include(c => c.Instructor).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ISCourseNameExistsAsync(string name)
        {
            return await context.Courses.AnyAsync(c => c.Name == name);
        }



        //public IEnumerable<Course> GetAll()
        //{
        //    return context.Courses.ToList();
        //}

        //public Course? GetById(Guid id)
        //{
        //    return context.Courses.Find(id);
        //}

        //public Course? GetCourseWithInstructor(Guid id)
        //{
        //    return context.Courses.Include(c => c.Instructor).ThenInclude(i => i!.User).FirstOrDefault(c => c.Id == id);
        //}

        //public IEnumerable<Course> GetPage(int page, int pageSize, string? searchName = null)
        //{
        //    var query = context.Courses.AsNoTracking();
        //    if (!string.IsNullOrWhiteSpace(searchName))
        //        query = query.Where(c => c.Name.Contains(searchName));
        //    query = query.OrderBy(c => c.Name);
        //    return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        //}
        //public int GetCount(string? searchName = null)
        //{
        //    var query = context.Courses.AsNoTracking();
        //    if (!string.IsNullOrWhiteSpace(searchName))
        //        query = query.Where(c => c.Name.Contains(searchName));
        //    return query.Count();
        //}

        //public bool ISCourseNameExists(string name)
        //{
        //    return context.Courses.Any(c => c.Name == name);
        //}

        //public void Add(Course course)
        //{
        //    context.Courses.Add(course);
        //}

        //public void Update(Course course)
        //{
        //    context.Courses.Update(course);
        //}

        //public void Delete(Guid Id)
        //{
        //    var course = context.Courses.Find(Id);
        //    if (course != null) context.Courses.Remove(course);
        //}

        //public void Save()
        //{
        //    context.SaveChanges();
        //}

    }
}
