using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.DTO;
using WebApplication666.Model;
using Microsoft.AspNetCore.Identity.Data;
using Service;
namespace WebApplication666.Pages.Client
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public User Input { get; set; } = null!;
        private readonly ICommand<UserDTO> _save;

        public AddModel(ICommand<UserDTO> save)
        {
            _save = save;
        }

        public IEnumerable<SelectListItem> SelectCountry { get; set; } =
        [
            new ("Россия", "Россия"),
            new ("США", "США"),
            new ("Германия","Германия"),
            new ("Мексика","Мексика"),
            new ("Канада","Канада")
        ];

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _save.Execute(new UserDTO()
                {
                    Login = Input.Name,
                    Password = Input.Password,
                    Country = Input.Country
                });  
                return RedirectToPage("/Index");
            }
            return Page();
        }
           
    }
}
