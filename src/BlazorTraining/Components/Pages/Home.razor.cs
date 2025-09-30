using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorTraining.Components.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        public IJSRuntime jsRuntime { get; set; } = default!;

        private int jQueryCounter = 0;
        public async void ButtonClick()
        {
            jQueryCounter++;

            await jsRuntime.InvokeVoidAsync("versionJQuery");
        }
    }
}
