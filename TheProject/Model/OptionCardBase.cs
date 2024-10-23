using Microsoft.AspNetCore.Components;

namespace TheProject.Model
{
    public class OptionCardBase : ComponentBase
    {
        [Parameter]
        public string Option { get; set; } = string.Empty;

        [Parameter]

        public EventCallback<string> OnOptionSelected { get; set; } 
        
        protected async void SelectOption()
        {
            await OnOptionSelected.InvokeAsync(Option);

        }
    }
}
