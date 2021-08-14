using System.Linq;
using AspNetCoreTemplate.Data;

namespace AspNetCoreTemplate.Web.Areas.Administration.Controllers
{
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly ApplicationDbContext dbContext;

        public DashboardController(ISettingsService settingsService, ApplicationDbContext dbContext)
        {
            this.settingsService = settingsService;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var dbContext = new HospitalContext();
            var viewModel = new IndexViewModel { SettingsCount = this.dbContext.Users.Count() };
            ViewBag.Users = this.dbContext.Users;
            var firstUser = this.dbContext.Users.Select(e =>new {Role = e.Roles}).First();
            firstUser.Role.FirstOrDefault().RoleId.ToString();
            return this.View(viewModel);
        }
    }
}
