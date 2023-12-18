using IdentityApp.Areas.Admin.Models;
using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityApp.Extensions;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private readonly UserManager<AppUser> _userMaanger;
        private readonly RoleManager<AppRole> _roleManager;

        public RolesController(RoleManager<AppRole> roleManager, UserManager<AppUser> userMaanger)
        {
            _roleManager = roleManager;
            _userMaanger = userMaanger;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.Select(x=> new RoleViewModel()
            {
                Id = x.Id!,
                Name = x.Name!
            }).ToListAsync();

            return View(roles);
        }

        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateViewModel request)
        {
            var result = await _roleManager.CreateAsync(new AppRole() { Name = request.Name });

            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors);
                return View();
            }
            return RedirectToAction(nameof(RolesController.Index));
        }

        public async Task<IActionResult> RoleUpdate(string id)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(id);

            if (roleToUpdate == null)
                throw new Exception("Güncelenecek role bulunamamıştır");

            return View(new RoleUpdateViewModel() { Id = roleToUpdate.Id, Name = roleToUpdate!.Name!});
        }
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel request)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(request.Id);

            if (roleToUpdate == null)
                throw new Exception("Güncelenecek role bulunamamıştır");

            roleToUpdate.Name = request.Name;

            await _roleManager.UpdateAsync(roleToUpdate);

            ViewData["SuccessMessage"] = "Rol bilgileri güncellenmiştir";

            return View();
        }
    }
}
