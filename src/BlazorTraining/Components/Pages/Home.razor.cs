using BlazorTraining.Tools;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorTraining.Components.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        public IJSRuntime jsRuntime { get; set; } = default!;

        [Inject]
        public NavigationManager Navigation { get; set; } = default!;

        private int jQueryCounter = 0;
        private int renderCounter = 0;
        public async void ButtonClick()
        {
            jQueryCounter++;

            await jsRuntime.InvokeVoidAsync("versionJQuery");
        }

        public void LoginClick()
        {
            Navigation.NavigateTo(PageNames.Login);
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            renderCounter++;

            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
