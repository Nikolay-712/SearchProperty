namespace SearchProperty.Web.Controllers.OfferedProperties
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using SearchProperty.Data.Models;
    using SearchProperty.Data.Models.OfferedProperties;
    using SearchProperty.Data.Models.OfferedProperties.Enums;
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

        public async Task<IActionResult> AddDetails(PropertyInputModel propertyInput)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(propertyInput);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var property = this.propertyService.AddProperty(propertyInput, user.Id);

            this.TempData["data"] = JsonConvert.SerializeObject(property);
            return this.RedirectToAction("AddResidentialDetails");
        }

        public IActionResult AddResidentialDetails()
        {
            var data = this.TempData["data"].ToString();
            var property = JsonConvert.DeserializeObject<Property>(data);

            var tempProperty = this.propertyService.ShowPropertyTempData(property);

            return this.View(tempProperty);
        }

        [HttpPost]
        public IActionResult AddResidentialDetails(ResidentialDetailsInputModel residentialDetails)
        {
            var data = this.TempData["data"].ToString();
            var property = JsonConvert.DeserializeObject<Property>(data);

            return this.View();
        }
    }
}
