using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace XCalculate.Web.App.Components
{
    public class BadgeControl : ViewComponent
    {
#pragma warning disable 1998
        public async Task<IViewComponentResult> InvokeAsync(string text, string uri, ColorClass color = ColorClass.Primary)
#pragma warning restore 1998
        {
            var model = new BadgeControlModel
            {
                Text = text,
                Uri = uri,
                Color = color.ToString().ToLower()
            };

            return View("Default", model);
        }
    }
}
