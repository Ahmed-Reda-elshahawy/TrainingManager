using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainingManager.BLL.Services.Interfaces;
using TrainingManager.BLL.ViewModels.User;
using TrainingManager.DAL.Repositories;

namespace TrainingManager.Controllers
{
    public class AccountController(IAccountService accountService, ITrackService trackService) : Controller
    {
        private readonly IAccountService _accountService = accountService;
        private readonly ITrackService trackService = trackService;

        #region Register

        [HttpGet]
        public async Task<IActionResult> RegisterTrainee()
        {
            ViewBag.Tracks = await trackService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTrainee(RegisterTraineeVM model)
        {
            ViewBag.Tracks = await trackService.GetAllAsync();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //IdentityResult creationResult = await authService.RegisterAsync(registerVM);
            //if (!creationResult.Succeeded)
            //{
            //    ModelState.AddModelError(string.Empty, creationResult.Errors.First().Description);
            //    return View(registerVM);
            //}

            //return RedirectToAction(nameof(Login));

            var result = await _accountService.RegisterTraineeAsync(model);
            if(result.Succeeded) return RedirectToAction("Index", "Home");
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult RegisterInstructor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterInstructor(RegisterInstructorVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _accountService.RegisterInstructorAsync(model);
            if (result.Succeeded) return RedirectToAction("Index", "Home");
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _accountService.RegisterAdminAsync(model);
            if (result.Succeeded) return RedirectToAction("Index", "Home");
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
        }

        #endregion

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            //var isAuthenticated = await authService.LoginAsync(loginVM);
            //if (isAuthenticated == false)
            //{
            //    ModelState.AddModelError(string.Empty, "Invalid user name or password");
            //    return View(loginVM);
            //}

            //return RedirectToAction(nameof(Index), nameof(CourseController));
            
            var result = await _accountService.LoginAsync(loginVM);
            if (result.Succeeded) return RedirectToAction("Index", "Home");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(loginVM);
            }
        }

        #endregion

        #region Logout

        public async Task<IActionResult> Logout()
        {
            //await authService.LogoutAsync();
            await _accountService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        #endregion
    }
}
