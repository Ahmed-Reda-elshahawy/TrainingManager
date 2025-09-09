using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TrainingManager.BLL.Services.Interfaces;
using TrainingManager.BLL.ViewModels.Course;
using TrainingManager.Configurations;

namespace TrainingManager.Controllers
{
    [Authorize]
    public class CourseController(ICourseService courseService, IInstructorService instructorService, IOptionsMonitor<CourseSettings> options) : Controller
    {

        #region Get
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = options.CurrentValue.DefaultPageSize;
            var coursesVM = await courseService.GetPagedAsync(page, pageSize);
            return View(coursesVM);
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index));
            }

            var courseVM = await courseService.GetDetailsAsync(id);
            return View("Details", courseVM);
        }
        #endregion

        #region Create

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //ViewBag.Instructors = context.Instructors.Select(i => new SelectListItem(i.FirstName, i.Id.ToString()));
            ViewData["Instructors"] = await instructorService.GetAllAsync();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateVM courseVM)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Instructors"] = await instructorService.GetAllAsync();
                return View(courseVM);
            }

            await courseService.AddAsync(courseVM);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var editVM = await courseService.GetCourseToEditAsync(id);

            ViewBag.Instructors = await instructorService.GetAllAsync();
            return View(editVM);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditVM editVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Instructors = await instructorService.GetAllAsync();
                return View(editVM);
            }

            await courseService.UpdateAsync(editVM);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var course = await courseService.GetByIdAsync(id);
            if (course == null) return NotFound();
            return RedirectToAction(nameof(GetById), new { id = id });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            var course = await courseService.GetByIdAsync(id);
            if (course == null) return NotFound();

            await courseService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Validation
        [HttpGet]
        public async Task<IActionResult> CheckForUniqueCourseName(string name)
        {
            var exists = await courseService.ISCourseNameExistsAsync(name);
            if (exists) return Json("This Course is already exists");
            return Json(true);
        }
        #endregion
    }
}
