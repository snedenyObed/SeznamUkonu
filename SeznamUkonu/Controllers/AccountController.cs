using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeznamUkonu.Models;

namespace SeznamUkonu.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}
		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
		}
		[HttpGet]
		public IActionResult Login(string? returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model, string? navratovaURL = null)
		{
			ViewData["ReturnUrl"] = navratovaURL;
			if (ModelState.IsValid)
			{
				var vysledekOvereni = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
				if (vysledekOvereni.Succeeded)
				{
					return RedirectToLocal(navratovaURL);
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Neplatné přihlašovací údaje.");
					return View(model);
				}
			}
			// Pokud byly odeslány neplatné údaje, vrátíme uživatele k přihlašovacímu fomuláři
			return View(model);
		}
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction(nameof(HomeController.Index), "Home");
		}
	}
}
