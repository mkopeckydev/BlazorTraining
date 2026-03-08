using Microsoft.AspNetCore.Components;
using BlazorTraining.ViewModel;

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
    }
}
