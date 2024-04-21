using LogisticsWebsite_WebProgramingProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LogisticsWebsite_WebProgramingProject.Controllers
{
	public class UsersController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		public UsersController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		//Admin
		public async Task<IActionResult> GetUserList()
		{
			var users = await _userManager.Users.ToListAsync();
			return View(users); // Pass the user list to the view
		}

		public async Task<IActionResult> GetInformationUser(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return BadRequest("Please provide a valid user ID.");
			}

			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound("User not found.");
			}

			// You can return a custom view model containing the user details you want to expose
			// or directly return the user object (be cautious about exposing sensitive data)
			var userViewModel = new UserInformation {Id=user.Id, Name = user.FullName, Email = user.Email, Password = user.PasswordHash, PhoneNumber = user.PhoneNumber, Country = user.CountryRegion };
			return View(userViewModel);
		}

		public async Task<IActionResult> EditUser(string id)
		{
            //var user = await _userManager.FindByIdAsync(id);
            //if (user == null)
            //{
            //    return NotFound("User not found");
            //}

            //return View(user);

            if (string.IsNullOrEmpty(id))
            {
            	return BadRequest("Please provide a valid user ID.");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
            	return NotFound("User not found.");
            }

            var editUserViewModel = new ApplicationUser{ Id = user.Id,FullName = user.FullName, Email = user.UserName, PhoneNumber = user.PhoneNumber, CountryRegion = user.CountryRegion };
            return View(editUserViewModel);
        }

		[HttpPost]
		public async Task<IActionResult> UpdateUser(ApplicationUser model)
		{
            //if (id != model.Id)
            //{
            //    return NotFound();
            //}
            //if (ModelState.IsValid)
            //{
            //    var existingUser = await _userManager.FindByIdAsync(id); 


            //    existingUser.FullName = model.Name;
            //    existingUser.UserName = model.Email;
            //    existingUser.PhoneNumber = model.PhoneNumber;
            //    existingUser.CountryRegion = model.Country;
            //    await _userManager.UpdateAsync(existingUser);
            //    return RedirectToAction(nameof(GetInformationUser));
            //}
            //return View(model);

            if (ModelState.IsValid)
            {
            	var user = await _userManager.FindByIdAsync(model.Id);
            	if (user == null)
            	{
            		return NotFound("User not found.");
            	}

            	user.UserName = model.Email;
            	user.FullName = model.FullName;
            	user.PhoneNumber = model.PhoneNumber;
            	user.CountryRegion = model.CountryRegion;

            	var updateResult = await _userManager.UpdateAsync(user);

            	if (updateResult.Succeeded)
            	{
            		return RedirectToAction("GetInformationUser"); // Redirect to user list or success page
            	}
            	else
            	{
            		foreach (var error in updateResult.Errors)
            		{
            			ModelState.AddModelError(string.Empty, error.Description);
            		}
            	}
            }

            return View("EditUser", model); // Return edit view with validation errors
        }

	}
}
