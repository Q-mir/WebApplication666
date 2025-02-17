using Domain.Commands;
using Domain.DTO;
using Domain.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;
using System.Windows.Input;
using WebApplication666.Model;

namespace WebApplication666.Pages.Client
{
    public class UpdateModel : PageModel
    {
        private readonly ICommand<UpdateClient> _command;
        private readonly IQueryService<SearchById, UserDTO> _query;

        public UpdateModel(ICommand<UpdateClient> command, IQueryService<SearchById, UserDTO> query)
        {
            //ArgumentNullException.ThrowIfNull(command);
            ArgumentNullException.ThrowIfNull(query);
            _command = command;
            _query = query;
        }

        public List<SelectListItem> Countryes { get; set; } =
            new List<SelectListItem>()
            {
                new SelectListItem("Россия", "Россия"),
                new SelectListItem("Китай", "Китай"),
                new SelectListItem("США", "США"),
                new SelectListItem("Мексика", "Мексика"),
                new SelectListItem("Канада", "Канада")
            };

        [BindProperty]
        public UserInDb Input { get; set; }

        public void OnGet(int id)
        {
            SearchById search = new()
            {
                Id = id,
            };
            var user = _query.Execute(search);
            if (user != null)
            {
                Input = new()
                {
                    Id = user.Id,
                    Name = user.Login,
                    Password = user.Password,
                    PasswordAgain = user.Password,
                    Country = user.Country
                };
            }
        }

        public IActionResult OnPost() 
        {
            if(!ModelState.IsValid) return Page();

            try
            {
            UpdateClient update = new()
            {
                Id = Input.Id,
                Password = Input.Password,
                Country = Input.Country,
            };
                _command.Execute(update);

            }
            catch (MissingFieldException ex)
            {
                return Page();
            }
            catch (InvalidDataException ex)
            {
                return Page();
            }
            return RedirectToPage("/client/show");

        }
    }
}
