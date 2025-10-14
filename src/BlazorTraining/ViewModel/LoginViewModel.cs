using System.ComponentModel.DataAnnotations;

namespace BlazorTraining.ViewModel
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Zadej uživatelské jméno")]
        public string UserName { get; set; } = String.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Zadej heslo")]
        public string Password { get; set; } = String.Empty;
    }
}
