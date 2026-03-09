using System.ComponentModel.DataAnnotations;

namespace BlazorTraining.ViewModel
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Pole je povinné.")]
        [MaxLength(32, ErrorMessage = "Maximální délka je {1} znaků.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pole je povinné.")]
        [MaxLength(32, ErrorMessage = "Maximální délka je {1} znaků.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pole je povinné.")]
        [MaxLength(32, ErrorMessage = "Maximální délka je {1} znaků.")]
        public string City { get; set; } = string.Empty;

        [MaxLength(64, ErrorMessage = "Maximální délka je {1} znaků.")]
        public string Description { get; set; } = string.Empty;
    }
}
