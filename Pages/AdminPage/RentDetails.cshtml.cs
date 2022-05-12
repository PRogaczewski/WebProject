using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalWebProject.Model;
using CarRentalWebProject.Models;

namespace CarRentalWebProject.Pages.AdminPage
{
    [Authorize(Policy = "AdminOnly")]
    public class RentDetailsModel : PageModel
    {
        private readonly IUserService _userService;
        [BindProperty]
        public IEnumerable<User> users { get; set; }
        public RentDetailsModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
            users = _userService.GetAllUsers();
        }
    }
}
