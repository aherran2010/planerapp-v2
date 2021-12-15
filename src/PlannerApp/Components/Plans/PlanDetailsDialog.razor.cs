using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PlaneerApp.Client.Services.Exceptions;
using PlaneerApp.Client.Services.Interfaces;
using PlannerApp.Shared.Models;
using System.Reflection.Metadata;

namespace PlannerApp.Components
{
    public partial class PlanDetailsDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Inject]
        public IPlansService PlansService { get; set; }

        //parametro utilizado para recuperar el plan
        [Parameter]
        public string PlanId { get; set; }

        private PlanDetail _plan;
        private bool _isBusy;
        private string _errorMessage = string.Empty;

        private void Close()  {
            MudDialog.Cancel();
        }

        //OnParametersSet y OnParametersSetAsync: son ejecutados cuando el componente ha recbido todos los parámetros y sus valores han sido asignado
        //a sus respectivas propiedades, aunque esto de tener los parámetros asignados ocurre también en la etapa de inicialización,
        //los métodos OnParametersSet se ejecutan cada vez que se actualizan los parámetros a diferencia de los métodos OnInitialized
        //que se ejecutan 1 única vez.
        protected override void OnParametersSet()
        {
            //verificar la identificación del plan
            if (PlanId == null)
                throw new ArgumentNullException(nameof(PlanId));
            base.OnParametersSet();
        }

        protected async override Task OnInitializedAsync()
        {
            await FetchPlanAsync();
        }
        private async Task FetchPlanAsync()   {
            _isBusy = true;
            try  {
                var result = await PlansService.GetByIdAsync(PlanId);
                _plan = result.Value;
                StateHasChanged();
            }
            catch (ApiException ex)  {
                //todo
            }
            catch (Exception ex)     {
                //todo: Log this error                
            }
            _isBusy = false;
        }
    }      
    
}
