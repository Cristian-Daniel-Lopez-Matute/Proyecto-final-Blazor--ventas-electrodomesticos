using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalProgramacion.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;

namespace ProyectoFinalProgramacion.Pages.Clientes;

partial class EditarCliente
{
    [Inject] private IClienteServicio _clienteServicio { get; set; }

    [Inject] NavigationManager _navigationManager { get; set; }

    [Inject] SweetAlertService Swal { get; set; }

    [Parameter] public string IdCliente { get; set; }

    Cliente customer = new Cliente();
    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(IdCliente))
        {
            customer = await _clienteServicio.GetPorCodigo(IdCliente);
        }
    }

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(customer.IdCliente) || string.IsNullOrEmpty(customer.Nombres))
        {
            return;
        }

        bool edito = await _clienteServicio.Actualizar(customer);
        if (edito)
        {
            await Swal.FireAsync("Felicidades", "Cliente actualizado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Cliente no se pudo actualizar", SweetAlertIcon.Error);
        }
        _navigationManager.NavigateTo("/Clientes");

    }

    protected async Task Cancelar()
    {
        _navigationManager.NavigateTo("/Clientes");
    }

    protected async Task Eliminar()
    {
        bool elimino = false;

        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "¿Seguro que quiere eliminar el registro?",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            ConfirmButtonText = "Aceptar",
            CancelButtonText = "Cancelar"
        });

        if (!string.IsNullOrEmpty(result.Value))
        {
            elimino = await _clienteServicio.Eliminar(customer);

            if (elimino)
            {
                await Swal.FireAsync("Felicidades", "Cliente eliminado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Clientes");
            }
            else
            {
                await Swal.FireAsync("Error", "Cliente no se pudo eliminar", SweetAlertIcon.Error);
            }
        }
    }

}
