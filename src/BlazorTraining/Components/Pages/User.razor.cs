using Microsoft.AspNetCore.Components;

namespace BlazorTraining.Components.Pages
{
    public partial class User : ComponentBase
    {
        private UserViewModel model = new();
        private string message = string.Empty;

        private void HandleValidSubmit()
        {
            message = $"Uloženo: {model.FirstName} {model.LastName}, {model.City}";
        }

        private class UserViewModel
        {
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
        }
    }
}
