using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MentalHealthApp.PWA.Pages
{
    public class CookieAuthRedirectionModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "Token")] 
        public string? AuthToken { get; set; } //
    }
}
