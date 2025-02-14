using Domain.Commands;
using Domain.DTO;
using Domain.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    }
}
