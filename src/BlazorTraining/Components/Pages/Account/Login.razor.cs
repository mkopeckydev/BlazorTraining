using BlazorTraining.Services;
using BlazorTraining.Tools;
using BlazorTraining.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BlazorTraining.Components.Pages.Account
{
    public partial class Login : ComponentBase
    {
        [SupplyParameterFromForm]
        public LoginViewModel Model { get; set; } = new();

        [Inject]
        public AuthService Auth { get; set; } = default!;

        [Inject]
        public NavigationManager Navigation { get; set; } = default!;

        public string ErrorMessage { get; set; } = String.Empty;

        public async Task ProcessLogin()
        {
            try
            {
                var user = await Auth.Login(Model.UserName, Model.Password);
                if (user.LoggedIn)
                {
                    Navigation.NavigateTo(PageNames.LoginProcess + "?token=" + user.Token);
                }
                else
                {
                    ErrorMessage = "Chyba přihlášení";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
