namespace SearchProperty.Web.Controllers.OfferedProperties
{
    using System.Net.Http;
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SearchProperty.Data.Models;
    using SearchProperty.Data.Models.OfferedProperties;
    using SearchProperty.Services.OfferedProperties;
    using SearchProperty.Web.ViewModels.OfferedProperties;

    [Authorize]
    public class PropertiesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPropertyService propertyService;

        public PropertiesController(UserManager<ApplicationUser> userManager, IPropertyService propertyService)
        {
            this.userManager = userManager;
            this.propertyService = propertyService;
        }

        public IActionResult AddProperty()
        {
            return this.View();
        }

        public async Task<IActionResult> ShowPropertyDetails(PropertyInputModel propertyInput)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(propertyInput);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var property = this.propertyService.AddProperty(propertyInput, user.Id);

            this.TempData["data"] = JsonConvert.SerializeObject(property);
            return this.RedirectToAction("AddDetails");
        }

        public IActionResult AddDetails()
        {
            try
            {
                var data = this.TempData["data"].ToString();
                var property = JsonConvert.DeserializeObject<Property>(data);

                var tempProperty = this.propertyService.ShowPropertyTempData(property);
                this.TempData["data"] = JsonConvert.SerializeObject(property);

                return this.View(tempProperty);
            }
            catch
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveProperty(TempPropertyViewModel tempProperty)
        {
            try
            {
                var data = this.TempData["data"].ToString();
                var property = JsonConvert.DeserializeObject<Property>(data);

                await this.propertyService.SavePropertyAsync(property, tempProperty);
            }
            catch
            {
                return this.BadRequest();
            }

            return this.View();
        }
    }
}
